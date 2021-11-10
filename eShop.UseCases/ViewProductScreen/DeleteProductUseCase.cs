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
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartSateStore shoppingCartSateStore;

        public DeleteProductUseCase(IShoppingCart shoppingCart,
            IShoppingCartSateStore shoppingCartSateStore)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCartSateStore = shoppingCartSateStore;
        }
        public async Task<Order> DeleteExecute(int proId)
        {
            var orderId = await this.shoppingCart.DeleteOrder(proId);
            this.shoppingCartSateStore.UpdateLineItemsCount();
            return orderId;
        }
    }
}
