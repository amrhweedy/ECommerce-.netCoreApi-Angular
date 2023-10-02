using E_Commerce.BL.Dtos;
using E_Commerce.BL.Dtos.UserDto;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.IService
{
    public interface IUserService 
    {
        Task<IEnumerable<UserReadDto?>> GetAll(RequestParameters requestParameters);

        Task<IEnumerable<UserReadDto?>> GetFilteredUsersBySearch(RequestParameters requestParameters, string? searchBy, string? searchString);


        Task<UserReadDto?> GetByID(string  ID);

        

    }
}
