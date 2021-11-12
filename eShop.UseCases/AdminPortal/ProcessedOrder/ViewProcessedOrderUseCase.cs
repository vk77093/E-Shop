using eshop.CoreBussiness.Models;
using eShop.UseCases.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.ProcessedOrder
{
   public class ViewProcessedOrderUseCase
    {
        private readonly IOrderRespository orderRepository;

        public ViewProcessedOrderUseCase(IOrderRespository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IEnumerable<Order> ExecuteViewProcessedOrder()
        {
            return orderRepository.GetProcessedOrders();
        }
    }
}
