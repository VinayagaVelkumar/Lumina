using LuminaAPI.Model.PMS;

namespace LuminaAPI.Service.Interface
{
    public interface IPMSService
    {
        public List<ProductDetail> GetAll();

        public bool Insert(ProductDetail product);

        public bool Update(ProductDetail product);

        public ProductDetail GetByID (string id);
    }

    public interface IPADService
    {
        public List<PADetail> GetAll();

        public PADetail GetByID(string id);

        public bool Insert(PADetail paDetail);

        public bool Update(PADetail paDetail);

        public bool UpdateImage(PADetail paDetail);
    }

    public interface IPADTransService
    {
        public List<PADTrans> GetAll();

        public PADTrans GetByID(string id);

        public bool Insert(PADTrans paTransDetail);

        public bool Update(PADTrans paTransDetail);
    }

    public interface IAliasService
    {
        public List<AliasDetail> GetAll();

        public AliasDetail GetByID(string id);
    }

    public interface IColorService
    {
        public List<ColorDetail> GetAll();

        public ColorDetail GetByID(string id);
    }

    public interface ICategoryService
    {
        public List<CategoryDetail> GetAll();

        public CategoryDetail GetByID(string id);
    }

    public interface ISizeService
    {
        public List<SizeDetail> GetAll();

        public SizeDetail GetByID(string id);
    }

    public interface IModelService
    {
        public List<ModelDetail> GetAll();

        public ModelDetail GetByID(string id);
    }

    public interface IImageService
    {
        public List<ImageDetail> GetAll();

        public ImageDetail GetByID(string id);
    }

    public interface IBrandService
    {
        public List<BrandDetail> GetAll();

        public BrandDetail GetByID(string id);
    }

    public interface ITagService
    {
        public List<TagDetail> GetAll();

        public TagDetail GetByID(string id);
    }
}
