using Orders.DTO;

namespace Orders.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrder();
        OrderDto GetOrder(int id);
        void AddOrder(CreateOrderDto order);
        OrderDto Update(OrderDto order);
        void Delete(int id);
    }
}
