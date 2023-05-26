
using Orders.DTO;
using Orders.Model;
using Orders.Repositories;

namespace Orders.Services
{
    public class  OrderService : IOrderService

    {
        private readonly IRepository<Order> _repository;
        public OrderService(IRepository <Order> repository )
        {
            _repository = repository;
        }

        public void AddOrder(CreateOrderDto order)
        {
           
           

            var orderModel = new Order
            {
                DateTime = order.DateTime,
                OrderProcessed = order.OrderProcessed,
                Items = order.Items.Select (i => new Item 
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    OrderId = i.OrderId,
                    Price = i.Price,

                }).ToList(),
            };

            _repository.Add(orderModel);
        }

        public void Delete(int id)
        {
            var desiredOrder = _repository.Get(id);

            if (desiredOrder == null)
            {
                throw new Exception($"No order with id {id} exists.");
            }

            _repository.Delete(desiredOrder);

        }

        public IEnumerable<OrderDto> GetAllOrder()
        {
            var orders = _repository.GetAll();
            return orders.Select(o => new OrderDto
            {
                DateTime = o.DateTime, 
                OrderProcessed = o.OrderProcessed,
                Items = o.Items.Select(i => new ItemDto
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    OrderId =  i.OrderId,
                    Price = i.Price,

                }).ToList(),
            });
        }

        public OrderDto GetOrder(int id)
        {
            var orderModel = _repository.Get(id);
            return new OrderDto
            {
                DateTime = orderModel.DateTime,
                OrderProcessed = orderModel.OrderProcessed,
                Items = orderModel.Items.Select(i => new ItemDto
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    OrderId = i.OrderId,
                    Price = i.Price,
                })

            };
        }

        public OrderDto Update(OrderDto order)
        {
            var desiredOrder = _repository.Get(order.Id);

            if (desiredOrder == null)
            {
                _repository.Add(new Order
                {
                    OrderProcessed = order.OrderProcessed,
                    DateTime = order.DateTime,
                    Items = order.Items.Select(i => new Item
                    {
                        Name= i.Name,
                        Quantity = i.Quantity,
                        OrderId = i.OrderId,
                        Price = i.Price,
                    }).ToList(),
                });
                return order;
            }
            else
            {
                _repository.Update(desiredOrder, new Order
                {
                    DateTime = order.DateTime,
                    OrderProcessed = order.OrderProcessed,
                    Items = order.Items.Select(i => new Item
                    {
                        Name = i.Name,
                        Quantity = i.Quantity,
                        OrderId = i.OrderId,
                        Price = i.Price,
                    }).ToList(),

                });

                return new OrderDto
                {
                   DateTime = desiredOrder.DateTime,
                   OrderProcessed = desiredOrder.OrderProcessed,
                   Items = desiredOrder.Items.Select(i => new ItemDto
                   {
                       Name = i.Name,
                       Quantity = i.Quantity,
                       OrderId = i.OrderId,
                       Price = i.Price,
                   }).ToList(),
                };
            }
        }
    }
}
