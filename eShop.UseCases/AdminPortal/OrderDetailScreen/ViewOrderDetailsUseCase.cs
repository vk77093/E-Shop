using eshop.CoreBussiness.Models;
using eShop.UseCases.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.OrderDetailScreen
{
    public class ViewOrderDetailsUseCase : IViewOrderDetailsUseCase
    {
        private readonly IOrderRespository orderRepository;

        public ViewOrderDetailsUseCase(IOrderRespository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order ExecuteVieworder(int orderId)
        {
            return orderRepository.GetOrder(orderId);
        }
    }
}
