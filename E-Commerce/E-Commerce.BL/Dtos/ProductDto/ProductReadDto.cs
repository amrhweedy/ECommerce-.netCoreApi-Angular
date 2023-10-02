using E_Commerce.DAL.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos;

public class  ProductReadDto
{
    public required int Id { get; set; }

    public  required string Name { get; set; } = string.Empty;

    public required string Description { get; set; } = string.Empty;

    public required double Price { get; set; }

    public required string Picture { get; set; }=string.Empty;

    public required string?  CategoryName { get; set; }

    public required string? BrandName { get; set; }



}
