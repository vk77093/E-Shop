using eshop.CoreBussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.SearchProductScreen
{
  public  interface ISearchProduct
    {
        public IEnumerable<Product> Execute(string filter = null);
        
    }
}
