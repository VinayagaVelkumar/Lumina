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
        private readonly IBrandService _brandService;
        private readonly ITagService _tagService;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;
        private readonly ILogger<PMSController> _logger;


        #region Constructer
        public PMSController(IPMSService pmsService, CollectionNames collectionNames, ConnectionConfig connectionConfig, IPADService padService, IPADTransService padTransService, IAliasService aliasService, IColorService colorService, ICategoryService categoryService, ISizeService sizeService, IModelService modelService, IImageService imageService, IBrandService brandService, ITagService tagService, ILogger<PMSController> logger)
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
            this._brandService = brandService;
            this._tagService = tagService;
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            this._logger = logger;
        }
        #endregion

        [HttpGet(Name = "GetProductList")]
        public List<ProductList> GetProductList(int categoryID, int sizeID, int modelID)
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<ProductList> products = pMSBusiness.GetProductLists(categoryID, sizeID, modelID);
                return products;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetCategories")]
        public List<CategoryDetail> GetCategories()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<CategoryDetail> categories = pMSBusiness.GetCategoryDetails(this._categoryService);
                return categories;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetModels")]
        public List<ModelDetail> GetModels()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<ModelDetail> models = pMSBusiness.GetModelDetails(this._modelService);
                return models;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetSizes")]
        public List<SizeDetail> GetSizes(int categoryID)
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<SizeDetail> sizes = pMSBusiness.GetSizeDetails(this._sizeService, categoryID);
                return sizes;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetColors")]
        public List<ColorDetail> GetColors()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<ColorDetail> colors = pMSBusiness.GetColors(this._colorService);
                return colors;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetTags")]
        public List<TagDetail> GetTags()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<TagDetail> tags = pMSBusiness.GetTags(this._tagService);
                return tags;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetBrands")]
        public List<BrandDetail> GetBrands()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<BrandDetail> brands = this._brandService.GetAll().Where(x => x.IsActive == true).ToList();
                return brands;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        #region Product Detail
        [HttpGet(Name = "GetProducts")]
        public List<ProductDetail> GetProducts()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<ProductDetail> products = pMSBusiness.GetProducts(this._brandService, this._modelService);
                return products;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetProductByID")]
        public ProductList GetProductByID(string id)
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                ProductList product = pMSBusiness.GetProductByID(id);
                return product;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpPost(Name = "InsertProduct")]
        public bool InsertProduct([FromBody] ProductDetail product)
        {
            try
            {
                bool isCreated = this._pmsService.Insert(product);
                return isCreated;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }
        #endregion

        #region Product Availability Detail
        [HttpGet(Name = "GetAllPA")]
        public List<PAList> GetAllPAD()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<PAList> pADetails = pMSBusiness.GetPAList(this._colorService, this._tagService, this._sizeService, this._categoryService);
                if (pADetails != null && pADetails.Count > 0)
                {
                    pADetails = pADetails.Where(x => x.Count > 0).OrderByDescending(x => x.ProductID).OrderByDescending(x => x.SizeID).ToList();
                }
                return pADetails;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetAllPAImage")]
        public List<PAImageList> GetAllPADWithoutImage()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<PAImageList> pADetails = pMSBusiness.GetPAListWithoutImage(this._colorService, this._tagService, this._sizeService, this._categoryService);
                return pADetails;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet(Name = "GetAllPAImageCount")]
        public int GetAllPADWithoutImageCount()
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                List<PAImageList> pADetails = pMSBusiness.GetPAListWithoutImage(this._colorService, this._tagService, this._sizeService, this._categoryService);
                if (pADetails != null)
                {
                    return pADetails.Count;
                }
                return 0;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpPut(Name = "UpdatePAImage")]
        public bool UpdatePAImage(int categoryID, string productID, int colorID, IFormFile image)
        {
            try
            {
                PMSBusiness pMSBusiness = new PMSBusiness(this._pmsService, this._padService, this._padTransService);
                bool isUpdated = pMSBusiness.UpdatePAImage(categoryID, productID, colorID, image, this._collectionNames);
                return isUpdated;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
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
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw;
            }
        }

        #endregion
    }
}
