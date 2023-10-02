using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos;

public record ProductAddOrUpdateDot
{
    [Required(ErrorMessage ="{0} can't be blank")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1}")]
    public string Name { get; init; } = string.Empty;
    [Required(ErrorMessage ="description can't be blank")]
    public string Description { get; init; } = string.Empty;

    [Required(ErrorMessage = "{0} can't be blank")]
    public double Price { get; init; }

    [Required(ErrorMessage = "{0} can't be blank")]

    public IFormFile Picture { get; init; } 

    [Required(ErrorMessage = "{0} can't be blank")]
    [Range(1,int.MaxValue , ErrorMessage ="{0} is required and bigger than 0")]
    public int CategoryId { get; init; }

    [Required(ErrorMessage = "{0} can't be blank")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} is required and bigger than 0")]

    public int BrandId { get; init; }

    

}
