using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.DeliveryMethod;

public class DeliveryMethodReadDto
{
    public int id { get; set; }

    public string Name { get; set; } = string.Empty;


    public string description { get; set; } = string.Empty;

    public double price { get; set; }
}
