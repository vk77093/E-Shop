using eshop.CoreBussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.UI
{
  public  interface IShoppingCart
    {
        public Task<Order> GetOrder();
        public Task<Order> AddProduct(Product product);
        public Task<Order> UpdateQuantity(int id, int qty);
        public Task<Order> UpdateOrder(Order order);
        public Task<Order> DeleteOrder(int id);
        public Task<Order> PlaceOrder();
        public Task EmptyOrder();
    }
}
