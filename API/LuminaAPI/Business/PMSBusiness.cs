using LuminaAPI.Model.PMS;
using LuminaAPI.Service;
using LuminaAPI.Service.Interface;
using MongoDB.Bson;

namespace LuminaAPI.Business
{
    public class PMSBusiness
    {
        private IPMSService _pmsservice;
        private IPADService _padService;
        private IPADTransService _padTransService;

        public PMSBusiness(IPMSService pmsservice, IPADService padService, IPADTransService padTransService)
        {
            _pmsservice = pmsservice;
            _padService = padService;
            _padTransService = padTransService;
        }

        public List<ProductList> GetProductLists(int categoryID, int sizeID, int modelID)
        {
            List<PADetail> pADetails = new List<PADetail>();
            if(modelID > 0)
            {
                pADetails = this._padService.GetAll().Where(x => x.CategoryID == categoryID && x.SizeID == sizeID && x.ModelID == modelID).ToList();
            }
            else
            {
                pADetails = this._padService.GetAll().Where(x => x.CategoryID == categoryID && x.SizeID == sizeID).ToList();
            }

            List<string> objectIDs = pADetails.Select(x => x._id).ToList();
            List<PADTrans> pADTransacs = this._padTransService.GetAll().Where(x => objectIDs.Contains(x.PadID) &&  x.Count > 0).ToList();
            List<ProductList> productLists = (from trans in pADTransacs
                             join detail in pADetails on trans.PadID equals detail._id
                             select new ProductList
                             {
                                 Price = trans.Price,
                                 Image = detail.Image,
                                 ProductID = detail.ProductID
                             }).ToList();

            return productLists;
        }

        public List<CategoryDetail> GetCategoryDetails(ICategoryService _categoryService)
        {
           List<CategoryDetail> categories = _categoryService.GetAll().Where(x=>x.IsActive).ToList();
           return categories;
        }

        public List<ModelDetail> GetModelDetails(IModelService _modelService)
        {
            List<ModelDetail> models = _modelService.GetAll().Where(x => x.IsActive).ToList();
            return models;
        }

        public List<SizeDetail> GetSizeDetails(ISizeService _sizeService, int categoryID)
        {
            List<SizeDetail> sizes = _sizeService.GetAll().Where(x => x.IsActive && x.CategoryID == categoryID).ToList();
            return sizes;
        }
    }
}
