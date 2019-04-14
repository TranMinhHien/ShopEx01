using System;

namespace ShopEx01.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopEx01DbContext Init();
    }
}
