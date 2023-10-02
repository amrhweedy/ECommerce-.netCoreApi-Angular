using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.IRepository;

public interface IUserRepo
{
    Task<IEnumerable<ApplicationUser?>> GetAll(RequestParameters requestParameters);

    Task<IEnumerable<ApplicationUser?>> GetSortedUsersBySearch(Expression<Func<ApplicationUser, bool>> predict);

    Task<ApplicationUser?> GetByID(string ID);

    


}
