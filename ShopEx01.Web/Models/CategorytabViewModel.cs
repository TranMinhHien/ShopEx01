using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopEx01.Web.Models
{
    public class CategorytabViewModel
    {
        public IEnumerable<TagViewModel> Tags { set; get; }
        public IEnumerable<ProductTagViewModel> ProductTags { set; get; }
        public IEnumerable<ProductViewModel> Products { set; get; }
    }
}