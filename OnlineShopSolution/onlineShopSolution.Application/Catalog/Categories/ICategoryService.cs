using onlineShopSolution.Application.Catalog.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll();
        Task<int> Update(EditViewModel edit);
        Task<int> Delete(int productId);
    }
}
