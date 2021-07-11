﻿using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void Add(Product product);
        public Product GetDetails(int id);
        void update(Product product);
        void Delete(int id);
    }
}