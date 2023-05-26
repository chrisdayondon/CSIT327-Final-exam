using Orders.Model;

namespace Orders.DTO
{
    public class CreateOrderDto
    {
        

        public DateTime DateTime { get; set; }

        public bool OrderProcessed { get; set; }

        public IEnumerable<ItemDto> Items { get; set; }
    }
}
