using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.IRepository;

public  interface IProductRepo
{

    Task<IEnumerable<Product?>> GetAllWithoutPagination();

    Task<IEnumerable<Product?>> GetAll(RequestParameters requestParameters);
    Task<IEnumerable<Product?>> GetAllWithFilter(ProductRequestParameters requestParameters );
    Task<IEnumerable<Product?>> GetAllWithFilterAndPagination(ProductRequestParameters requestParameters);


    Task<Product?> GetByID(int ID);

    Task Add(Product? entity);
    Task Update(int id, Product entity);
    Task Delete(Product? entity);

    Task SaveChanges();

    // Receive lambda expression which contain the link condition , to receive the lambda expression we will use expression class

    Task<IEnumerable<Product?>> GetAllWithSearch(Expression<Func<Product,bool>> predict);
    Task<IEnumerable<Product?>> GetAllWithSearchWithPagination(Expression<Func<Product, bool>> predict,RequestParameters requestParameters);

    Task<IEnumerable<Product?>> GetAllWithSortASC<T>(Expression<Func<Product, T>> predict, RequestParameters requestParameters);
    Task<IEnumerable<Product?>> GetAllWithSortDESC<T>(Expression<Func <Product, T>> predict, RequestParameters requestParameters);
}
