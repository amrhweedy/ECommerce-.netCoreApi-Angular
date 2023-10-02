using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.Authentication;

 public class LoginDto
{
    public required string password { get; init; } = string.Empty;
    public required string email { get; init; } = string.Empty;

}
