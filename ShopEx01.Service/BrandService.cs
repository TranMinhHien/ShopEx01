using ShopEx01.Data.Infrastructure;
using ShopEx01.Data.Repositories;
using ShopEx01.Model.Models;
using System.Collections.Generic;

namespace ShopEx01.Service
{
    public interface IBrandService
    {
        Brand Add(Brand Brand);

        void Update(Brand Brand);

        Brand Delete(int id);

        IEnumerable<Brand> GetAll();

        IEnumerable<Brand> GetAll(string keyword);

        Brand GetById(int id);

        void Save();
    }
    public class BrandService:IBrandService
    {
        private IBrandRepository _BrandRepository;
        private IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository BrandRepository, IUnitOfWork unitOfWork)
        {
            this._BrandRepository = BrandRepository;
            this._unitOfWork = unitOfWork;
        }

        public Brand Add(Brand Brand)
        {
            return _BrandRepository.Add(Brand);
        }

        public Brand Delete(int id)
        {
            return _BrandRepository.Delete(id);
        }

        public IEnumerable<Brand> GetAll()
        {
            return _BrandRepository.GetAll();
        }

        public IEnumerable<Brand> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _BrandRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _BrandRepository.GetAll();

        }

        public Brand GetById(int id)
        {
            return _BrandRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Brand Brand)
        {
            _BrandRepository.Update(Brand);
        }
    }
}
