using eShop.UseCases.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterface.StateStore.Implmentaion
{
    public class ShoppingCartStateStore : StateStoreBase, IShoppingCartSateStore
    {
        private readonly IShoppingCart shoppingCart;

        public ShoppingCartStateStore(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        public async Task<int> GetItemCount()
        {
            var order = await shoppingCart.GetOrder();
            if (order != null && order.LineItems != null && order.LineItems.Count > 0)
                return order.LineItems.Count;
            return 0;
        }

        public void UpdateLineItemsCount()
        {
            base.BroadCastSateChange();
        }

        public void UpdateProductQuantity()
        {
            base.BroadCastSateChange();
        }
    }
}
