using eshop.CoreBussiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.ViewProductScreen
{
    public interface IDeleteProductUseCase
    {
        Task<Order> DeleteExecute(int proId);
    }
}