﻿using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Interface
{
    public interface IProductRepository
    {
        string AddProduct(Product product);
        List<Product> GetProductList();
        string GetProductById(int id);
    }
}
