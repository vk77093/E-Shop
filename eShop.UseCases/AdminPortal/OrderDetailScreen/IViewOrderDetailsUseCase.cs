using eshop.CoreBussiness.Models;

namespace eShop.UseCases.AdminPortal.OrderDetailScreen
{
    public interface IViewOrderDetailsUseCase
    {
        Order ExecuteVieworder(int orderId);
    }
}