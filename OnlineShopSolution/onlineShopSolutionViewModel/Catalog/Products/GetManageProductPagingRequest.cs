﻿using onlineShopSolution.ViewModel.Common;
using System.Collections.Generic;

namespace onlineShopSolution.ViewModel.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
       // public int? CategoryId { get; set; }
    }
}
