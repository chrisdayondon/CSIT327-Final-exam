﻿using Microsoft.VisualBasic;

namespace Orders.Model
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public bool OrderProcessed { get; set; }

        public IEnumerable <Item> Items { get; set; }
    }

}
