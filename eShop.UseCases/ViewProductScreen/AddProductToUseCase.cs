using eShop.UseCases.PluginInterface.DataStore;
using eShop.UseCases.PluginInterface.StateStore;
using eShop.UseCases.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ViewProductScreen
{
    public class AddProductToUseCase : IAddProductToUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartSateStore shoppingCartSateStore;

        public AddProductToUseCase(IProductRepository productRepository, 
            IShoppingCart shoppingCart,IShoppingCartSateStore shoppingCartSateStore)
        {
            this.productRepository = productRepository;
            this.shoppingCart = shoppingCart;
            this.shoppingCartSateStore = shoppingCartSateStore;
        }
        public async void Execute(int productId)
        {
            var product = productRepository.GetProduct(productId);
            await shoppingCart.AddProduct(product);
            shoppingCartSateStore.UpdateLineItemsCount();
        }
    }
}
