using AutoMapper;
using ShopEx01.Model.Models;
using ShopEx01.Service;
using ShopEx01.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopEx01.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService,
            IProductService productService,
            ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _commonService = commonService;
            _productService = productService;
        }

        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;

            var lastestProductModel = _productService.GetLastest(6);
            var topSaleProductModel = _productService.GetHotProduct(6);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            homeViewModel.LastestProducts = lastestProductViewModel;
            homeViewModel.TopSaleProducts = topSaleProductViewModel;
            return View(homeViewModel);
        }

        
        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public ActionResult Footer()
        {
            //var model = _productCategoryService.GetAll();
            //var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            //return PartialView(listProductCategoryViewModel);

            var tagModel = _commonService.GetTags();
            var tagView = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tagModel);
            var footerViewModel = new FooterViewModel();
            footerViewModel.Tags = tagView;

            var productCategoryModel = _productCategoryService.GetProductCategory();
            var productCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategoryModel);
            footerViewModel.ProductCategory = productCategoryViewModel;
            return View(footerViewModel);
        }
        
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Category()
        {
            var brandModel = _commonService.GetBrands();
            var brandView = Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(brandModel);
            var categoryViewModel = new CategoryViewModel();
            categoryViewModel.Brands = brandView;

            var productCategoryModel = _productCategoryService.GetProductCategory();
            var productCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategoryModel);
            categoryViewModel.ProductCategory = productCategoryViewModel;
            return View(categoryViewModel);
        }
    }
}