﻿using ShopEx01.Service;
using ShopEx01.Web.Infrastructure.Core;
using System.Web.Http;

namespace ShopEx01.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, Member. ";
        }
    }
}
