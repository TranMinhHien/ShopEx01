using ShopEx01.Common.ViewModels;
using ShopEx01.Data.Repositories;
using System.Collections.Generic;

namespace ShopEx01.Service
{
    public interface IStatisticService
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);

    }
    public class StatisticService : IStatisticService
    {
        IOrderRepository _orderRepository;
        public StatisticService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            return _orderRepository.GetRevenueStatistic(fromDate, toDate);
        }
    }
}
