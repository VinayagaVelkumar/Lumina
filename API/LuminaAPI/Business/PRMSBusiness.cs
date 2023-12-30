using LuminaAPI.Model.Config;
using LuminaAPI.Model.PMS;
using LuminaAPI.Model.PRMS;
using LuminaAPI.Model.SLMS;
using LuminaAPI.Service.Interface;

namespace LuminaAPI.Business
{
    public class PRMSBusiness
    {
        private IPRMSService pRMSService;
        private IPMSService pMSService;
        private IPADService pADService;
        private IPADTransService pADTransService;

        public PRMSBusiness(IPRMSService _iprmsService, IPMSService _pMSService, IPADService _pADService, IPADTransService _pADTransService)
        {
            pRMSService = _iprmsService;
            pMSService = _pMSService;
            pADService = _pADService;
            pADTransService = _pADTransService;
        }

        public bool AddPurchaseDetail(PurchaseDetailFromUI detailFromUI)
        {
            try
            {
                foreach (int SizeID in detailFromUI.SizeIDs)
                {
                    PurchaseDetail purchaseDetail = new PurchaseDetail();
                    purchaseDetail.ProductID = detailFromUI.ProductID;
                    purchaseDetail.MRP = detailFromUI.MRP;
                    purchaseDetail.PurchasePrice = detailFromUI.PurchasePrice;
                    purchaseDetail.PurchaseDate = DateTime.Now;
                    purchaseDetail.Count = detailFromUI.Count;
                    purchaseDetail.DiscountCode = detailFromUI.DiscountCode;

                    PADetail pADetail = this.pADService.GetAll().Where(x => x.ProductID == detailFromUI.ProductID && x.CategoryID == detailFromUI.CategoryID && x.SizeID == SizeID && x.ColorID == detailFromUI.ColorID && x.TagID == detailFromUI.TagID).FirstOrDefault();
                    if (pADetail == null)
                    {
                        ProductDetail product = this.pMSService.GetAll().Where(x => x.ProductID == detailFromUI.ProductID).FirstOrDefault();
                        PADetail newPADetail = new PADetail();
                        newPADetail.ProductID = detailFromUI.ProductID;
                        newPADetail.CategoryID = detailFromUI.CategoryID;
                        newPADetail.SizeID = SizeID;
                        newPADetail.ColorID = detailFromUI.ColorID;
                        newPADetail.TagID = detailFromUI.TagID;
                        newPADetail.IsActive = true;

                        bool isInserted = this.pADService.Insert(newPADetail);
                        if (isInserted)
                        {
                            pADetail = this.pADService.GetAll().Where(x => x.ProductID == detailFromUI.ProductID && x.CategoryID == detailFromUI.CategoryID && x.SizeID == SizeID && x.ColorID == detailFromUI.ColorID && x.TagID == detailFromUI.TagID).FirstOrDefault();
                        }
                    }

                    purchaseDetail.PadID = pADetail._id;

                    PADTrans pADTrans = this.pADTransService.GetAll().Where(x => x.PadID == pADetail._id).FirstOrDefault();
                    if (pADTrans != null)
                    {
                        purchaseDetail.PrevCount = pADTrans.Count;
                        purchaseDetail.CurrentCount = pADTrans.Count + purchaseDetail.Count;
                        pADTrans.Count += purchaseDetail.Count;
                        pADTrans.Price = detailFromUI.MRP - detailFromUI.DiscountCode;
                        pADTrans.MRP = detailFromUI.MRP;
                        bool isUpdated = this.pADTransService.Update(pADTrans);
                    }
                    else
                    {
                        PADTrans newPADTrans = new PADTrans();
                        newPADTrans.PadID = pADetail._id;
                        newPADTrans.Count = purchaseDetail.Count;
                        newPADTrans.Price = detailFromUI.MRP - detailFromUI.DiscountCode;
                        newPADTrans.MRP = detailFromUI.MRP;
                        bool isCreated = this.pADTransService.Insert(newPADTrans);
                    }

                    bool createPurchase = this.pRMSService.Insert(purchaseDetail);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UploadBillAsync(IFormFile file, TwilioConfig twilioConfig, DriveConfig driveConfig)
        {
            try
            {
                GoogleDriveBusiness googleDriveBusiness = new GoogleDriveBusiness(driveConfig);
                var filePath = driveConfig.UploadFolder + file.FileName;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Upload the file to Google Drive
                var driveLink = await googleDriveBusiness.UploadFile(filePath, file.FileName);
                _ = Task.Run(async () =>
                {

                    if (driveLink != null)
                    {

                        var message = $"Here is the file: {driveLink}";
                        WhatsappBusiness whatsappBusiness = new WhatsappBusiness(twilioConfig);
                        await whatsappBusiness.SendMessage(message, driveLink);
                    }
                });
                return true;
                }
            catch
            {
                throw;
            }
        }

        public List<BillPAList> GetBillPALists(List<string> billIDs, IColorService colorService, ISizeService sizeService, ICategoryService categoryService)
        {
            try
            {
                List<BillPAList> billPALists = new List<BillPAList>();
                List<PADetail> pALists = this.pADService.GetAll().Where(x => billIDs.Contains(x._id)).ToList();
                List<PurchaseDetail> purchases = this.pRMSService.GetAll().Where(x => billIDs.Contains(x.PadID)).ToList();
                List<ColorDetail> colors = colorService.GetAll();
                List<SizeDetail> sizes = sizeService.GetAll();
                List<CategoryDetail> categories = categoryService.GetAll();

                var joinedDetails = from padetail in pALists
                                    join color in colors on padetail.ColorID equals color.ColorID
                                    join category in categories on padetail.CategoryID equals category.CategoryID
                                    join size in sizes on padetail.SizeID equals size.SizeID
                                    join purchase in purchases on padetail._id equals purchase.PadID
                                    select new
                                    {
                                        PADetail = padetail,
                                        ColorName = color.ColorName,
                                        CategoryName = category.CategoryName,
                                        Price = purchase.PurchasePrice,
                                        CategoryId = padetail.CategoryID
                                    };

                billPALists = joinedDetails.Select(j =>
                       new BillPAList
                       {
                           _id = j.PADetail._id,
                           ProductID = j.PADetail.ProductID,
                           Category = j.CategoryName,
                           Color = j.ColorName,
                           LastPurchasePrice = j.Price,
                           CategoryID = j.CategoryId
                       }).ToList();

                foreach(BillPAList bill in billPALists)
                {
                    List<SizeDetail> sizeDetails = sizes.Where(x => x.CategoryID == bill.CategoryID).ToList();
                    bill.Count = sizeDetails.Count;
                    bill.Sizes = string.Join(",", sizeDetails.Select(sd => sd.Size));
                    bill.EstimatedPrice = bill.Count * bill.LastPurchasePrice;
                }

                int sumOfEstimatedPrices = billPALists.Sum(item => item.EstimatedPrice);


                foreach (var item in billPALists)
                {
                    item.EstimatedTotalPrice = sumOfEstimatedPrices;
                }

                List<BillPAList> distinctList = billPALists.GroupBy(x => x._id).Select(group => group.First()).ToList();

                billPALists = distinctList.GroupBy(x => new { x.ProductID, x.Category, x.Color, x.Count }).Select(group => group.First()).ToList();

                return billPALists;
            }
            catch
            {
                throw;
            }
        }
    }
}
