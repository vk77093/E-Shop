﻿using eshop.CoreBussiness.Models;
using eShop.UseCases.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.SearchProductScreen
{
    public class ViewProduct : IViewProduct
    {
        private readonly IProductRepository productRepository;
        public ViewProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product Execute(int id)
        {
            return productRepository.GetProduct(id);
        }
    }
}
