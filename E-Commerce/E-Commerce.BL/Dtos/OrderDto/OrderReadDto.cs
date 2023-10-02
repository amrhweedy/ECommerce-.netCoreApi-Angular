using E_Commerce.DAL.models.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.OrderDto;

public class OrderReadDto
{
    public int Id { get; set; }


    public DateTime OrderDate { get; set; } = DateTime.Now;


    public double Total { get; set; }



    public OrderedStatus OrderedStatus { get; set; }   

    public Address? Address { get; set; }

    public string? userName { get; set; } 

    public string? email { get; set; }
}
