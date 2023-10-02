using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.Authentication;



public class TokenDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime? ExpiryDate { get; set; }
    public string? Role { get; set; }
    public string UserId { get; set; }=string.Empty;
    public string? UserName { get; set; }
}