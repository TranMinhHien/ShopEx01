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
    [RoutePrefix("api/slide")]
    public class SlideController : ApiControllerBase
    {
        #region Initialize
        private ISlideService _slideService;

        public SlideController(IErrorService errorService, ISlideService slideService)
            : base(errorService)
        {
            this._slideService = slideService;
        }

        #endregion

        //[Route("getallparents")]
        //[HttpGet]
        //public HttpResponseMessage GetAll(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _slideService.GetAll();

        //        var responseData = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(model);

        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        return response;
        //    });
        //}
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _slideService.GetById(id);

                var responseData = Mapper.Map<Slide, SlideViewModel>(model);

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
                var model = _slideService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(query);

                var paginationSet = new PaginationSet<SlideViewModel>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, SlideViewModel slideModel)
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
                    var newSlide = new Slide();
                    newSlide.UpdateSlide(slideModel);
                    newSlide.CreatedDate = DateTime.Now;
                    _slideService.Add(newSlide);
                    _slideService.Save();

                    var responseData = Mapper.Map<Slide, SlideViewModel>(newSlide);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, SlideViewModel slideModel)
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
                    var dbSlide = _slideService.GetById(slideModel.ID);

                    dbSlide.UpdateSlide(slideModel);
                    dbSlide.UpdatedDate = DateTime.Now;

                    _slideService.Update(dbSlide);
                    _slideService.Save();

                    var responseData = Mapper.Map<Slide, SlideViewModel>(dbSlide);
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
                    var oldSlide = _slideService.Delete(id);
                    _slideService.Save();

                    var responseData = Mapper.Map<Slide, SlideViewModel>(oldSlide);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedSlide)
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
                    var listSlide = new JavaScriptSerializer().Deserialize<List<int>>(checkedSlide);
                    foreach (var item in listSlide)
                    {
                        _slideService.Delete(item);
                    }

                    _slideService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listSlide.Count);
                }

                return response;
            });
        }
    }
}
