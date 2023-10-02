using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.models.order;

public class productedOrdered
{

    [ForeignKey(nameof(order))] 
     public int orderid { get; set; }    
    public virtual Order? order { get; set; }

    [ForeignKey(nameof(product))]

    public int productid { get; set; }
    public Product? product { get; set; }

    public int Quantity { get; set; }


    




    

}
