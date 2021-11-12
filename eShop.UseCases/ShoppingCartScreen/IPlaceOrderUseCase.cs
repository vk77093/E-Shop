using eshop.CoreBussiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public interface IPlaceOrderUseCase
    {
        Task<string> PlaceOrderExecute(Order order);
    }
}