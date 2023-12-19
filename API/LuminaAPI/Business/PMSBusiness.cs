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

        public List<ProductDetail> GetProducts(IBrandService brandService, IModelService modelService)
        {
            List<ProductDetail> products = new List<ProductDetail>();
            products = this._pmsservice.GetAll();
            List<BrandDetail> brands = brandService.GetAll();
            List<ModelDetail> models = modelService.GetAll();
            List<ProductDetail> result = products
      .Join(
          brands,
          product => product.BrandID,
          brand => brand.BrandID,
          (product, brand) => new
          {
              Product = product,
              BrandName = brand.BrandName
          }
      )
      .Join(
          models,
          combined => combined.Product.ModelID,
          model => model.ModelID,
          (combined, model) => new ProductDetail
          {
              _id = combined.Product._id,
              ProductID = combined.Product.ProductID,
              ProductName = combined.Product.ProductName,
              IsActive = combined.Product.IsActive,
              BrandID = combined.Product.BrandID,
              ModelID = combined.Product.ModelID,
              Brand = combined.BrandName,
              Model = model.ModelName
          }
      )
      .ToList();


            return result;
        }

        public List<ProductList> GetProductLists(int categoryID, int sizeID, int modelID)
        {
            List<PADetail> pADetails = new List<PADetail>();
            List<ProductDetail> products = new List<ProductDetail>();
            if(modelID > 0)
            {
                products = this._pmsservice.GetAll().Where(p => p.ModelID == modelID).ToList();
                List<string> productIDs = products.Select(p => p.ProductID).ToList();
                pADetails = this._padService.GetAll().Where(x => x.CategoryID == categoryID && x.SizeID == sizeID && productIDs.Contains(x.ProductID)).ToList();
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

        public List<ColorDetail> GetColors(IColorService _colorService)
        {
            List<ColorDetail> colors = _colorService.GetAll().Where(x => x.IsActive).ToList();
            return colors;
        }
    }
}
