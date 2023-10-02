using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.models.order;

public class Order
{
    public int Id { get; set; }

    
    public DateTime OrderDate { get; set; } = DateTime.Now;


    public double Total { get; set; }

    
    public string paymentIntentId { get; set; }= string.Empty;

    public OrderedStatus OrderedStatus { get; set; } = OrderedStatus.pending;  //enum

    public   Address?  Address  { get; set; }  


    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = string.Empty;
    public virtual ApplicationUser? User { get; set; }


    [ForeignKey(nameof(DeliveryMethod))]
    public int deliveryMethodId { get; set; }
    public virtual DeliveryMethod? DeliveryMethod { get; set; }


    public IEnumerable<productedOrdered> orderItems { get; set; } = new List<productedOrdered>();



}
