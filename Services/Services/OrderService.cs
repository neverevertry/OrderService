using Domain.Entities;
using Domain.Exceptions;
using Domain.Interface;
using Service.Interface;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public async Task<Order> createOrderAsync(Order order)
        {
            var existOrder = await getOrderByIdAsync(order.id);

            if (existOrder == null)
            {
                var newOrder = order.orderProducts.Count <= 0 || order.orderProducts == null
                                                         ? throw new Exception("Список товаров пуст")
                                                         : await _orderRepository.createOrderAsync(order);

                return newOrder;
            }

            throw new OrderAlreadyExistsException();
        }

        public async Task deleteOrderAsync(Guid id)
        {
            var existOrder = await getOrderByIdAsync(id);

            if (existOrder == null)
                throw new OrderNotFoundException(id.ToString());

            await _orderRepository.deleteOrderAsync(existOrder);
        }

        public async Task<Order> getOrderByIdAsync(Guid id)
        {
            var existOrder = await _orderRepository.getOrderByIdAsync(id);

            if (existOrder == null)
                throw new OrderNotFoundException(id.ToString());

            return existOrder;
        }

        public async Task<Order> updateOrderAsync(Order order)
        {
            var existOrder = await getOrderByIdAsync(order.id);

            if (existOrder == null)
                throw new OrderNotFoundException(order.id.ToString());

            if (order.status != existOrder.status && existOrder.status != statusOrder.New)
                throw new CantEditException("статус");

            if (order.Created != existOrder.Created)
                throw new CantEditException("время");

            existOrder.orderProducts = order.orderProducts;
            existOrder.status = order.status;

            return await _orderRepository.updateOrderAsync(existOrder);
        }

    }
}
