using E_Commerce.BL.Dtos;
using E_Commerce.BL.Dtos.Pagination;
using E_Commerce.BL.IService;
using E_Commerce.BL.Services;
using E_Commerce.DAL.paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace E_Commerce_.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await brandService.GetAll());
        }

        [HttpGet("BrandsWithPagination")]
        public async Task<ActionResult<BrandReadDto>> GetAllWithPagination([FromQuery] BrandRequestParameters requestParameters)
        {
            var allBrands = await brandService.GetAll();
            var brandsWithPagination = await brandService.GetAllWithPagination(requestParameters);

            PaginationResponse<BrandReadDto> paginationResponse = new PaginationResponse<BrandReadDto>
            {
                Data = brandsWithPagination!,
                pageSize = requestParameters.PageSize,
                pageNumber = requestParameters.pageNumber,
                totalItems = allBrands.Count()
            };

            return Ok(paginationResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>  GetByID(int id)
        {
            return Ok(await brandService.GetByID(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(BrandAddorUpdateDto? brandAddorUpdateDto)
        {
            await brandService.Add(brandAddorUpdateDto);
            return Ok(brandAddorUpdateDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BrandAddorUpdateDto? brandAddorUpdateDto)
        {
            await brandService.Update(id, brandAddorUpdateDto);
            return Ok(brandAddorUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await brandService.Delete(id);
            return NoContent();
        }


    }
}
