using Microsoft.EntityFrameworkCore;
using Orders.Contexts;
using Orders.Model;

namespace Orders.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
            
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            return _context.Orders
                .Where(p => p.Id == id)
                .Include(p => p.Items) 
                .FirstOrDefault();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
               .Include(p => p.Items) 
               .ToList();
        }

        public void Update(Order order, Order updatedOrder)
        {
            order.DateTime = updatedOrder.DateTime;
            order.OrderProcessed = updatedOrder.OrderProcessed;
            order.Items = updatedOrder.Items;


            _context.SaveChanges();
        }
    }
}
