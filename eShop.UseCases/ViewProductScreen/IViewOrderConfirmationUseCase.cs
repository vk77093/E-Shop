using eshop.CoreBussiness.Models;

namespace eShop.UseCases.ViewProductScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order ViewOrderExecute(string uniqueId);
    }
}