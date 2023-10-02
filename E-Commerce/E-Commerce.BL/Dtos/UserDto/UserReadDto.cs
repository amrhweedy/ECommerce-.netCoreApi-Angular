using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.UserDto
{
     public  class UserReadDto
    {
        public required string Id { get; init; } = string.Empty;

        public required string Name { get; init; } = string.Empty;

        public required string Email { get; init; } = string.Empty;

        public required  string RegisterdDate { get; init; }


    }
}
