using E_Commerce.DAL.context;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repository;

public class UserRepo : IUserRepo
{
    private readonly ECommerceDBContext context;

    public UserRepo(ECommerceDBContext context)
    {
        this.context = context;
    }
    public async Task<IEnumerable<ApplicationUser?>> GetAll(RequestParameters requestParameters)
    {
        return await context.Set<ApplicationUser>()
            .Skip((requestParameters.pageNumber - 1) * requestParameters.PageSize)
            .Take(requestParameters.PageSize)
            .ToListAsync();
    }

    public async Task<ApplicationUser?> GetByEmail(string Email)
    {
         return await context.Set<ApplicationUser>()
              .FirstOrDefaultAsync(x=> x.Email == Email);   

    }

    public async Task<ApplicationUser?> GetByID(string ID)
    {
        return await context.Set<ApplicationUser>()
               .FirstOrDefaultAsync(u => u.Id == ID);
    }

    public async Task<ApplicationUser?> GetByName(string Name)
    {
        return await context.Set<ApplicationUser>()
               .FirstOrDefaultAsync(x=>x.UserName==Name);

    }

    public async Task<IEnumerable<ApplicationUser?>> GetSortedUsersBySearch(Expression<Func<ApplicationUser, bool>> predict)
    {
        return await context.Set<ApplicationUser>()
            .Where(predict)
            .ToListAsync();
    }
}
