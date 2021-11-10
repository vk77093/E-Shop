using eshop.CoreBussiness.Models;
using eShop.UseCases.PluginInterface.StateStore;
using eShop.UseCases.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ViewProductScreen
{
    public class UpdateQuantityUseCase : IUpdateQuantityUseCase
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartSateStore shoppingCartStateStore;

        public UpdateQuantityUseCase(IShoppingCart shoppingCart,
            IShoppingCartSateStore shoppingCartStateStore)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
        }
        public async Task<Order> UpdateExecute(int proId, int qty)
        {
            var order = await shoppingCart.UpdateQuantity(proId, qty);
            shoppingCartStateStore.UpdateProductQuantity();
            return order;

        }
    }
}
