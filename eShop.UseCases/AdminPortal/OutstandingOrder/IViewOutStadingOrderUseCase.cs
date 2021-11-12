using eshop.CoreBussiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.AdminPortal.OutstandingOrder
{
    public interface IViewOutStadingOrderUseCase
    {
        IEnumerable<Order> Execute();
    }
}