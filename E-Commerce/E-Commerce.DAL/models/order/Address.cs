using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.models.order;

public class Address
{
    [Required]
    public string? firstName {  get; set; } 
    [Required]
    public string? lastName { get; set; } 
    [Required]
    public string street { get;set; } = string.Empty;
    [Required]
    public string city { get; set; } = string.Empty;
    [Required]
    public string state { get; set; } = string.Empty;



}
