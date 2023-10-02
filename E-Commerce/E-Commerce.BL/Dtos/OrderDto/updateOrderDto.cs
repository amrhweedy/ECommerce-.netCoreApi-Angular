using E_Commerce.DAL.models.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.OrderDto;

public class updateOrderDto
{
    public OrderedStatus OrderedStatus { get; set; }
}
