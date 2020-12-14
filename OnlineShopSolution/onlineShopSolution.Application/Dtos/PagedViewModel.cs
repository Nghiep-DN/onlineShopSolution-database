using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Application.Dtos
{
    
    public class PagedViewModel<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }
    }
}
