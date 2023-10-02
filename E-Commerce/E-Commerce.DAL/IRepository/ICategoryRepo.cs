using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.IRepository;

 public interface ICategoryRepo
{
    Task<IEnumerable<Category?>> GetAll();

    Task<IEnumerable<Category?>> GetAllWithPagination(CategoryRequestParameters requestParameters);

    Task<Category?> GetByID(int ID);

    Task Add(Category? entity);
    Task Update(int id, Category entity);
    Task Delete(Category? entity);

    Task SaveChanges();

}
