namespace ShopEx01.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopEx01DbContext dbContext;
        public ShopEx01DbContext Init()
        {
            return dbContext ?? (dbContext = new ShopEx01DbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        /*
        public ShopEx01DbContext Init()
        {
            throw new NotImplementedException();
        }
        */
    }
}
