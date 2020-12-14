using onlineShopSolution.Application.Catalog.Categories.Dtos;
using onlineShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService

    {
        private readonly OnlineShopDbContext _context;
        public CategoryService(OnlineShopDbContext context)
        {
            context = _context;
        }
        public async Task<int> Delete(int productId)
        {
            var del = _context.Categories.Find(productId);
            _context.Categories.Remove(del);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(EditViewModel edit)
        {
            throw new NotImplementedException();
        }
    }
}
