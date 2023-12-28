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

        public SLMSBusiness(IPMSService pmsservice, IPADService padService, IPADTransService padTransService, IPRMSService prmsService, ISLMSService slmsService)
        {
            _pmsservice = pmsservice;
            _padService = padService;
            _padTransService = padTransService;
            _prmsService = prmsService;
            _slmsService = slmsService;
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
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
