namespace Orders.Model
{
    public class Item 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public float Price { get; set; }
    }
}
