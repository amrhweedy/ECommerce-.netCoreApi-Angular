using Azure;
using E_Commerce.BL.Dtos.DeliveryMethod;
using E_Commerce.BL.Dtos.OrderDto;
using E_Commerce.DAL.models.order;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.IService;

public  interface IOrderService
{
    Task<IEnumerable<OrderReadDto>> GetAllOrderReadAsync();
    Task AddOrderAsync(AddOrderDto? addOrderDto);
    Task updateOrderstatus(int id, JsonPatchDocument<Order> order);
    Task<IEnumerable<DeliveryMethodReadDto>> GetallDeliveryMethods();

    Task<Address?> getAddressFromLastOrder(string userId);
}
