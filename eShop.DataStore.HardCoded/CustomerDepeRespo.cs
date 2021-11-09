using eshop.CoreBussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataStore.HardCoded
{
  public  class CustomerDepeRespo
    {
        private List<CustomerDepen> customers;
        public CustomerDepeRespo()
        {
            customers = new List<CustomerDepen>()
            {
                new CustomerDepen{Id=101,CustName="vijay",CustAddress="some address bar"},
                new CustomerDepen{Id=102,CustName="Krishna",CustAddress="some2 address2 bar2"}
            };
        }
        public CustomerDepen GetCustomer(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
