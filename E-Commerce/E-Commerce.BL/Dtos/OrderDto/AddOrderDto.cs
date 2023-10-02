using E_Commerce.DAL.models.order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.OrderDto;

public class AddOrderDto
{
    [Required]
    public string userId { get; set; } = string.Empty; 

    [Required]
    public Address Address { get; set; } = new Address();
    [Required]
    public int deliveryMethodId { get; set; }

    
    public IEnumerable<ProductOrderedDto> orderItems { get; set; } = new List<ProductOrderedDto>();



}
