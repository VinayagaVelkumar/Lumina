using LuminaAPI.Model.PMS;
using LuminaAPI.Service.Interface;
using LuminaAPI.Repository;
using MongoDB.Driver;
using MongoDB.Bson;
using LuminaAPI.Model.Config;

namespace LuminaAPI.Service
{
    #region Product Detail
    public class PMSService : IPMSService
    {

        private readonly MongoDBHandler<ProductDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public PMSService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<ProductDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Product);
        }

        public List<ProductDetail> GetAll()
        {
            try
            {
                List<ProductDetail> products = dBHandler.GetAllDocuments().Where(x => x.IsActive == true).ToList();
                return products;
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public bool Insert(ProductDetail product)
        {
            try
            {
                dBHandler.InsertDocument(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update (ProductDetail product)
        {
            try
            {
                var filter = Builders<ProductDetail>.Filter.Eq(p => p._id, product._id);
                var updateProduct = Builders<ProductDetail>.Update.Set(p => p, product);
                dBHandler.UpdateDocument(filter, updateProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ProductDetail GetByID(string id) 
        {
            try
            {
                ProductDetail productDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return productDetail;
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion

    #region Product Availability Detail
    public class PADService : IPADService
    {
        private readonly MongoDBHandler<PADetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public PADService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<PADetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.ProductAvailability);
        }
        public List<PADetail> GetAll()
        {
            try
            {
                List<PADetail> paDetails = dBHandler.GetAllDocuments();
                return paDetails;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public PADetail GetByID(string id)
        {
            try
            {
                PADetail paDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return paDetail;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(PADetail paDetail)
        {
            try
            {
                dBHandler.InsertDocument(paDetail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PADetail paDetail)
        {
            try
            {
                var filter = Builders<PADetail>.Filter.Eq(p => p._id, paDetail._id);
                var updatePADetail = Builders<PADetail>.Update.Set(p => p, paDetail);
                dBHandler.UpdateDocument(filter, updatePADetail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    #endregion

    #region Product Availability Transacs
    public class PADTransService : IPADTransService
    {
        private readonly MongoDBHandler<PADTrans> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public PADTransService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<PADTrans>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.ProductAvailabilityTrans);
        }
        public List<PADTrans> GetAll()
        {
            try
            {
                List<PADTrans> paTransacs = dBHandler.GetAllDocuments();
                return paTransacs;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public PADTrans GetByID(string id)
        {
            try
            {
                PADTrans paTransDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return paTransDetail;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(PADTrans paDetail)
        {
            try
            {
                dBHandler.InsertDocument(paDetail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PADTrans paDetail)
        {
            try
            {
                var filter = Builders<PADTrans>.Filter.Eq(p => p._id, paDetail._id);
                var updatePATransDetail = Builders<PADTrans>.Update.Set(p => p, paDetail);
                dBHandler.UpdateDocument(filter, updatePATransDetail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    #endregion

    #region Alias Detail
    public class AliasService : IAliasService
    {
        private readonly MongoDBHandler<AliasDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public AliasService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<AliasDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Alias);
        }
        public List<AliasDetail> GetAll()
        {
            try
            {
                List<AliasDetail> aliasDetails = dBHandler.GetAllDocuments();
                return aliasDetails;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public AliasDetail GetByID(string id)
        {
            try
            {
                AliasDetail aliasDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return aliasDetail;
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion

    #region Color Detail
    public class ColorService : IColorService
    {
        private readonly MongoDBHandler<ColorDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public ColorService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<ColorDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Colour);
        }
        public List<ColorDetail> GetAll()
        {
            try
            {
                List<ColorDetail> colorDetails = dBHandler.GetAllDocuments();
                return colorDetails;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public ColorDetail GetByID(string id)
        {
            try
            {
                ColorDetail colorDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return colorDetail;
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion

    #region Category Detail
    public class CategoryService : ICategoryService
    {
        private readonly MongoDBHandler<CategoryDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public CategoryService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<CategoryDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Category);
        }
        public List<CategoryDetail> GetAll()
        {
            try
            {
                List<CategoryDetail> categoryDetails = dBHandler.GetAllDocuments();
                return categoryDetails;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public CategoryDetail GetByID(string id)
        {
            try
            {
                CategoryDetail categoryDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return categoryDetail;
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion

    #region Size Detail
    public class SizeService : ISizeService
    {
        private readonly MongoDBHandler<SizeDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public SizeService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<SizeDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Size);
        }
        public List<SizeDetail> GetAll()
        {
            try
            {
                List<SizeDetail> sizeDetails = dBHandler.GetAllDocuments();
                return sizeDetails;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public SizeDetail GetByID(string id)
        {
            try
            {
                SizeDetail sizeDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return sizeDetail;
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion

    #region Model Detail
    public class ModelService : IModelService
    {
        private readonly MongoDBHandler<ModelDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public ModelService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<ModelDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Model);
        }
        public List<ModelDetail> GetAll()
        {
            try
            {
                List<ModelDetail> modelDetails = dBHandler.GetAllDocuments();
                return modelDetails;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public ModelDetail GetByID(string id)
        {
            try
            {
                ModelDetail modelDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return modelDetail;
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion

    #region Image Detail
    public class ImageService : IImageService
    {
        private readonly MongoDBHandler<ImageDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public ImageService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<ImageDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Image);
        }
        public List<ImageDetail> GetAll()
        {
            try
            {
                List<ImageDetail> imageDetails = dBHandler.GetAllDocuments();
                return imageDetails;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public ImageDetail GetByID(string id)
        {
            try
            {
                ImageDetail imageDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return imageDetail;
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion
}
