using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterface.StateStore
{
  public  interface IShoppingCartSateStore:IStateStore
    {
        Task<int> GetItemCount();
        void UpdateLineItemsCount();
    }
}
