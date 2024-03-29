﻿using LuminaAPI.Model.Config;
using LuminaAPI.Model.PMS;
using LuminaAPI.Model.SLMS;
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
            try
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
            catch
            {
                throw;
            }
        }

        public List<ProductList> GetProductLists(int categoryID, int sizeID, int modelID)
        {
            try
            {
                List<PADetail> pADetails = new List<PADetail>();
                List<ProductDetail> products = new List<ProductDetail>();
                if (modelID > 0)
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
                List<PADTrans> pADTransacs = this._padTransService.GetAll().Where(x => objectIDs.Contains(x.PadID) && x.Count > 0).ToList();
                List<ProductList> productLists = (from trans in pADTransacs
                                                  join detail in pADetails on trans.PadID equals detail._id
                                                  select new ProductList
                                                  {
                                                      Price = trans.MRP,
                                                      Image = detail.Image,
                                                      ProductID = detail.ProductID
                                                  }).ToList();

                return productLists;
            }
            catch
            {
                throw;
            }
        }

        public ProductList GetProductByID(string padID)
        {
            try
            {
                ProductList product = new ProductList();
                PADetail pADetail = this._padService.GetByID(padID);
                PADTrans pADTransac = this._padTransService.GetAll().Where(x => x.PadID == pADetail._id).FirstOrDefault();
                product.Price = pADTransac.MRP;
                product.Image = pADetail.Image;
                product.ProductID = pADetail.ProductID;
                return product;
            }
            catch
            {
                throw;
            }
        }

        public List<CategoryDetail> GetCategoryDetails(ICategoryService _categoryService)
        {
            try
            {
                List<CategoryDetail> categories = _categoryService.GetAll().Where(x => x.IsActive).ToList();
                return categories;
            }
            catch
            {
                throw;
            }
        }

        public List<ModelDetail> GetModelDetails(IModelService _modelService)
        {
            try
            {
                List<ModelDetail> models = _modelService.GetAll().Where(x => x.IsActive).ToList();
                return models;
            }
            catch
            {
                throw;
            }
        }

        public List<SizeDetail> GetSizeDetails(ISizeService _sizeService, int categoryID)
        {
            try
            {
                List<SizeDetail> sizes = _sizeService.GetAll().Where(x => x.IsActive && x.CategoryID == categoryID).ToList();
                return sizes;
            }
            catch
            {
                throw;
            }
        }

        public List<SizeDetail> GetAllSizes(ISizeService _sizeService)
        {
            try
            {
                List<SizeDetail> sizes = _sizeService.GetAll().Where(x => x.IsActive).ToList();
                return sizes;
            }
            catch
            {
                throw;
            }
        }

        public List<ColorDetail> GetColors(IColorService _colorService)
        {
            try
            {
                List<ColorDetail> colors = _colorService.GetAll().Where(x => x.IsActive).ToList();
                return colors;
            }
            catch
            {
                throw;
            }
        }

        public List<TagDetail> GetTags(ITagService _tagService)
        {
            try
            {
                List<TagDetail> tags = _tagService.GetAll().Where(x => x.IsActive).ToList();
                return tags;
            }
            catch
            {
                throw;
            }
        }

        public List<PAList> GetPAList(IColorService colorService, ITagService tagService, ISizeService sizeService, ICategoryService categoryService,int count)
        {
            try
            {
                List<PAList> paList = new List<PAList>();
                List<ColorDetail> colors = this.GetColors(colorService);
                List<TagDetail> tags = this.GetTags(tagService);
                List<SizeDetail> sizes = this.GetAllSizes(sizeService);
                List<CategoryDetail> categories = this.GetCategoryDetails(categoryService);
                List<PADetail> pADetails = this._padService.GetAll();

                if (pADetails != null && pADetails.Count > 0)
                {
                    List<string> objectIDs = pADetails.Select(x => x._id).ToList();
                    List<PADTrans> pADTransacs = this._padTransService.GetAll().Where(x => objectIDs.Contains(x.PadID) && x.Count > count).ToList();

                    var joinedDetails = from padetail in pADetails
                                        join color in colors on padetail.ColorID equals color.ColorID
                                        join category in categories on padetail.CategoryID equals category.CategoryID
                                        join tag in tags on padetail.TagID equals tag.TagID
                                        join size in sizes on padetail.SizeID equals size.SizeID
                                        join padTrans in pADTransacs on padetail._id equals padTrans.PadID
                                        select new
                                        {
                                            PADetail = padetail,
                                            ColorName = color.ColorName,
                                            CategoryName = category.CategoryName,
                                            TagName = tag.TagName,
                                            Size = size.Size,
                                            Count = padTrans.Count
                                        };

                    paList = joinedDetails.Select(j =>
                       new PAList
                       {
                           _id = j.PADetail._id,
                           ProductID = j.PADetail.ProductID,
                           Category = j.CategoryName,
                           Size = j.Size,
                           Color = j.ColorName,
                           Image = j.PADetail.Image,
                           Tag = j.TagName,
                           CategoryID = j.PADetail.CategoryID,
                           ColorID = j.PADetail.ColorID,
                           SizeID = j.PADetail.SizeID,
                           TagID = j.PADetail.TagID,
                           Count = j.Count
                       }).ToList();
                }
                return paList.OrderBy(x => x.ProductID).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<SalePAList> GetSalePAList(IColorService colorService, ITagService tagService, ISizeService sizeService, ICategoryService categoryService, int count)
        {
            try
            {
                List<SalePAList> paList = new List<SalePAList>();
                List<ColorDetail> colors = this.GetColors(colorService);
                List<TagDetail> tags = this.GetTags(tagService);
                List<SizeDetail> sizes = this.GetAllSizes(sizeService);
                List<CategoryDetail> categories = this.GetCategoryDetails(categoryService);
                List<PADetail> pADetails = this._padService.GetAll();

                if (pADetails != null && pADetails.Count > 0)
                {
                    List<string> objectIDs = pADetails.Select(x => x._id).ToList();
                    List<PADTrans> pADTransacs = this._padTransService.GetAll().Where(x => objectIDs.Contains(x.PadID) && x.Count > count).ToList();

                    var joinedDetails = from padetail in pADetails
                                        join color in colors on padetail.ColorID equals color.ColorID
                                        join category in categories on padetail.CategoryID equals category.CategoryID
                                        join tag in tags on padetail.TagID equals tag.TagID
                                        join size in sizes on padetail.SizeID equals size.SizeID
                                        join padTrans in pADTransacs on padetail._id equals padTrans.PadID
                                        select new
                                        {
                                            PADetail = padetail,
                                            PADTransDetail = padTrans,
                                            ColorName = color.ColorName,
                                            CategoryName = category.CategoryName,
                                            TagName = tag.TagName,
                                            Size = size.Size,
                                            Count = padTrans.Count
                                        };

                    paList = joinedDetails.Select(j =>
                       new SalePAList
                       {
            
                           _id = j.PADetail._id,
                           ProductID = j.PADetail.ProductID,
                           Category = j.CategoryName,
                           Size = j.Size,
                           Color = j.ColorName,
                           Image = j.PADetail.Image,
                           Tag = j.TagName,
                           CategoryID = j.PADetail.CategoryID,
                           ColorID = j.PADetail.ColorID,
                           SizeID = j.PADetail.SizeID,
                           TagID = j.PADetail.TagID,
                           Count = j.Count,
                           MRP = j.PADTransDetail.MRP,
                           Discount = j.PADTransDetail.MRP - j.PADTransDetail.Price
                       }).ToList();
                }
                return paList.OrderBy(x => x.ProductID).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<PAImageList> GetPAListWithoutImage(IColorService colorService, ITagService tagService, ISizeService sizeService, ICategoryService categoryService)
        {
            try
            {
                List<PAList> list = this.GetPAList(colorService, tagService, sizeService, categoryService, 0).Where(x => x.Image == null || x.Image == string.Empty).ToList();
                List<PAImageList> imageList = new List<PAImageList>();
                if (list != null && list.Count > 0)
                {
                    foreach (PAList pAList in list)
                    {
                        PAImageList pAImage = new PAImageList();
                        pAImage.ProductID = pAList.ProductID;
                        pAImage.Category = pAList.Category;
                        pAImage.CategoryID = pAList.CategoryID;
                        pAImage.Color = pAList.Color;
                        pAImage.ColorID = pAList.ColorID;
                        imageList.Add(pAImage);
                    }

                    imageList = imageList.Distinct().ToList();
                }
                return imageList;
            }
            catch
            {
                throw;
            }
        }

        public bool UpdatePAImage(int categoryID, string productID, int colorID, IFormFile image, CollectionNames collectionNames)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return false;
                }

                var fileName = Path.GetFileName(image.FileName);

                var folderPath = collectionNames.ImageFolder;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                List<PADetail> paDetails = this._padService.GetAll().Where(x => x.CategoryID == categoryID && x.ColorID == colorID && x.ProductID == productID).ToList();
                foreach (PADetail paDetail in paDetails)
                {
                    paDetail.Image = fileName;
                    this._padService.UpdateImage(paDetail);
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
