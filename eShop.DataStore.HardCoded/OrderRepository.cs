using eshop.CoreBussiness.Models;
using eShop.UseCases.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRespository
    {
        private Dictionary<int, Order> DicOrders;
        public OrderRepository()
        {
            DicOrders = new Dictionary<int, Order>();
        }
        public int CreateOrder(Order order)
        {
            order.OrderId = DicOrders.Count + 1;
            //order.UniqueId = Guid.NewGuid().ToString();
            DicOrders.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public IEnumerable<Order> GetLineItemsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            return DicOrders[id];
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            foreach(var order in DicOrders)
            {
                if (order.Value.UniqueId == uniqueId) return order.Value;

                return null;
            }
            return null;
        }

        public IEnumerable<Order> GetOrders()
        {
            return DicOrders.Values;
        }

        public IEnumerable<Order> GetOustandingOrders()
        {
            var allorders = (IEnumerable<Order>)DicOrders.Values;
            return allorders.Where(x => x.DateProcessed.HasValue == false);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var allorders = (IEnumerable<Order>)DicOrders.Values;
            return allorders.Where(x => x.DateProcessed.HasValue);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null || !order.OrderId.HasValue)
                return;
            var ord = DicOrders[order.OrderId.Value];
            if (ord == null) return;
            DicOrders[order.OrderId.Value] = order;
        }
    }
}
