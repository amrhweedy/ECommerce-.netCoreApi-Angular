using E_Commerce.DAL.context;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ECommerceDBContext Context;

        public CategoryRepo(ECommerceDBContext Context)
        {
            this.Context = Context;
        }


        public async Task Add(Category? entity)
        {
            await Context.categories.AddAsync(entity!);

        }

        public async Task Delete(Category? entity)
        {
            Context.Remove(entity!);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Category?>> GetAll()
        {
            return await Context.categories
                        .Include(c=>c.Products!)
                         .ThenInclude(p=>p.Brand)
                         .ToListAsync();
        }

        public async Task<IEnumerable<Category?>> GetAllWithPagination( CategoryRequestParameters requestParameters)
        {
            return await Context.categories.
                Include(c=>c.Products!).
                ThenInclude(p=>p.Brand)
                 .Skip((requestParameters.pageNumber - 1) * requestParameters.PageSize)
                 .Take(requestParameters.PageSize)
                 .ToListAsync();
        }

        public async Task<Category?> GetByID(int ID)
        {
            return await Context.categories.Include(c => c.Products!).ThenInclude(p=>p.Brand).FirstOrDefaultAsync(c=>c.Id==ID);
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

        public async Task Update(int id, Category? entity)
        {
            await Task.CompletedTask;
        }
    }
}
