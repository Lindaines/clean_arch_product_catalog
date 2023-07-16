using CleanArchMvc.Domain.Intefaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CleanArchMvc.Infra.Data.Repository 
{

    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _productContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync ()
        {
            return await _productContext.Products.ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);

        }
        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;

        }
        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;


        }
        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}