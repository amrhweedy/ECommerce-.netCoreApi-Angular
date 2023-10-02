using AutoMapper;
using E_Commerce.BL.CusotmException;
using E_Commerce.BL.Dtos;
using E_Commerce.BL.IService;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Services
{
    public class BrandService : IBrandService
    {
        private readonly  IBrandRepo brandRepo;
        private readonly IMapper mapper;

        public BrandService(  IBrandRepo brandRepo , IMapper mapper)
        {
            this.brandRepo = brandRepo;
            this.mapper = mapper;
        }
        public async Task Add(BrandAddorUpdateDto? entity)
        {
            Brand brand = mapper.Map<Brand>(entity);
            await  brandRepo.Add(brand);
            await brandRepo.SaveChanges();

        }

        public async Task Delete(int id)
        {
            Brand? brand = await brandRepo.GetByID(id);
             if(brand is null)
            {
                throw new MyException("this brand is not found", 400);
            }
            else
            {
                await brandRepo.Delete(brand);
                await brandRepo.SaveChanges();
            }
        }

        public async Task<IEnumerable<BrandReadDto?>> GetAllWithPagination(BrandRequestParameters requestParameters)
        {
            var brands = await brandRepo.GetAllWithPagination(requestParameters);
             return  mapper.Map<IEnumerable<BrandReadDto>>(brands);


        }

        public async Task<IEnumerable<BrandReadDto?>> GetAll()
        {
            var brands = await brandRepo.GetAll();
            return mapper.Map<IEnumerable<BrandReadDto>>(brands);
        }

       

        public async Task<BrandReadDto?> GetByID(int ID)
        {
            if(ID == 0)
            {
                throw new MyException("id mustnot be 0", 400);
            }

            
            var brand = await brandRepo.GetByID(ID);

            if(brand is  null)
            {
                throw new MyException("this brand not found", 400);
            }

             return mapper.Map<BrandReadDto>(brand);
        }

        public async Task Update(int id, BrandAddorUpdateDto? entity)
        {
            Brand? brand = await brandRepo.GetByID(id);

            if (brand is null)
            {
                throw new MyException("this brand is not found", 400);
            }
            else
            {
                mapper.Map(entity,brand);
                await brandRepo.SaveChanges();
            }
        }
    }
}
