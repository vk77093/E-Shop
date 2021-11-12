using eshop.CoreBussiness.Models;
using eShop.UseCases.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.OutstandingOrder
{
    public class ViewOutStadingOrderUseCase : IViewOutStadingOrderUseCase
    {
        private readonly IOrderRespository orderRepostiory;

        public ViewOutStadingOrderUseCase(IOrderRespository orderRepostiory)
        {
            this.orderRepostiory = orderRepostiory;
        }
        public IEnumerable<Order> Execute()
        {
            return orderRepostiory.GetOustandingOrders();
        }

    }
}
