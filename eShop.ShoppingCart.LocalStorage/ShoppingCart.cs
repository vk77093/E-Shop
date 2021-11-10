using eshop.CoreBussiness.Models;
using eShop.UseCases.PluginInterface.DataStore;
using eShop.UseCases.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IJSRuntime jSRuntime;
        private readonly IProductRepository productRepository;
        private const string cstrShoppingCart = "eShop.ShoppingCart";

        public ShoppingCart(IJSRuntime jSRuntime,IProductRepository productRepository)
        {
            this.jSRuntime = jSRuntime;
            this.productRepository = productRepository;
        }
        public async Task<Order> AddProduct(Product product)
        {
            var order = await GetOrders();
            order.AddProduct(product.Id, 1, product.Price);
            await SetOrder(order);
            return order;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var orderDel = await GetOrders();
            orderDel.RemoveProduct(id);
            await SetOrder(orderDel);
            return orderDel;
        }

        public Task EmptyOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrder()
        {
            var orderDetails = await GetOrders();
            return orderDetails;
        }

        public Task<Order> PlaceOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            await this.SetOrder(order);
            return order;
        }

        public async Task<Order> UpdateQuantity(int id, int qty)
        {
            var order = await GetOrders();
            if (qty < 0)
                return order;
            else if (qty == 0)
                return await DeleteOrder(id);

            var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId == id);
            if (lineItem != null) lineItem.Quantity = qty;
            await SetOrder(order);

            return order;

        }
       
        private async Task<Order> GetOrders()
        {
            Order order = null;
            var strOrder = await jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != "null")
            {
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            }
            else
            {
                order = new Order();
                await SetOrder(order);
            }
            foreach(var item in order.LineItems)
            {
                item.Product = productRepository.GetProduct(item.ProductId);
            }
            return order;
        }
        private async Task SetOrder(Order order)
        {
            // await jSRuntime.InvokeVoidAsync("localStorage.getItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}
