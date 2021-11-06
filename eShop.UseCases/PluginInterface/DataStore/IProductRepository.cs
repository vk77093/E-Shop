using eshop.CoreBussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterface.DataStore
{
  public  interface IProductRepository
    {
        public IEnumerable<Product> GetProducts(string filter);
        public Product GetProduct(int id);
    }
}
