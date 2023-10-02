using E_Commerce.DAL.models.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.IRepository;

public  interface IOrderRepo
{
    Task<IEnumerable<Order>> GetAll();
    Task CreateOrder(Order? order);


    Task SaveChanges();
    Task<Order?> GetOrderByID(int id);
    Task updateOrderState(Order order1);
    Task<IEnumerable<DeliveryMethod>> getAllDeliveryMethods();
    Task<Order?> getAddressFromLastOrder(string userId);
}
