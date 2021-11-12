using eshop.CoreBussiness.Models;
using eshop.CoreBussiness.Service;
using eShop.UseCases.PluginInterface.DataStore;
using eShop.UseCases.PluginInterface.StateStore;
using eShop.UseCases.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{


    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IOrderService orderService;
        private readonly IOrderRespository orderRepository;
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartSateStore shoppingCartStateStore;

        public PlaceOrderUseCase(IOrderService orderService, IOrderRespository orderRepository,
            IShoppingCart shoppingCart, IShoppingCartSateStore shoppingCartStateStore)
        {
            this.orderService = orderService;
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
        }
        public async Task<string> PlaceOrderExecute(Order order)
        {

            await shoppingCart.UpdateOrder(order);
            if (orderService.ValidateCreateOrder(order))
            {
                order.DatePlaced = DateTime.Now;
                order.UniqueId = Guid.NewGuid().ToString();
                int orderId = orderRepository.CreateOrder(order);
                order = orderRepository.GetOrder(orderId);

                await shoppingCart.EmptyOrder();
                this.shoppingCartStateStore.UpdateLineItemsCount();

                return order.UniqueId;
            }

            return null;
        }
    }

}
