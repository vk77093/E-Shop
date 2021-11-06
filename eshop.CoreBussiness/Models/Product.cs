using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.CoreBussiness.Models
{
  public  class Product
    {
        public int Id { get; set; }
        public string Band { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string  ImageUrl { get; set; }
        public string  Description { get; set; }
    }
}
