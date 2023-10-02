using E_Commerce.BL.Dtos.Authentication;
using E_Commerce.DAL.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using E_Commerce.BL.CusotmException;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace E_Commerce_.Apis.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager; 
    private readonly IConfiguration configuration;

    public AuthenticationController(UserManager<ApplicationUser> userManager , IConfiguration configuration,RoleManager<IdentityRole> roleManager )
    {
        this.userManager = userManager;
        this.configuration = configuration;
        this.roleManager = roleManager;
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
       ApplicationUser? applicationUser = await userManager.FindByEmailAsync(registerDto.email);
        if (applicationUser != null)
        {
            throw new MyException("this email is found already.choose another email", 400);
        }

        ApplicationUser? applicationUser1 =   await userManager.FindByNameAsync(registerDto.userName);
        if (applicationUser1 != null)
        {
            throw new MyException("this UserName is found already.choose another UserName", 400);
        }

        ApplicationUser user = new ApplicationUser()
        {
            UserName = registerDto.userName,
            Email = registerDto.email,
        };

        
      var result =  await userManager.CreateAsync(user , registerDto.password);
        if (!result.Succeeded)
        {
            string error = "";
            foreach(var item in result.Errors)
            {
                error += item.Description+"\n";
            }
            return BadRequest(error);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "User"),
        };

        await userManager.AddClaimsAsync(user, claims);
        await userManager.AddToRoleAsync(user, "User");

        return Ok();

    }

    [HttpPost("Login")]
    public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
    {

        var user = await userManager.FindByEmailAsync(loginDto.email);

        if (user == null) 
        {
            return Unauthorized("this email is not found");  
        }

        var isAuthenticated = await userManager.CheckPasswordAsync(user,loginDto.password);
        if (!isAuthenticated)
        {
            return Unauthorized("this password is wrong");
        }
        var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();

       

        var claimsList = await userManager.GetClaimsAsync(user);

        #region SecrectKey
        var secretKeyString = configuration.GetValue<string>("SecretKey");
        var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
        var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);
        #endregion

        #region Create a combination of secretKey, Algorithm
        var signingCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256Signature);
        #endregion

        #region putting all together to create token object

        var expiryDate = DateTime.Now.AddDays(1);

        var token = new JwtSecurityToken(
            claims: claimsList,
            expires: expiryDate,
            signingCredentials: signingCredentials);

        #endregion

        #region Convert Token Object To String

        var tokenHndler = new JwtSecurityTokenHandler();
        var tokenString = tokenHndler.WriteToken(token);

        #endregion

        return new TokenDto
        {
            Token = tokenString,
            ExpiryDate = expiryDate,
            Role = role,
            UserId =user.Id,
            UserName = user.UserName,
        };

    }





}
