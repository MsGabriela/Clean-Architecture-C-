﻿using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
     public interface IProductRepository
    {
        //retorna todas as categorias
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetByIdAsync(int? id);
        Task<Product> GetProductCategoryAsync(int? id);

        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
