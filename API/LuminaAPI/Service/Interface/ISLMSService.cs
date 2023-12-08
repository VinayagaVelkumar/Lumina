using LuminaAPI.Model.SLMS;

namespace LuminaAPI.Service.Interface
{
    public interface ISLMSService
    {
        public List<SaleDetail> GetAll();

        public SaleDetail GetByID(string id);

        public bool Insert(SaleDetail saleDetail);

        public bool Update(SaleDetail saleDetail);
    }
}
