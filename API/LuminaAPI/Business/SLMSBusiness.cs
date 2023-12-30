using LuminaAPI.Model.Config;
using LuminaAPI.Model.PMS;
using LuminaAPI.Model.PRMS;
using LuminaAPI.Model.SLMS;
using LuminaAPI.Service.Interface;

namespace LuminaAPI.Business
{
    public class SLMSBusiness
    {
        private IPMSService _pmsservice;
        private IPADService _padService;
        private IPADTransService _padTransService;
        private IPRMSService _prmsService;
        private ISLMSService _slmsService;
        private IColorService _colorService;
        private ITagService _tagService;
        private ICategoryService _CategoryService;
        private ISizeService _SizeService;
        private TwilioConfig _twilioConfig;

        public SLMSBusiness(IPMSService pmsservice, IPADService padService, IPADTransService padTransService, IPRMSService prmsService, ISLMSService slmsService, IColorService colorService, ITagService tagService, ICategoryService categoryService, ISizeService sizeService, TwilioConfig twilioConfig)
        {
            this._pmsservice = pmsservice;
            this._padService = padService;
            this._padTransService = padTransService;
            this._prmsService = prmsService;
            this._slmsService = slmsService;
            this._CategoryService = categoryService;
            this._colorService = colorService;
            this._tagService = tagService;
            this._SizeService = sizeService;
            this._twilioConfig = twilioConfig;
        }

        public bool AddSale(string padID, int soldPrice, int Count)
        {
            try
            {
                PADetail pADetail = this._padService.GetAll().Where(x =>x._id == padID ).FirstOrDefault();
                PADTrans pADTrans = this._padTransService.GetAll().Where(x => x.PadID == padID).FirstOrDefault();
                PurchaseDetail purchaseDetail = this._prmsService.GetAll().Where(x => x.PadID == padID).FirstOrDefault();
                SaleDetail slDetail = new SaleDetail();
                slDetail.Count = Count;
                slDetail.SaleDate = DateTime.Now;
                slDetail.SoldPrice = soldPrice;
                slDetail.PadID = padID;
                slDetail.UserID = 0;
                slDetail.ProductID = pADetail.ProductID;
                slDetail.PurchasedPrice = purchaseDetail.PurchasePrice;
                slDetail.MRP = pADTrans.MRP;
                slDetail.PreviousCount = pADTrans.Count;
                bool isSaleInserted = this._slmsService.Insert(slDetail);

                if (isSaleInserted)
                {
                    pADTrans.Count = pADTrans.Count - Count;
                    this._padTransService.Update(pADTrans);
                    string color = this._colorService.GetAll().Where(x => x.ColorID == pADetail.ColorID).Select(x => x.ColorName).FirstOrDefault();
                    string tag = this._tagService.GetAll().Where(x => x.TagID == pADetail.TagID).Select(x => x.TagName).FirstOrDefault();
                    int size = this._SizeService.GetAll().Where(x => x.SizeID == pADetail.SizeID).Select(x => x.Size).FirstOrDefault();
                    string category = this._CategoryService.GetAll().Where(x => x.CategoryID == pADetail.CategoryID).Select(x => x.CategoryName).FirstOrDefault();
                    string productName = this._pmsservice.GetAll().Where(x => x.ProductID == pADetail.ProductID).Select(x => x.ProductName).FirstOrDefault();
                    string messageBody = $"An Sale has been completed on Lumina. Please find the below Details:" +
                    $"\nProduct ID: {pADetail.ProductID} ," +
                    $"\nProduct Name: {productName} ," +
                    $"\nCategory: {category} ," +
                    $"\nColor: {color} ," +
                    $"\nTag: {tag} ," +
                    $"\nSize: {size}  ," +
                    $"\nMRP: {slDetail.MRP} ," +
                    $"\nSold Price: {slDetail.SoldPrice} ," +
                    $"\nPurchased Price: {slDetail.PurchasedPrice} ," +
                    $"\nCount: {slDetail.Count}.";

                    _ = Task.Run(async () =>
                    {
                        WhatsappBusiness whatsapp = new WhatsappBusiness(this._twilioConfig);
                        await whatsapp.SendMessage(messageBody);
                    });

                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public List<SalePAList> GetAllSalePA()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsservice, this._padService, this._padTransService);
                List<SalePAList> pADetails = pMSBusiness.GetSalePAList(this._colorService, this._tagService, this._SizeService, this._CategoryService, 0);
                if (pADetails != null && pADetails.Count > 0)
                {
                    pADetails = pADetails.Where(x => x.Count > 0).OrderBy(x => x.CategoryID).ThenBy(x => x.ProductID).ThenBy(x => x.ColorID).ThenBy(x => x.SizeID).ToList();
                }
                return pADetails;
            }
            catch
            {
                throw;
            }
        }
    }
}
