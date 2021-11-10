using eshop.CoreBussiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public interface IShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}