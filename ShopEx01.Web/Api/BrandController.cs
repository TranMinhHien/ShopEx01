using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopEx01.Model.Models;
using ShopEx01.Service;
using ShopEx01.Web.Infrastructure.Core;
using ShopEx01.Web.Models;
using ShopEx01.Web.Infrastructure.Extensions;
using AutoMapper;
using System.Web.Script.Serialization;

namespace ShopEx01.Web.Api
{
    [RoutePrefix("api/brand")]
    public class BrandController : ApiControllerBase
    {
        #region Initialize
        private IBrandService _brandService;

        public BrandController(IErrorService errorService, IBrandService brandService)
            : base(errorService)
        {
            this._brandService = brandService;
        }

        #endregion

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _brandService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _brandService.GetById(id);

                var responseData = Mapper.Map<Brand, BrandViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _brandService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(query);

                var paginationSet = new PaginationSet<BrandViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, BrandViewModel brandModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newBrand = new Brand();
                    newBrand.UpdateBrand(brandModel);
                    newBrand.CreatedDate = DateTime.Now;
                    _brandService.Add(newBrand);
                    _brandService.Save();

                    var responseData = Mapper.Map<Brand, BrandViewModel>(newBrand);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, BrandViewModel brandModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbBrand = _brandService.GetById(brandModel.ID);

                    dbBrand.UpdateBrand(brandModel);
                    dbBrand.UpdatedDate = DateTime.Now;

                    _brandService.Update(dbBrand);
                    _brandService.Save();

                    var responseData = Mapper.Map<Brand, BrandViewModel>(dbBrand);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldBrand = _brandService.Delete(id);
                    _brandService.Save();

                    var responseData = Mapper.Map<Brand, BrandViewModel>(oldBrand);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedBrand)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listBrand = new JavaScriptSerializer().Deserialize<List<int>>(checkedBrand);
                    foreach (var item in listBrand)
                    {
                        _brandService.Delete(item);
                    }

                    _brandService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listBrand.Count);
                }

                return response;
            });
        }
    }
}

