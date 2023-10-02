using E_Commerce.DAL.context;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models.order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repository;

public class OrderRepo : IOrderRepo
{
    private readonly ECommerceDBContext Context;

    public OrderRepo(ECommerceDBContext context)
    {
        Context = context;
    }
    public async Task CreateOrder(Order? order)
    {
        if(order is not null )
        {
            await Context.AddAsync(order);
        }
    }

    public async Task<Order?> getAddressFromLastOrder(string userId)
    {
        return  await Context.orders.OrderBy(o=>o.OrderDate).LastOrDefaultAsync(o=>o.UserId == userId);
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return  await Context.orders.Include(o=>o.User).ToListAsync();
    }

    public async Task<IEnumerable<DeliveryMethod>> getAllDeliveryMethods()
    {
        return await Context.deliveryMethods.ToListAsync();
    }

    public async Task<Order?> GetOrderByID(int id)
    {
        return await Context.orders.Include(o => o.User).FirstOrDefaultAsync();
    }

   

    public async Task SaveChanges()
    {
       await Context.SaveChangesAsync();
    }

    public async Task updateOrderState(Order order1)
    {
         Context.orders.Update(order1);
        await Task.CompletedTask;
    }
}
