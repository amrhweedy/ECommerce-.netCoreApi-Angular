using AutoMapper.Configuration.Conventions;
using E_Commerce.BL.Dtos;
using E_Commerce.BL.Dtos.Pagination;
using E_Commerce.BL.IService;
using E_Commerce.DAL;
using E_Commerce.DAL.models;
using E_Commerce.DAL.paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace E_Commerce_.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<ProductReadDto>>> GetAll([FromQuery] RequestParameters requestParameters ) 
        {
            var productsWithPagination = await productService.GetAll(requestParameters);
            var allProducts = await productService.GetAllWithoutPagination();

            PaginationResponse<ProductReadDto> paginationResponse = new PaginationResponse<ProductReadDto>
            {
                Data = productsWithPagination!,
                pageSize = requestParameters.PageSize,
                pageNumber = requestParameters.pageNumber,
                totalItems = allProducts.Count()
            };

            return Ok(paginationResponse);   



        }

        [HttpGet("GetProductsWithFilter")]
        public async Task<ActionResult<PaginationResponse<ProductReadDto>>> GetAllWithFilter([FromQuery] ProductRequestParameters requestParameters)
        {
            var allProducts = await productService.GetAllWithoutPagination();
            var productsWithFilteroInly = await productService.GetAllWithFilter(requestParameters);
            var productsWithFilterAndPagination = await productService.GetAllWithFilterAndPagination(requestParameters);



            PaginationResponse<ProductReadDto> paginationResponse = new PaginationResponse<ProductReadDto>
            {
                Data = productsWithFilterAndPagination!,  // data with pagination
                pageSize = requestParameters.PageSize,
                pageNumber = requestParameters.pageNumber,
            };
            
            if(requestParameters.CategoryName is null && requestParameters.BrandName is null&& requestParameters.MinPrice==null&&requestParameters.MaxPrice==null)
            {
                paginationResponse.totalItems=allProducts.Count();
            }
            else
            {
                paginationResponse.totalItems=productsWithFilteroInly.Count();
            }

            return Ok(paginationResponse);

        }

        [HttpGet("GetProductsWithSearch")]

        public async Task<ActionResult<PaginationResponse<ProductReadDto>>> GetAllWithSearch([FromQuery] RequestParameters requestParameters , [FromQuery] string? searchString)
        {

            var searchedProductsPagination = await productService.GetAllWithSearchWithPagination(requestParameters ,searchString);
            var searchedProducts = await productService.GetAllWithSearch(requestParameters, searchString);


            PaginationResponse<ProductReadDto> paginationResponse = new PaginationResponse<ProductReadDto>
            {
                Data = searchedProductsPagination!,
                pageSize = requestParameters.PageSize,
                pageNumber = requestParameters.pageNumber,
                totalItems = searchedProducts.Count()
            };

            return Ok(paginationResponse);
        }

        [HttpGet("GetProductsWithSortASC")]

        public async Task<ActionResult<PaginationResponse<ProductReadDto>>> GetAllWithSortASC([FromQuery] RequestParameters requestParameters, string? sortBy)
        {
            var allProducts = await productService.GetAllWithoutPagination();

            var SortedProductsASc = await productService.GetAllWithSortASC(requestParameters, sortBy);

            PaginationResponse<ProductReadDto> paginationResponse = new PaginationResponse<ProductReadDto>
            {
                Data = SortedProductsASc!,
                pageSize = requestParameters.PageSize,
                pageNumber = requestParameters.pageNumber,
                totalItems = allProducts.Count()
            };

            return Ok(paginationResponse);

        }

        [HttpGet("GetProductsWithSortDESC")]

        public async Task<ActionResult<PaginationResponse<ProductReadDto>>> GetAllWithSortDESC([FromQuery] RequestParameters requestParameters, string? sortBy)
        {
            var allProducts = await productService.GetAllWithoutPagination();

            var SortedProductsASc = await productService.GetAllWithSortDESC(requestParameters, sortBy);

            PaginationResponse<ProductReadDto> paginationResponse = new PaginationResponse<ProductReadDto>
            {
                Data = SortedProductsASc!,
                pageSize = requestParameters.PageSize,
                pageNumber = requestParameters.pageNumber,
                totalItems = allProducts.Count()
            };

            return Ok(paginationResponse);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             return Ok(  await productService.GetByID(id));
        }


        [HttpPost]
         public async Task<IActionResult> Add ([FromForm]ProductAddOrUpdateDot? enity)
        {
            await  productService.Add(enity);
            return Ok(enity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , [FromForm] ProductAddOrUpdateDot? enity)
        {
            await productService.Update(id, enity);
            return Ok(enity);   
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.Delete(id);
            return NoContent();

        }
    }
}
