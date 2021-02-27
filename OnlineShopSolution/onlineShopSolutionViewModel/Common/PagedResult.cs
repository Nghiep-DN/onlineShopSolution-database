﻿using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Common
{
    
    public class PagedResult<T>:PagedResultBase
    {
        public List<T> Items { set; get; }
        public string Message { set; get; }
        public int ResultCode { set; get; }
    }
}
