using eshop.CoreBussiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.AdminPortal.ProcessedOrder
{
    public interface IViewProcessedOrderUseCase
    {
        IEnumerable<Order> ExecuteViewProcessedOrder();
    }
}