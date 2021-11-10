using eshop.CoreBussiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.ViewProductScreen
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> UpdateExecute(int proId, int qty);
    }
}