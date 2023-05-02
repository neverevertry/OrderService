using DataAccess.Context;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public EFOrderRepository(ApplicationDbContext context) => _context = context;


        public async Task<Order> createOrderAsync(Order order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task deleteOrderAsync(Order order)
        {
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> getOrderByIdAsync(Guid id) => await _context.orders.Include(x => x.orderProducts)
                                                                                    .FirstOrDefaultAsync(x => x.id == id);


        public async Task<Order> updateOrderAsync(Order order)
        {
            _context.orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
