using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryAPI.Models
{
    public partial class Item
    {
        public Item()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
