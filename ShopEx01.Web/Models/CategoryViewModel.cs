using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopEx01.Web.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<ProductCategoryViewModel> ProductCategory { set; get; }
        public IEnumerable<BrandViewModel> Brands { set; get; }
    }
}