using E_Commerce.BL.Dtos;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.IService
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandReadDto?>> GetAll();

        Task<IEnumerable<BrandReadDto?>> GetAllWithPagination(BrandRequestParameters requestParameters);

        Task<BrandReadDto?> GetByID(int ID);

        Task Add(BrandAddorUpdateDto? entity);
        Task Update(int id, BrandAddorUpdateDto? entity);
        Task Delete(int id);
    }
}
