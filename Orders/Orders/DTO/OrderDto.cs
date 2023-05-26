using Orders.Model;

namespace Orders.DTO
{
    public class OrderDto 
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public bool OrderProcessed { get; set; }

        public IEnumerable<ItemDto> Items { get; set; }
    }
}
