﻿using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.System.Users
{
    public class GetUserPagingRequest :PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
