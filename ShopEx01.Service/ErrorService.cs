using ShopEx01.Data.Infrastructure;
using ShopEx01.Data.Repositories;
using ShopEx01.Model.Models;

namespace ShopEx01.Service
{
    public interface IErrorService
    {
        Error Create(Error error);
        void Save();
    }
    public class ErrorService: IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;
        public ErrorService(IErrorRepository errorRepository,IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }
        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
