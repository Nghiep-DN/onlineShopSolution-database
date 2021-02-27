using Microsoft.AspNetCore.Http;
using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Catalog.ProductImages;
using onlineShopSolution.ViewModel.Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.Catalog.Products
{
    public interface IProductService
    {
        /// <summary>
        /// Tạo mới sản phẩm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> Create(ProductCreateRequest request);

        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> Update(ProductUpdateRequest request);
        Task<ProductViewModel> GetById(int productId,string languageId);

        /// <summary>
        /// Cập nhật giá sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="newPrice"></param>
        /// <returns></returns>
        Task<bool> UpdatePrice(int productId, decimal newPrice);

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<int> Delete(int productId);
       
        Task<bool> UpdateStock(int productId,int addedQuantity);
     
        Task AddViewCount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        /// <summary>
        /// Thêm danh sách ảnh vào sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="formFiles"></param>
        /// <returns></returns>
        Task<int> AddImages(int productId, ProductImageCreateRequest request);
        Task<ProductImageViewModel> GetImageById(int imageId);

        /// <summary>
        /// Xóa ảnh
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        Task<int> RemoveImages(int imageId);

        /// <summary>
        /// Cập nhật thông tin ảnh
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="isDefault"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        Task<int> UpdateImages(int imageId,ProductImageUpdateRequest request);

        /// <summary>
        /// Lấy danh sách ảnh
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<List<ProductImageViewModel>> GetListImage(int productId);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //  PagedResult<ProductViewModel> GetAllByCategoryId(int categoryId,int pageIndex,int pageSize); thay bằng đối tượng cho dễ chỉnh sửa, ko truyền trực tiếp như này
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<PagedResult<ProductViewModel>> GetAll(string languageId);


    }
}
