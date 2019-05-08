using ShopEx01.Common;
using ShopEx01.Data.Infrastructure;
using ShopEx01.Data.Repositories;
using ShopEx01.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEx01.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Tag> GetTags();

    }
    public class CommonService : ICommonService
    {
        IFooterRepository _footerRepository;
        IUnitOfWork _unitOfWork;
        ISlideRepository _slideRepository;
        IBrandRepository _brandRepository;
        ITagRepository _tagRepository;
        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork,ISlideRepository slideRepository, IBrandRepository brandRepository, ITagRepository tagRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _slideRepository = slideRepository;
            _brandRepository = brandRepository;
            _tagRepository = tagRepository;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brandRepository.GetMulti(x => x.Status);
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x=>x.Status);
        }

        public IEnumerable<Tag> GetTags()
        {
            return _tagRepository.GetAll();
        }
    }
}
