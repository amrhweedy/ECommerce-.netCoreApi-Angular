using AutoMapper;
using E_Commerce.BL.CusotmException;
using E_Commerce.BL.Dtos;
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

namespace E_Commerce.BL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepo categoryRepo , IMapper mapper)
        {
            this.categoryRepo = categoryRepo;
            this.mapper = mapper;
        }
        public async Task Add(CategoryAddorUpdateDto? entity)
        {
            Category category = mapper.Map<Category>(entity);
            await categoryRepo.Add(category);
            await categoryRepo.SaveChanges();
            
        }

        public async Task Delete(int id)
        {
            var category = await categoryRepo.GetByID(id);

            if (category == null)
            {
                throw new MyException("this category is not found", 400);
            }
            else
            {
                 await categoryRepo.Delete(category);
                await categoryRepo.SaveChanges();
            }

        }

        public async Task<IEnumerable<CategoryReadDto?>> GetAll()
        {
            var categories = await categoryRepo.GetAll();
            var categoiresDto = mapper.Map<IEnumerable<CategoryReadDto>>(categories);

            return categoiresDto;
        }

        public async Task<IEnumerable<CategoryReadDto?>> GetAllWithPagination(CategoryRequestParameters requestParameters)
        {
                var categories =  await categoryRepo.GetAllWithPagination(requestParameters);
                var categoiresDto =   mapper.Map<IEnumerable<CategoryReadDto>>(categories);

            return categoiresDto;  
                
        }

        public async Task<CategoryReadDto?> GetByID(int ID)
        {
            if (  ID == 0)
            {
                throw new MyException("id mustnot be null or zero", 400);
            }

            Category? category = await categoryRepo.GetByID(ID);
            if (category == null)
            {
                throw new MyException("this category is not found", 400);
            }
            
            var categoryDto= mapper.Map<CategoryReadDto>(category);

            return categoryDto;
        }

        public async Task Update(int id, CategoryAddorUpdateDto? entity)
        {
             var category = await categoryRepo.GetByID(id);

              if(category == null)
            {
                throw new MyException("this category is not found", 400);
            }
            else
            {
                mapper.Map(entity, category);

                await categoryRepo.SaveChanges();
            }
        }
    }
}
