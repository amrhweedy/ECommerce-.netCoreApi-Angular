using E_Commerce.BL.Dtos;
using E_Commerce.DAL;
using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto?>> GetAllWithoutPagination();

        Task<IEnumerable<ProductReadDto?>> GetAll(RequestParameters requestParameters);

        Task<IEnumerable<ProductReadDto?>> GetAllWithFilter(ProductRequestParameters requestParameters);
        Task<IEnumerable<ProductReadDto?>> GetAllWithFilterAndPagination(ProductRequestParameters requestParameters);


        Task<ProductReadDto?> GetByID(int ID);

        Task Add(ProductAddOrUpdateDot? entity);
        Task Update(int id, ProductAddOrUpdateDot? entity);
        Task Delete(int id );


        //Task<IEnumerable<ProductReadDto?>> GetAllWithSearch( RequestParameters requestParameters , string? searchBy, string? searchString);
        Task<IEnumerable<ProductReadDto?>> GetAllWithSearchWithPagination(RequestParameters requestParameters,  string? searchString);
        Task<IEnumerable<ProductReadDto?>> GetAllWithSearch(RequestParameters requestParameters , string? searchString);



        Task<IEnumerable<ProductReadDto?>> GetAllWithSortASC(RequestParameters? RequestParameters,string? sortBy );
        Task<IEnumerable<ProductReadDto?>> GetAllWithSortDESC(RequestParameters? RequestParameters, string? sortBy);



    }
}
