using E_Commerce.BL.Dtos;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto?>> GetAll();

        Task<IEnumerable<CategoryReadDto?>> GetAllWithPagination(CategoryRequestParameters requestParameters);

        Task<CategoryReadDto?> GetByID(int ID);

        Task Add(CategoryAddorUpdateDto? entity);
        Task Update(int id, CategoryAddorUpdateDto? entity);
        Task Delete(int id);
    }
}
