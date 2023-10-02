using E_Commerce.DAL.context;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ECommerceDBContext Context;

        public ProductRepo(ECommerceDBContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<Product?>> GetAllWithoutPagination()
        {
            return await Context.products.ToListAsync();
        }
        public async Task<IEnumerable<Product?>> GetAll(RequestParameters requestParameters)
        {
            return await Context.products
                          .Include(p => p.Category)
                          .Include(p => p.Brand)
                          .Skip((requestParameters.pageNumber - 1) * requestParameters.PageSize)
                          .Take(requestParameters.PageSize)
                          .ToListAsync();


        }

        public async Task<IEnumerable<Product?>> GetAllWithSearchWithPagination(Expression<Func<Product, bool>> predict, RequestParameters requestParameters)
        {
            return await Context.products
               .Include(p => p.Category)
               .Include(p => p.Brand)
               .Where(predict)
               .Skip((requestParameters.pageNumber - 1) * requestParameters.PageSize)
               .Take(requestParameters.PageSize)
               .ToListAsync();
        }
        public async Task<IEnumerable<Product?>> GetAllWithSearch(Expression<Func<Product, bool>> predict)
        {
            return await Context.products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(predict)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product?>> GetAllWithSortASC<T>(Expression<Func<Product, T>> predict, RequestParameters requestParameters)
        {
            return await Context.products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .OrderBy(predict)
                .Skip((requestParameters.pageNumber - 1) * requestParameters.PageSize)
                .Take(requestParameters.PageSize)
                .ToListAsync();

        }
        public async Task<IEnumerable<Product?>> GetAllWithSortDESC<T>(Expression<Func<Product, T>> predict, RequestParameters requestParameters)
        {
            return await Context.products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .OrderByDescending(predict)
                .Skip((requestParameters.pageNumber - 1) * requestParameters.PageSize)
                .Take(requestParameters.PageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product?>> GetAllWithFilter(ProductRequestParameters requestParameters)
        {
            return await Context.products
                  .Include(p => p.Category)
                  .Include(p => p.Brand)
                  .Where(p => (requestParameters.CategoryName != null) ? (p.Category!.Name == requestParameters.CategoryName) : true)
                  .Where(p => (requestParameters.BrandName != null) ? (p.Brand!.Name == requestParameters.BrandName) : true)
                  .Where(p => (requestParameters.MinPrice != null && requestParameters.MaxPrice != null) ? (p.Price > requestParameters.MinPrice && p.Price <= requestParameters.MaxPrice) : true)
                  .Where(p => (requestParameters.MinPrice != null && requestParameters.MaxPrice == null) ? ( p.Price>requestParameters.MinPrice) : true)
                  .Where(p => (requestParameters.MinPrice == null && requestParameters.MaxPrice != null) ? (p.Price <= requestParameters.MaxPrice) : true)
                  .ToListAsync();
        }
        public async Task<IEnumerable<Product?>> GetAllWithFilterAndPagination(ProductRequestParameters requestParameters)
        {

            return await Context.products
                   .Include(p => p.Category)
                   .Include(p => p.Brand)
                   .Where(p => (requestParameters.CategoryName != null) ? (p.Category!.Name == requestParameters.CategoryName) : true)
                   .Where(p => (requestParameters.BrandName != null) ? (p.Brand!.Name == requestParameters.BrandName) : true)
                   .Where(p => (requestParameters.MinPrice != null && requestParameters.MaxPrice != null) ? (p.Price > requestParameters.MinPrice && p.Price <= requestParameters.MaxPrice) : true)
                  .Where(p => (requestParameters.MinPrice != null && requestParameters.MaxPrice == null) ? (p.Price > requestParameters.MinPrice) : true)
                  .Where(p => (requestParameters.MinPrice == null && requestParameters.MaxPrice != null) ? (p.Price <= requestParameters.MaxPrice) : true)
                   .Skip((requestParameters.pageNumber - 1) * requestParameters.PageSize)
                   .Take(requestParameters.PageSize)
                   .ToListAsync();


        }

        public async Task<Product?> GetByID(int ID)
        {
            return await Context.products.Include(p => p.Category).Include(p => p.Brand).FirstOrDefaultAsync(p=>p.Id== ID);
        }
        public async Task Add(Product? entity)
        {
           await Context.products.AddAsync(entity!);
        }

        public  async Task Delete(Product? entity)
        {
              Context.Remove(entity!);

             await Task.CompletedTask;
                
        }


        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();   
        }

        public async Task Update(int id, Product? entity)
        {
            await Task.CompletedTask;
        }

        
    }
}
