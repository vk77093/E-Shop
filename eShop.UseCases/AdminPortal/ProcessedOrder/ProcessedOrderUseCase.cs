using eshop.CoreBussiness.Service;
using eShop.UseCases.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.ProcessedOrder
{
    public class ProcessedOrderUseCase : IProcessedOrderUseCase
    {
        private readonly IOrderRespository orderRepostiory;
        private readonly IOrderService orderService;

        public ProcessedOrderUseCase(IOrderRespository orderRepostiory, IOrderService orderService)
        {
            this.orderRepostiory = orderRepostiory;
            this.orderService = orderService;
        }
        public bool ExecuteProcessedOrder(int orderid, string adminUserName)
        {
            var order = orderRepostiory.GetOrder(orderid);
            order.AdminUser = adminUserName;
            order.DateProcessed = DateTime.Now;
            if (orderService.ValidateProcessOrder(order))
            {
                orderRepostiory.UpdateOrder(order);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
