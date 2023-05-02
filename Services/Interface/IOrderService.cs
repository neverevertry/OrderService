using Domain.Entities;

namespace Service.Interface
{
    public interface IOrderService
    {
        Task<Order> getOrderByIdAsync(Guid id);

        Task<Order> updateOrderAsync(Order order);

        Task deleteOrderAsync(Guid id);

        Task<Order> createOrderAsync(Order order);
    }
}
