﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Entities.Contracts
{
    public class PagedResult<T>
    {
        public IList<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
