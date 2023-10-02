using AutoMapper;
using E_Commerce.BL.CusotmException;
using E_Commerce.BL.Dtos;
using E_Commerce.BL.IService;
using E_Commerce.DAL;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo productRepo;
        private readonly IMapper mapper;
        private readonly ICategoryRepo categoryRepo;
        private readonly IBrandRepo brandRepo;
        private readonly  IWebHostEnvironment hosting;

        public ProductService(IProductRepo ProductRepo , IMapper mapper,
          ICategoryRepo categoryRepo, IBrandRepo brandRepo , IWebHostEnvironment hosting  )
        {
            productRepo = ProductRepo;
            this.mapper = mapper;
            this.categoryRepo = categoryRepo;
            this.brandRepo = brandRepo;
            this.hosting = hosting;
        }
        
        private async Task<bool> GetCategory( int id  )
        {
              var category = await categoryRepo.GetByID( id ); 
             if ( category is null )
            {
                return false;
            }
             return true;
        }

        private async Task<bool> GetBrand(int id)
        {
            var brand = await brandRepo.GetByID(id);

             if(brand is null )
            { return false; }   
             return true;
        }

        public async Task<IEnumerable<ProductReadDto?>> GetAll(RequestParameters requestParameters)
        {
            var allproducts = await productRepo.GetAll(requestParameters);
            IEnumerable<ProductReadDto> allProductsDto = mapper.Map<IEnumerable<ProductReadDto>>(allproducts);

            return allProductsDto;
        }

        public async Task<IEnumerable<ProductReadDto?>> GetAllWithoutPagination()
        {

            var products = await productRepo.GetAllWithoutPagination();

            return mapper.Map<IEnumerable<ProductReadDto>>(products);
        }

        public async Task Add(  ProductAddOrUpdateDot? entity)
        {
             

            if (  !await GetCategory( entity!.CategoryId))
            {
                throw new MyException("this category is not found", 400);
            }

            if (!await GetBrand(entity.BrandId))
            {
                
               throw new MyException("this brand is not found", 400);
            }

            string PathToFolderImages = Path.Combine(hosting.WebRootPath, "Images");
            string pictureName = entity.Picture.FileName;
            string PicturefullPath = Path.Combine(PathToFolderImages, pictureName);
            await entity.Picture.CopyToAsync(new FileStream(PicturefullPath, FileMode.Create));

            Product product = new Product()
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Picture = pictureName,
                BrandId = entity.BrandId,
                CategoryId = entity.CategoryId,

            };

            await productRepo.Add( product );
            await productRepo.SaveChanges();

        }

        public async Task Delete(int id)
        {
            var product = await productRepo.GetByID(id);
            if(product is null)
            {
                throw new MyException("this product is not found", 400);
            }

            await productRepo.Delete( product );
            await productRepo.SaveChanges();

        }



        public async Task<IEnumerable<ProductReadDto?>> GetAllWithFilter(ProductRequestParameters requestParameters )
        {
            var allproducts = await productRepo.GetAllWithFilter(requestParameters);
            IEnumerable<ProductReadDto> allProductsDto = mapper.Map<IEnumerable<ProductReadDto>>(allproducts);

            return allProductsDto;

                  
        }
        public async Task<IEnumerable<ProductReadDto?>> GetAllWithFilterAndPagination(ProductRequestParameters requestParameters)
        {
            var allproducts = await productRepo.GetAllWithFilterAndPagination(requestParameters);
            IEnumerable<ProductReadDto> allProductsDto = mapper.Map<IEnumerable<ProductReadDto>>(allproducts);

            return allProductsDto;
        }
        

        public async Task<IEnumerable<ProductReadDto?>> GetAllWithSearchWithPagination(RequestParameters requestParameters, string? searchString)
        {
            IEnumerable<Product?> products;

            if ( string.IsNullOrEmpty(searchString))
            {
                products = await productRepo.GetAll(requestParameters);
                return mapper.Map<IEnumerable<ProductReadDto>>(products);
            }


            products = await productRepo.GetAllWithSearchWithPagination(p => p.Name.Contains(searchString) , requestParameters);


            IEnumerable<ProductReadDto> productReadDtos = mapper.Map<IEnumerable<ProductReadDto>>(products);

            return productReadDtos;

        }


        public async Task<ProductReadDto?> GetByID(int ID)
        {
            if ( ID==0)
            {
                throw new MyException("id mustnot be null or zero", 400);
            }

            Product? product =  await productRepo.GetByID(ID);
            if (product == null)
            {
                throw new MyException("this product is not found", 400);
            }

             ProductReadDto productDto =   mapper.Map<ProductReadDto>(product);

            return productDto;
        }

        public async Task Update(int id, ProductAddOrUpdateDot? entity)
        {
            var product = await productRepo.GetByID(id);

            if (product == null)
            {
                throw new MyException("this product is notfound ", 400);
            }

            if (!await GetCategory(entity!.CategoryId))
            {
                throw new MyException("this category is not found", 400);
            }

            if (!await GetBrand(entity.BrandId))
            {

                throw new MyException("this brand is not found", 400);
            }


            string PathToFolderImages = Path.Combine(hosting.WebRootPath, "Images");
            string pictureName = entity.Picture.FileName;
            string PicturefullPath = Path.Combine(PathToFolderImages, pictureName);
            await entity.Picture.CopyToAsync(new FileStream(PicturefullPath, FileMode.Create));

            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Price = entity.Price;
            product.Picture = pictureName;
            product.BrandId = entity.BrandId;
            product.CategoryId = entity.CategoryId;
            
            
            await productRepo.SaveChanges();

        }

        public async  Task<IEnumerable<ProductReadDto?>> GetAllWithSortASC(RequestParameters? requestParameters, string? sortBy)

        {
            if( string.IsNullOrEmpty(sortBy) || string.IsNullOrWhiteSpace(sortBy))
            {
                  return await GetAll(requestParameters!);
            }



             var sortedproducts = sortBy switch
            {
                (nameof(ProductReadDto.Name)) =>
                 await productRepo.GetAllWithSortASC(p => p.Name, requestParameters),



                (nameof(ProductReadDto.Price)) =>
                 await productRepo.GetAllWithSortASC(p => p.Price, requestParameters),




                _ => await productRepo.GetAll(requestParameters)


            } ;

              return mapper.Map<IEnumerable< ProductReadDto>>(sortedproducts);

        }

        public async Task<IEnumerable<ProductReadDto?>> GetAllWithSortDESC(RequestParameters? requestParameters, string? sortBy)
        {
            if (string.IsNullOrEmpty(sortBy) || string.IsNullOrWhiteSpace(sortBy))
            {
                return await GetAll(requestParameters!);
            }



            var sortedproducts = sortBy switch
            {
                (nameof(ProductReadDto.Name)) =>
                 await productRepo.GetAllWithSortDESC(p => p.Name, requestParameters),



                (nameof(ProductReadDto.Price)) =>
                 await productRepo.GetAllWithSortDESC(p => p.Price, requestParameters),




                _ => await productRepo.GetAll(requestParameters)


            };

            return mapper.Map<IEnumerable<ProductReadDto>>(sortedproducts);

        }

       

        public async Task<IEnumerable<ProductReadDto?>> GetAllWithSearch(RequestParameters requestParameters,string? searchString)
        {
            IEnumerable<Product?> products;

            if (string.IsNullOrEmpty(searchString))
            {
                products = await productRepo.GetAll(requestParameters);
                return mapper.Map<IEnumerable<ProductReadDto>>(products);
            }


            products = await productRepo.GetAllWithSearch(p => p.Name.Contains(searchString) );


            IEnumerable<ProductReadDto> productReadDtos = mapper.Map<IEnumerable<ProductReadDto>>(products);

            return productReadDtos;

        }


        #region getallwithsearhc(more options for search by)
        //public async Task<IEnumerable<ProductReadDto?>> GetAllWithSearch(RequestParameters requestParameters, string? searchBy, string? searchString)
        //{
        //    IEnumerable<Product?> products;

        //    if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
        //    {
        //        products = await productRepo.GetAll(requestParameters);
        //        return mapper.Map<IEnumerable<ProductReadDto>>(products);
        //    }

        //    products = searchBy switch
        //    {
        //        // i cant use stringcomparison.ignoresensitive because this lamda experssion will convert into sql statement and the entity framework cant convert stringcomparison.ignoresensitive
        //        nameof(ProductReadDto.Name) =>
        //        await productRepo.GetAllWithSearchWithPagination(p => p.Name.Contains(searchString), requestParameters),


        //        nameof(ProductReadDto.CategoryName) =>
        //        await productRepo.GetAllWithSearchWithPagination(p => p.Category.Name.Contains(searchString), requestParameters),

        //        nameof(ProductReadDto.BrandName) =>
        //        await productRepo.GetAllWithSearchWithPagination(p => p.Brand.Name.Contains(searchString), requestParameters),

        //        _ => await productRepo.GetAll(requestParameters)

        //    };

        //    IEnumerable<ProductReadDto> productReadDtos = mapper.Map<IEnumerable<ProductReadDto>>(products);

        //    return productReadDtos;


        //}
        #endregion

    }
}
