using System;

namespace onlineShopSolution.ViewModel.Catalog.Products
{
    /// <summary>
    /// Model dùng chung
    /// </summary>
    public class ProductViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details {  get; set; }
        public string SeoDesciption { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
    }
}
