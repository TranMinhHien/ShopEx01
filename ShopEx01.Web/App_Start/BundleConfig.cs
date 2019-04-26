using System.Web;
using System.Web.Optimization;

namespace ShopEx01.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                "~/Assets/client/js/jquery.min.js"
            ));

            //bundles.Add(new ScriptBundle("~/js/jqueryIndex").Include(
            //    "~/Assets/admin/libs/jquery/dist/jquery.js"
            //));

            bundles.Add(new ScriptBundle("~/js/plugins").Include(                
                "~/Assets/admin/libs/jqueri-ui/jquery-ui.min.js",
                "~/Assets/admin/libs/mustache/mustache.js",
                "~/Assets/admin/libs/jquery-validation/dist/jquery.validate.js",
                "~/Assets/admin/libs/jquery-validation/dist/additional-methods.min.js",
                "~/Assets/client/js/common.js"
            ));

            bundles.Add(new ScriptBundle("~/js/pluginsIndex").Include(
                "~/Assets/admin/libs/bootstrap/dist/js/bootstrap.js",
                "~/Assets/admin/libs/slimScroll/jquery.slimscroll.js",
                "~/Assets/admin/libs/fastclick/lib/fastclick.js",
                "~/Assets/admin/js/app.min.js",

                "~/Assets/admin/libs/angular/angular.js",
                "~/Assets/admin/libs/angular-ui-router/release/angular-ui-router.js",
                "~/Assets/admin/libs/angular-sanitize/angular-sanitize.min.js",
                "~/Assets/admin/libs/toastr/toastr.js",
                "~/Assets/admin/libs/bootbox/bootbox.js",
                "~/Assets/admin/libs/ckeditor/ckeditor.js",
                "~/Assets/admin/libs/ckfinder/ckfinder.js",
                "~/Assets/admin/libs/ngBootbox/ngBootbox.js",
                "~/Assets/admin/libs/ng-ckeditor/ng-ckeditor.js",
                "~/Assets/admin/libs/angular-local-storage/dist/angular-local-storage.js",
                "~/Assets/admin/libs/angular-loading-bar/build/loading-bar.js",
                "~/Assets/admin/libs/checklist-model/checklist-model.js",
                "~/Assets/admin/libs/angular-ui-select/dist/select.min.js",
                "~/app/shared/modules/shopex01.common.js",
                "~/app/shared/filters/statusFilter.js",
                ///////////////////////////////////
                "~/app/shared/services/apiService.js",
                "~/app/shared/directives/pagerDirective.js",
                "~/app/shared/directives/asDateDirective.js",
                "~/app/shared/services/notificationService.js",
                "~/app/shared/services/authData.js",
                "~/app/shared/services/authenticationService.js",
                "~/app/shared/services/loginService.js",
                "~/app/shared/services/commonService.js",
                "~/app/components/products/products.module.js",
                "~/app/components/product_categories/productCategories.module.js",
                "~/app/components/application_groups/applicationGroups.module.js",
                "~/app/components/application_roles/applicationRoles.module.js",
                "~/app/components/application_users/applicationUsers.module.js",
                "~/app/app.js",
                "~/app/components/home/rootController.js",
                "~/app/components/product_categories/productCategoryListController.js",
                "~/app/components/product_categories/productCategoryAddController.js",
                "~/app/components/products/productAddController.js",
                "~/app/components/product_categories/productCategoryEditController.js",
                "~/app/components/products/productListController.js",
                "~/app/components/home/homeController.js",
                "~/app/components/products/productEditController.js",
                "~/app/components/login/loginController.js",

                "~/app/components/application_groups/applicationGroupListController.js",
                "~/app/components/application_groups/applicationGroupEditController.js",
                "~/app/components/application_groups/applicationGroupAddController.js",

                "~/app/components/application_roles/applicationRoleAddController.js",
                "~/app/components/application_roles/applicationRoleEditController.js",
                "~/app/components/application_roles/applicationRoleListController.js",

                "~/app/components/application_users/applicationUserAddController.js",
                "~/app/components/application_users/applicationUserEditController.js",
                "~/app/components/application_users/applicationUserListController.js"
            ));

            bundles.Add(new StyleBundle("~/css/base")
                .Include("~/Assets/client/css/bootstrap.css",new CssRewriteUrlTransform())
                .Include("~/Assets/client/font-awesome-4.6.3/css/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/Assets/admin/libs/jqueri-ui/themes/smoothness/jquery-ui.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/custom.css", new CssRewriteUrlTransform())
                );

            bundles.Add(new StyleBundle("~/css/baseIndex")
               .Include("~/Assets/admin/libs/toastr/toastr.css", new CssRewriteUrlTransform())
               .Include("~/Assets/admin/libs/angular-loading-bar/build/loading-bar.css", new CssRewriteUrlTransform())
               .Include("~/Assets/admin/libs/angular-ui-select/dist/select.min.css", new CssRewriteUrlTransform())
               .Include("~/Assets/admin/css/custom.css", new CssRewriteUrlTransform())
               .Include("~/Assets/admin/css/skins/_all-skins.min.css", new CssRewriteUrlTransform())
               .Include("~/Assets/admin/libs/bootstrap/dist/css/bootstrap.min.css", new CssRewriteUrlTransform())
               );

            BundleTable.EnableOptimizations = true;
        }
    }
}
