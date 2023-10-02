using Azure;
using E_Commerce.BL.CustomAuthorization;
using E_Commerce.BL.Dtos.OrderDto;
using E_Commerce.BL.IService;
using E_Commerce.DAL.models.order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace E_Commerce_.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]   
        public async Task<IActionResult> GetAllorders()
        {
            return Ok(await orderService.GetAllOrderReadAsync());

        }
        [HttpPost]

        public async Task<IActionResult> CreateOrder(AddOrderDto orderDto)
        {
            await orderService.AddOrderAsync(orderDto);
            return Ok();
        }

        [HttpPatch("{id}")]

        public async Task<IActionResult> updateStatus( int id , [FromBody]JsonPatchDocument<Order> order)
        {
            await orderService.updateOrderstatus(id, order);
            return Ok();
        }

        
        [HttpGet("deliveryMethods")]
        [Authorize]
        public async Task<IActionResult> GetAllDeliveryMethods()
        {
            return Ok(await orderService.GetallDeliveryMethods());
        }


        [HttpGet("getAddressByUserId")]
        public async Task<IActionResult> getAddressFromLastorder([FromQuery]string userId)
        {
            return Ok(await orderService.getAddressFromLastOrder(userId));
        }

    }
}
