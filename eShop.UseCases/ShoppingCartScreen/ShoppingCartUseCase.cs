using eshop.CoreBussiness.Models;
using eShop.UseCases.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class ShoppingCartUseCase : IShoppingCartUseCase
    {
        private readonly IShoppingCart shoppingCart;

        public ShoppingCartUseCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        public Task<Order> Execute()
        {
            return shoppingCart.GetOrder();
        }
    }
}
