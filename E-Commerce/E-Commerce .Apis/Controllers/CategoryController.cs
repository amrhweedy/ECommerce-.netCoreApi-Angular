using Azure.Core;
using E_Commerce.BL.Dtos;
using E_Commerce.BL.Dtos.Pagination;
using E_Commerce.BL.IService;
using E_Commerce.BL.Services;
using E_Commerce.DAL.paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService) 
        { 
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryService.GetAll());
        }

        [HttpGet("CategoriesWithPagination")]
        public async Task<ActionResult<CategoryReadDto>> GetAllWithPagination([FromQuery] CategoryRequestParameters requestParameters)
        {
              var allCategories = await categoryService.GetAll();
            var categoriesWithPagination = await categoryService.GetAllWithPagination(requestParameters);

            PaginationResponse<CategoryReadDto> paginationResponse = new PaginationResponse<CategoryReadDto>
            {
                Data = categoriesWithPagination!,
                pageSize = requestParameters.PageSize,
                pageNumber = requestParameters.pageNumber,
                totalItems = allCategories.Count()
            };

            return Ok(paginationResponse);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            return Ok(await categoryService.GetByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddorUpdateDto? categoryAddorUpdateDto)
        {
            await categoryService.Add(categoryAddorUpdateDto);
            return Ok(categoryAddorUpdateDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id ,CategoryAddorUpdateDto? categoryAddorUpdateDto)
        {
            await categoryService.Update(id, categoryAddorUpdateDto);
            return Ok(categoryAddorUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.Delete(id);
            return NoContent();
        }
    }
}
