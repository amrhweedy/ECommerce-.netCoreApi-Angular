using AutoMapper;
using Azure;
using E_Commerce.BL.CusotmException;
using E_Commerce.BL.Dtos.DeliveryMethod;
using E_Commerce.BL.Dtos.OrderDto;
using E_Commerce.BL.IService;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models;
using E_Commerce.DAL.models.order;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo orderRepo;
        private readonly IProductRepo productRepo;
        private readonly IMapper mapper;

        public OrderService(IOrderRepo orderRepo , IProductRepo productRepo , IMapper mapper)
        {
            this.orderRepo = orderRepo;
            this.productRepo = productRepo;
            this.mapper = mapper;
        }

        private  async Task<bool> GetProducts(List<int> ids) 
        {

            List<Product> products=new List<Product>();  

            foreach(var id in ids)
            {
                Product? product =  await productRepo.GetByID(id);
                if(product is not  null)
                {
                    products.Add(product);
                }
            }

             return (products.Count() == ids.Count())? true: false;
                  
        }
        public async Task AddOrderAsync(AddOrderDto? addOrderDto)
        {
            if (addOrderDto == null)
            {
                throw new MyException("the order is not found", 400);

            }
            List<int> PrductsId = addOrderDto.orderItems.Select(p => p.productId).ToList();

            if (await GetProducts(PrductsId) == false)
            {
                throw new MyException("the products are not found", 400);
            }




            double total = 0;
            foreach (var item in addOrderDto.orderItems)
            {
                Product? product = await productRepo.GetByID(item.productId);


                total += item.Quantity * product.Price;

            }


            


            Order order1 = new Order()
            {
                Total = total,
                 Address = addOrderDto.Address ,
                 deliveryMethodId = addOrderDto.deliveryMethodId ,  
                 UserId = addOrderDto.userId ,
                 orderItems=  addOrderDto.orderItems.Select(p=> new productedOrdered
                 {
                     Quantity = p.Quantity,
                     productid= p.productId,
                   
                 }).ToList(),
             };

            #region mapper 
            //Order order = new Order()
            //{
            //    Total = total
            //};

            //  mapper.Map(addOrderDto , order);

            #endregion

            await orderRepo.CreateOrder(order1);
              await orderRepo.SaveChanges();
            
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllOrderReadAsync()
        {
            var orders = await orderRepo.GetAll();

            return orders.Select(o => new OrderReadDto
            {
                Id = o.Id,
                Address = o.Address,
                OrderDate = o.OrderDate,
                OrderedStatus = o.OrderedStatus,
                Total = o.Total,
                userName = o.User?.UserName,
                email = o.User?.Email,

            }) ;
            
        }

       
        public async Task updateOrderstatus(int id, JsonPatchDocument<Order> order)
        {
            Order? order1 = await orderRepo.GetOrderByID(id);
            if (order1 is null )
            {
                throw new MyException("this order is not found", 400);
            }

            order.ApplyTo(order1 );

            await orderRepo.updateOrderState(order1);
            await orderRepo.SaveChanges();

        }

        public async Task<IEnumerable<DeliveryMethodReadDto>> GetallDeliveryMethods()
        {
            var deliveryMethods = await orderRepo.getAllDeliveryMethods();

            return deliveryMethods.Select(d => new DeliveryMethodReadDto
            {
                id = d.id,
                Name = d.Name,
                description = d.description,
                price = d.price,

            });
        }

        public async Task<Address?> getAddressFromLastOrder(string userId)
        {
            if (userId == null)
            {
                throw new MyException("id is not found", 400);
            }
            // check if this user is found or not

            var order = await orderRepo.getAddressFromLastOrder(userId);
            if(order == null)
            {
                throw new MyException("this is no orders for you" , 400);
            }

            return new Address
            {
                firstName = order.Address!.firstName,
                lastName = order.Address!.lastName,
                street = order.Address!.street,
                city = order.Address!.city,
                state = order.Address!.state,
            };
        }
    }
}
