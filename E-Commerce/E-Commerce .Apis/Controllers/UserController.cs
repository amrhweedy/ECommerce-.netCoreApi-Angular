using E_Commerce.BL.IService;
using E_Commerce.DAL.paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_.Apis.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    [Authorize(Policy ="Admin")]

    public async Task<IActionResult> getAll([FromQuery] RequestParameters requestParameters)
    {

        return Ok(await userService.GetAll(requestParameters));
    }

    [HttpGet("SortedUsers")]


    public async Task<IActionResult> getSortedUsersBySearhc([FromQuery] RequestParameters requestParameters,[FromQuery] string? searchBy , [FromQuery]string? searchString)
    {

        return Ok(await userService.GetFilteredUsersBySearch(requestParameters,searchBy,searchString));
    }





    //[HttpGet("getByName/{name}")]
    //public async Task<IActionResult> getByName(string name)
    //{

    //    return Ok(await userService.getbyname(name));
    //}
    //[HttpGet("getByEmail/{email}")]
    //public async Task<IActionResult> getByEmail(string email)
    //{

    //    return Ok(await userService.getbyemail(email));
    //}
}