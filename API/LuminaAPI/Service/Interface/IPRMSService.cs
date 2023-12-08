using LuminaAPI.Model.PRMS;

namespace LuminaAPI.Service.Interface
{
    public interface IPRMSService
    {
        public List<PurchaseDetail> GetAll();

        public PurchaseDetail GetByID(string id);

        public bool Insert(PurchaseDetail prDetail);

        public bool Update(PurchaseDetail prDetail);
    }
}
