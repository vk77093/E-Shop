using eShop.UseCases.PluginInterface.DataStore;
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

        public AddProductToUseCase(IProductRepository productRepository, IShoppingCart shoppingCart)
        {
            this.productRepository = productRepository;
            this.shoppingCart = shoppingCart;
        }
        public async void Execute(int productId)
        {
            var product = productRepository.GetProduct(productId);
            await shoppingCart.AddProduct(product);
        }
    }
}
