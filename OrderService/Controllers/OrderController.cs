using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Services;

namespace OrderService.Controller
{
    [ApiController]
    [Route("[Order]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => _orderService = orderService;

        [HttpGet("/getOrder/{id}")]
        public async Task<OrderDTO> GetOrderById(Guid id)
        {
            var result = await _orderService.getOrderByIdAsync(id);

            return new OrderDTO
            {
                Id = result.id,
                Created = result.Created,
                status = result.status,
                lines = result.orderProducts.Select(x => new Lines
                {
                    Id = x.ProductId,
                    quantity = x.count
                }).ToList()
            };
        }

        [HttpPost]
        [Route("/Create")]
        public async Task<Order> CreateOrder(OrderDTO orderDto)
        {
            Order order = new Order();
            order.id = orderDto.Id;
            order.Created = orderDto.Created;
            order.status = statusOrder.New;
            order.Created = DateTime.UtcNow;
            order.orderProducts = orderDto.lines.Select(x => new OrderProduct
            {
                OrderId = x.Id,
                count = x.quantity,
                ProductId = orderDto.Id
            }).ToList();

            return await _orderService.createOrderAsync(order);
        }

        [HttpPut]
        [Route("/Update")]
        public async Task<Order> UpdateOrder(Order order) => await _orderService.updateOrderAsync(order);

        [HttpDelete]
        [Route("/Delete")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.deleteOrderAsync(id);
            return Ok();
        }
    }
}
