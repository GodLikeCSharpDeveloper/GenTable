﻿using GenericTableBlazorAppV4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Repository.StoreLogic.NewFolder2
{
    public class ProductRepository : IProductRepositoryService
    {
        private readonly StoreContext _StoreContext;
        public ProductRepository(StoreContext storeContext)
        {
            _StoreContext = storeContext;
        }
        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            return await _StoreContext.Products.ToListAsync();
        }
        public async Task<List<ProductModel>> GetProductsByCategoryAsync(string category)
        {
            return await _StoreContext.Products.Where(a => a.Category.ToLower().Contains(category.ToLower())).ToListAsync();
        }
        public async Task<List<ProductModel>> GetOrderByName(string name)
        {
            var product = await _StoreContext.Products.Where(a => a.Name.ToLower().Contains(name))
                .ToListAsync();
            return product;
        }
        public async Task<bool> InsertProductAsync(ProductModel product)
        {
            await _StoreContext.Products.AddAsync(product);
            await _StoreContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateProductAsync(ProductModel product)
        {
            _StoreContext.Products.Update(product);
            await _StoreContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOrderAsync(ProductModel product)
        {
            _StoreContext.Products.Remove(product);
            await _StoreContext.SaveChangesAsync();
            return true;
        }
    }
}
