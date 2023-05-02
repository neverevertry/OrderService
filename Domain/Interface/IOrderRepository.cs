using Domain.Entities;

namespace Domain.Interface
{
    public interface IOrderRepository
    {
        Task<Order> getOrderByIdAsync(Guid id);

        Task deleteOrderAsync(Order order);

        Task<Order> updateOrderAsync(Order order);

        Task<Order> createOrderAsync(Order order);
    }
}
