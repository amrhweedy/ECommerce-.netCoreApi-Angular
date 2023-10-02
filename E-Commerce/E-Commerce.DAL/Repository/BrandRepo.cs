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
    public class BrandRepo : IBrandRepo
    {
        private readonly ECommerceDBContext Context;

        public BrandRepo(ECommerceDBContext context)
        {
            Context = context;
        }

        public async Task Add(Brand? entity)
        {
            await Context.brands.AddAsync(entity!);

        }

        public async Task Delete(Brand? entity)
        {
            Context.Remove(entity!);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Brand?>> GetAll()
        {
            return await Context.brands.
                Include(c => c.Products!).
                ThenInclude(p => p.Category).
                ToListAsync();
        }

        public async Task<IEnumerable<Brand?>> GetAllWithPagination(BrandRequestParameters requestParameters)
        {
            return await Context.brands.
                Include(c => c.Products!).
                ThenInclude(p=>p.Category).
                Skip((requestParameters.pageNumber - 1) * requestParameters.PageSize)
                .Take(requestParameters.PageSize)
                .ToListAsync();

        }

        public async Task<Brand?> GetByID(int ID)
        {
            return await Context.brands.Include(c => c.Products!).ThenInclude(p => p.Category).FirstOrDefaultAsync(c=>c.Id==ID);

        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();

        }

        public async Task Update(int id, Brand? entity)
        {
            await Task.CompletedTask;

        }
    }
}
