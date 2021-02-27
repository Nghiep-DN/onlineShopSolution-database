using onlineShopSolution.Data.Entities;
using onlineShopSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using onlineShopSolution.ViewModel.Catalog.Products;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using onlineShopSolution.Application.Common;
using onlineShopSolution.ViewModel.Catalog.ProductImages;
using onlineShopSolution.ViewModel.Common;

namespace onlineShopSolution.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Biến nội bộ
        /// </summary>
        private readonly OnlineShopDbContext _context;
        private readonly IStorageService _storageService;

        /// <summary>
        /// OnlineShopDbContext phải reference từ tầng Data vào tầng này để có thể sử dụng
        /// </summary>
        /// <param name="context"></param>
        public ProductService(OnlineShopDbContext context,IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        #region image

        public async Task<int> AddImages(int productId,ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                ProductId = productId,
                SortOrder = request.SortOrder,
                DateCreated = DateTime.Now,
                Caption = request.Caption

            };
            if(request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;

        }
      

        public async Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            var listImage = await _context.ProductImages.Where(x => x.ProductId == productId).Select(i => new ProductImageViewModel()
            {
                Caption = i.Caption,
                DateCreated = i.DateCreated,
                FileSize = i.FileSize,
                Id = i.Id,
                ImagePath = i.ImagePath,
                IsDefault = i.IsDefault,
                ProductId = i.ProductId,
                SortOrder = i.SortOrder
            }).ToListAsync();

            return listImage;
        }

        public async Task<int> RemoveImages(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new onlineShopNotFoundException($"Cannot find an image with id: {imageId}");
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }


        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (image == null)
                throw new onlineShopNotFoundException($"Cannot find an image with id: {imageId}");

            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }


        public async Task<int> UpdateImages(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new onlineShopNotFoundException($"Cannot find an image with id: {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Update(productImage);
            return await _context.SaveChangesAsync();

        }

        #endregion

        #region product

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Tạo mới Product bằng entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    //thêm dạng cha con này, id tự tăng, ProductId tự map
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description=request.Description,
                        Details= request.Details,
                        SeoDesciption=request.SeoDesciption,
                        SeoAlias=request.SeoAlias,
                        SeoTitle=request.SeoTitle,
                        LanguageId=request.LanguageId
                    }
                }
            };
            //save Image
            if(request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "thumbnail image",
                        DateCreated=DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath=await this.SaveFile(request.ThumbnailImage),
                        IsDefault=true,
                        SortOrder=1,
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;  

        }

        /// <summary>
        /// Xóa product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            { 
                //throw new onlineShopNotFoundException("Can not find product " + productId);
                throw new onlineShopNotFoundException($"Cannot find product with id: {productId}");
            }

            var images = _context.ProductImages.Where(p => p.ProductId == productId);
            foreach (var item in images)
            {
                await _storageService.DeleteFileAsync(item.ImagePath);
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }


        /// <summary>
        /// lấy ra các bản ghi, Search theo tên Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //lấy ra các bản ghi, Search theo tên product => JOIN với bảng Products để lấy trường Name

            //b1. select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.Name.Contains(request.Keyword)
                        select new { p, pt, pic };
            //b2. filter
            if (string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }

            //b3. paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    SeoDesciption = x.pt.SeoDesciption,
                    SeoAlias = x.pt.SeoAlias,
                    SeoTitle = x.pt.SeoTitle,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,

                }
            ).ToListAsync();

            //b4. select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageSize=request.pageSize,
                PageIndex=request.pageIndex,
                Message = "Success",
                ResultCode = 1
                
            };
            return pagedResult;
        }





        /// <summary>
        /// Update sản phẩm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if (product == null || productTranslations == null)
            {
                throw new onlineShopNotFoundException($"Cannot find product with id: {request.Id}");
            }
            productTranslations.Name = request.Name;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDesciption = request.SeoDesciption;
            productTranslations.SeoTitle = request.SeoTitle;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetById(int productId,string languageId)
        {
            var product = await _context.Products.FindAsync(productId);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageId == languageId);
            var productViewModel = new ProductViewModel()
            {
                Id=product.Id,
                Price=product.Price,
                OriginalPrice=product.OriginalPrice,
                Stock=product.Stock,
                ViewCount=product.ViewCount,
                DateCreated = product.DateCreated,
                Description=productTranslation !=null ?productTranslation.Description:null,
                LanguageId=productTranslation.LanguageId,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                SeoDesciption = productTranslation != null ? productTranslation.SeoDesciption : null,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,

            };
           
            return productViewModel;

        }



        /// <summary>
        /// Cập nhật giá 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="newPrice"></param>
        /// <returns></returns>
        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new onlineShopNotFoundException($"Cannot find a product with id: {productId}");

            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0; // > 0 true

        }

        /// <summary>
        /// cập nhật tồn kho
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="addedQuantity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new onlineShopNotFoundException($"Cannot find product with id: {productId}");

            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0; // > 0 true
        }
        #endregion
        #region private
        /// <summary>
        /// Lưu file ảnh
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }



        #endregion

        public async Task<PagedResult<ProductViewModel>> GetAll(string languageId)
        {
            var output = new PagedResult<ProductViewModel>();

            if (string.IsNullOrEmpty(languageId))
            {
                output.Message = "languageId khong duoc de trong !!!";
                output.ResultCode = 0;
                return output;
            }


            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };

            var data = await query
               .Select(x => new ProductViewModel()
               {
                   Id = x.p.Id,
                   Name = x.pt.Name,
                   DateCreated = x.p.DateCreated,
                   Description = x.pt.Description,
                   Details = x.pt.Details,
                   SeoDesciption = x.pt.SeoDesciption,
                   SeoAlias = x.pt.SeoAlias,
                   SeoTitle = x.pt.SeoTitle,
                   LanguageId = x.pt.LanguageId,
                   OriginalPrice = x.p.OriginalPrice,
                   Price = x.p.Price,
                   Stock = x.p.Stock,
                   ViewCount = x.p.ViewCount,

               }
           ).ToListAsync();


            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = data.Count,
                Items = data,
                Message = "Success!",
                ResultCode = 1

            };
            return pagedResult;

            //return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            var output = new PagedResult<ProductViewModel>();
            //b1. select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == request.LanguageId
                        select new { p, pt, pic };
            //b2. filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            else
            {

                output.Message = "CategoryId ko duoc de trong!!!";
                output.ResultCode = 0;
                return output;
            }
            //var user = (_context.Categories.Find(x => x. == request.CategoryId)).FirstOrDefault();
            //if (user == null)
            //{
            //    output.ResultCode = 0;
            //    output.Message = "Invalid User!";
            //    return output;
            //}

            if (string.IsNullOrEmpty(request.LanguageId))
            {

                output.Message = "LanguageId ko duoc de trong!!!";
                output.ResultCode = 0;
                return output;
            }

            //b3. paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    SeoDesciption = x.pt.SeoDesciption,
                    SeoAlias = x.pt.SeoAlias,
                    SeoTitle = x.pt.SeoTitle,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,

                }
            ).ToListAsync();

            //b4. select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageSize = request.pageSize,
                PageIndex = request.pageIndex,
                Message = "Success!",
                ResultCode = 1

            };
            return pagedResult;
        }
    }



}

