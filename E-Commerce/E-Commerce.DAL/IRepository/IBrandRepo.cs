using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.IRepository;

public interface IBrandRepo
{
    Task<IEnumerable<Brand?>> GetAll();

    Task<IEnumerable<Brand?>> GetAllWithPagination(BrandRequestParameters requestParameters);

    Task<Brand?> GetByID(int ID);

    Task Add(Brand? entity);
    Task Update(int id, Brand entity);
    Task Delete(Brand? entity);

    Task SaveChanges();
}
