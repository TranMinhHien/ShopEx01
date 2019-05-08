﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopEx01.Web.Models
{
    public class FooterViewModel
    {
        public IEnumerable<TagViewModel> Tags { set; get; }
        public IEnumerable<ProductCategoryViewModel> ProductCategory { set; get; }
    }

}