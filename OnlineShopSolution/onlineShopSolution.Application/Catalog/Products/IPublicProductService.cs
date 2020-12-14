using onlineShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Application.Catalog.Products.Dtos
{
    public interface IPublicProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedViewModel<ProductViewModel> GetAllByCategoryId(int categoryId,int pageIndex,int pageSize);
    }
}
