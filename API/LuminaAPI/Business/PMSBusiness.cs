using LuminaAPI.Model.PMS;
using LuminaAPI.Service;
using LuminaAPI.Service.Interface;
using MongoDB.Bson;

namespace LuminaAPI.Business
{
    public class PMSBusiness
    {
        public List<ProductList> GetProductLists(IPMSService pMSService, IPADService pADService, IPADTransService pADTransService)
        {
            List<PADTrans> pADTransacs = pADTransService.GetAll().Where(x => x.Count > 0).ToList();
            List<string> objectIds = pADTransacs.Select(x => x.PadID).ToList();
            List<PADetail> pADetails = pADService.GetAll().Where(y => objectIds.Contains(y._id)).ToList();
            List<ProductList> productLists = pADTransacs
    .Select(x => new ProductList
    {
        Price = x.Price
    })
    .Concat(pADetails
        .Select(y => new ProductList
        {
            Image = y.Image,
            ProductID = y.ProductID
        }))
    .ToList();

            return productLists;
        }
    }
}
