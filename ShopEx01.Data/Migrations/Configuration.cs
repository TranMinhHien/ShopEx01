namespace ShopEx01.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopEx01.Data.ShopEx01DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopEx01.Data.ShopEx01DbContext context)
        {
            CreateProductCategorySample(context);
            CreateUser(context);
            CreateSlide(context);
            CreateBrand(context);
            CreatePage(context);
            CreateContactDetail(context);
            //This method will be called after migrating to the latest version.
        }

        private void CreateUser(ShopEx01DbContext context)
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopEx01DbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopEx01DbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "shop",
            //    Email = "shop.international@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Technology Shop"

            //};

            //manager.Create(user, "123456");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("shop.international@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(ShopEx01.Data.ShopEx01DbContext context)
        {
            //if (context.ProductCategories.Count() == 0)
            //{
            //    List<ProductCategory> listProductCategory = new List<ProductCategory>()
            //{
            //    new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
            //     new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
            //      new ProductCategory() { Name="Gia Dụng",Alias="do-gia-dung",Status=true },
            //       new ProductCategory() { Name="Mỹ Phẩm",Alias="my-pham",Status=true },
            //       new ProductCategory() { Name="aksdffk",Alias="my-pham1",Status=true }
            //};
            //    context.ProductCategories.AddRange(listProductCategory);
            //    context.SaveChanges();
            //}
        }

        private void CreateSlide(ShopEx01DbContext context)
        {
            //if (context.Slides.Count() == 0)
            //{
            //    List<Slide> listSlide = new List<Slide>()
            //    {
            //        new Slide() {Name="Slide1", DisplayOrder=1, Status=true, Url="#", Image="Assets/client/images/home/girl1.jpg"},
            //        new Slide() {Name="Slide2", DisplayOrder=2, Status=true, Url="#", Image="Assets/client/images/home/girl2.jpg"},
            //        new Slide() {Name="Slide3", DisplayOrder=3, Status=true, Url="#", Image="Assets/client/images/home/girl3.jpg"}
            //    };
            //    context.Slides.AddRange(listSlide);
            //    context.SaveChanges();
            //}
        }

        private void CreateBrand(ShopEx01DbContext context)
        {
            //if (context.Brands.Count() == 0)
            //{
            //    List<Brand> listBrand = new List<Brand>()
            //    {
            //        new Brand() {Name="Dell", Status=true, Alias="dell"},
            //        new Brand() {Name="HP", Status=true, Alias="hp"},
            //        new Brand() {Name="ASUS", Status=true, Alias="asus"}
            //    };
            //    context.Brands.AddRange(listBrand);
            //    context.SaveChanges();
            //}
        }

        private void CreatePage(ShopEx01DbContext context)
        {
            //if (context.Pages.Count() == 0)
            //{
            //    try
            //    {
            //        var page = new Page()
            //        {
            //            Name = "Giới thiệu",
            //            Alias = "gioi-thieu",
            //            Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium ",
            //            Status = true

            //        };
            //        context.Pages.Add(page);
            //        context.SaveChanges();
            //    }
            //    catch (DbEntityValidationException ex)
            //    {
            //        foreach (var eve in ex.EntityValidationErrors)
            //        {
            //            Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
            //            foreach (var ve in eve.ValidationErrors)
            //            {
            //                Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
            //            }
            //        }
            //    }

            //}
        }

        private void CreateContactDetail(ShopEx01DbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new ShopEx01.Model.Models.ContactDetail()
                    {
                        Name = "ShopEx01",
                        Address = "Làng ĐH, Q.Thủ Đức",
                        Email = "shopex01@gmail.com",
                        Lat = 10.873629,
                        Lng = 106.799634,
                        Phone = "0985617988",
                        Website = "http://shopex01vn",
                        Other = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }
    }
}