using LuminaAPI.Model.PMS;
using LuminaAPI.Model.PRMS;
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
    }
}
