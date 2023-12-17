using LuminaAPI.Business;
using LuminaAPI.Model.Config;
using LuminaAPI.Model.PMS;
using LuminaAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace LuminaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PMSController : ControllerBase
    {
        private readonly IPMSService _pmsService;
        private readonly IPADService _padService;
        private readonly IPADTransService _padTransService;
        private readonly IAliasService _aliasService;
        private readonly IColorService _colorService;
        private readonly ICategoryService _categoryService;
        private readonly ISizeService _sizeService;
        private readonly IModelService _modelService;
        private readonly IImageService _imageService;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        #region Constructer
        public PMSController(IPMSService pmsService, CollectionNames collectionNames, ConnectionConfig connectionConfig, IPADService padService, IPADTransService padTransService, IAliasService aliasService, IColorService colorService,ICategoryService categoryService, ISizeService sizeService, IModelService modelService, IImageService imageService)
        {
            this._pmsService = pmsService;
            this._padService = padService;
            this._padTransService = padTransService;
            this._aliasService = aliasService;
            this._colorService = colorService;
            this._sizeService = sizeService;
            this._categoryService = categoryService;
            this._modelService = modelService;
            this._imageService = imageService;
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;          
        }
        #endregion

        [HttpGet(Name = "GetProductList")]
        public List<ProductList> GetProductList()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(); 
                List<ProductList> products = pMSBusiness.GetProductLists(this._pmsService, this._padService, this._padTransService);
                return products;
            }
            catch
            {
                throw;
            }
        }

        #region Product Detail
        [HttpGet(Name ="GetProducts")]
        public List<ProductDetail> GetProducts()
        {
            try
            {
                List<ProductDetail> products = this._pmsService.GetAll();
                return products;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetProductByID")]
        public ProductDetail GetProductByID(string id)
        {
            try
            {
                ProductDetail product = this._pmsService.GetByID(id);
                return product;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost(Name = "InsertProduct")]
        public bool InsertProduct(ProductDetail product)
        {
            try
            {
                bool isCreated = this._pmsService.Insert(product);
                return isCreated;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut(Name = "UpdateProduct")]
        public bool UpdateProduct(ProductDetail product)
        {
            try
            {
                bool isUpdated = this._pmsService.Update(product);
                return isUpdated;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Product Availability Detail
        [HttpGet(Name ="GetAllPA")]
        public List<PADetail> GetAllPAD()
        {
            try
            {
                List<PADetail> pADetails = this._padService.GetAll();
                return pADetails;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetPADByID")]
        public PADetail GetPADByID(string id)
        {
            try
            {
                PADetail pADetail = this._padService.GetByID(id);
                return pADetail;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost(Name = "InsertPAD")]
        public bool InsertPADetail(PADetail paDetail)
        {
            try
            {
                bool isCreated = this._padService.Insert(paDetail);
                return isCreated;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut(Name = "UpdatePAD")]
        public bool UpdatePADetail(PADetail paDetail)
        {
            try
            {
                bool isUpdated = this._padService.Update(paDetail);
                return isUpdated;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Product Availability Transacs Detail
        [HttpGet(Name = "GetAllPATrans")]
        public List<PADTrans> GetAllPATrans()
        {
            try
            {
                List<PADTrans> pATransacs = this._padTransService.GetAll();
                return pATransacs;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetPATransByID")]
        public PADTrans GetPATransByID(string id)
        {
            try
            {
                PADTrans pATrans = this._padTransService.GetByID(id);
                return pATrans;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost(Name = "InsertPATran")]
        public bool InsertPATran(PADTrans paTrans)
        {
            try
            {
                bool isCreated = this._padTransService.Insert(paTrans);
                return isCreated;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut(Name = "UpdatePATran")]
        public bool UpdatePATran(PADTrans paTrans)
        {
            try
            {
                bool isUpdated = this._padTransService.Update(paTrans);
                return isUpdated;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Alias Detail

        [HttpGet(Name = "GetAllAlias")]
        public List<AliasDetail> GetAllAlias()
        {
            try
            {
                List<AliasDetail> aliasDetails = this._aliasService.GetAll();
                return aliasDetails;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetAliasByID")]
        public AliasDetail GetAliasByID(string id)
        {
            try
            {
                AliasDetail aliasDetail = this._aliasService.GetByID(id);
                return aliasDetail;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Color Detail

        [HttpGet(Name = "GetAllColors")]
        public List<ColorDetail> GetAllColors()
        {
            try
            {
                List<ColorDetail> colorDetails = this._colorService.GetAll();
                return colorDetails;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetColorByID")]
        public ColorDetail GetColorByID(string id)
        {
            try
            {
                ColorDetail colorDetail = this._colorService.GetByID(id);
                return colorDetail;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Category Detail

        [HttpGet(Name = "GetAllCategories")]
        public List<CategoryDetail> GetAllCategories()
        {
            try
            {
                List<CategoryDetail> categoryDetails = this._categoryService.GetAll();
                return categoryDetails;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetCategoryByID")]
        public CategoryDetail GetCategoryByID(string id)
        {
            try
            {
                CategoryDetail categoryDetail = this._categoryService.GetByID(id);
                return categoryDetail;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Size Detail

        [HttpGet(Name = "GetAllSizes")]
        public List<SizeDetail> GetAllSizes()
        {
            try
            {
                List<SizeDetail> sizeDetails = this._sizeService.GetAll();
                return sizeDetails;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetSizeByID")]
        public SizeDetail GetSizeByID(string id)
        {
            try
            {
                SizeDetail sizeDetail = this._sizeService.GetByID(id);
                return sizeDetail;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Moodel Detail

        [HttpGet(Name = "GetAllModels")]
        public List<ModelDetail> GetAllModels()
        {
            try
            {
                List<ModelDetail> modelDetails = this._modelService.GetAll();
                return modelDetails;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetModelByID")]
        public ModelDetail GetModelByID(string id)
        {
            try
            {
                ModelDetail modelDetail = this._modelService.GetByID(id);
                return modelDetail;
            }
            catch
            {
                throw;
            }
        }

        #endregion  

        #region Image Detail

        [HttpGet(Name = "GetAllImages")]
        public List<ImageDetail> GetImageDetails()
        {
            try
            {
                List<ImageDetail> imageDetails = this._imageService.GetAll();
                return imageDetails;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetImageByID")]
        public ImageDetail GetImageByID(string id)
        {
            try
            {
                ImageDetail imageDetail = this._imageService.GetByID(id);
                return imageDetail;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
