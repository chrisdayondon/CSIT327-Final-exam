namespace Orders.DTO
{
    public class CreateItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public float Price { get; set; }
    }
}
