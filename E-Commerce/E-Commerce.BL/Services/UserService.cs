using AutoMapper;
using E_Commerce.BL.CusotmException;
using E_Commerce.BL.Dtos;
using E_Commerce.BL.Dtos.UserDto;
using E_Commerce.BL.IService;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using E_Commerce.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Services;

public class UserService : IUserService
{
    private readonly IUserRepo userRepo;

    public UserService(IUserRepo userRepo)
    {
        this.userRepo = userRepo;
    }
    public async Task<IEnumerable<UserReadDto?>> GetAll(RequestParameters requestParameters)
    {
        
       var allusers = await userRepo.GetAll(requestParameters);

        return allusers.Select(user => new UserReadDto
        {


            Id = user.Id,
            Name = user.UserName!,
            Email = user.Email!,
            RegisterdDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")

        }) ;
        
    }

   

    public async Task<UserReadDto?> GetByID(string ID)
    {
        if (string.IsNullOrWhiteSpace(ID))
        {
            throw new MyException("id mustnot be blank", 400);
        }
        var user =  await userRepo.GetByID(ID);

        if(user == null)
        {
            throw new MyException("this user is not found", 400);
        }

        return new UserReadDto
        {
            Id = user.Id,
            Name = user.UserName!,
            Email = user.Email!,
            RegisterdDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
        };

    }

    //public async Task<UserReadDto?> getbyname(string name)
    //{
    //    if (string.IsNullOrWhiteSpace(name))
    //    {
    //        throw new MyException("name mustnot be blank", 400);
    //    }
    //    var user = await userRepo.GetByName(name);

    //    if (user == null)
    //    {
    //        throw new MyException("this user is not found", 400);
    //    }

    //    return new UserReadDto
    //    {
    //        Id = user.Id,
    //        Name = user.UserName!,
    //        Email = user.Email!,
    //        RegisterdDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
    //    };
    //}

    //public async Task<UserReadDto?> getbyemail(string email)
    //{
    //    if (string.IsNullOrWhiteSpace(email))
    //    {
    //        throw new MyException("email mustnot be blank", 400);
    //    }
    //    var user = await userRepo.GetByEmail(email);

    //    if (user == null)
    //    {
    //        throw new MyException("this user is not found", 400);
    //    }

    //    return new UserReadDto
    //    {
    //        Id = user.Id,
    //        Name = user.UserName!,
    //        Email = user.Email!,
    //        RegisterdDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
    //    };
    //}

   

    public async Task<IEnumerable<UserReadDto?>> GetFilteredUsersBySearch(RequestParameters requestParameters, string? searchBy, string? searchString)
    {
        IEnumerable<ApplicationUser?> Users;

        if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
        {
            Users = await userRepo.GetAll(requestParameters);
            return Users.Select(user => new UserReadDto
            {
                Id = user.Id,
                Name = user.UserName!,
                Email = user.Email!,
                RegisterdDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
            });
        }

        Users = searchBy switch
        {
            // i cant use stringcomparison.ignoresensitive because this lamda experssion will convert into sql statement and the entity framework cant convert stringcomparison.ignoresensitive
            nameof(UserReadDto.Name) =>
            await userRepo.GetSortedUsersBySearch(p => p.UserName.Contains(searchString)),

            nameof(UserReadDto.Email) =>
            await userRepo.GetSortedUsersBySearch(p => p.Email.Contains(searchString)),


            _ => await userRepo.GetAll(requestParameters)

        };

        var usersReadDto = Users.Select(user => new UserReadDto
        {
            Id = user.Id,
            Name = user.UserName!,

            Email = user.Email!,
            RegisterdDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
        });

        return usersReadDto;

    }
}
