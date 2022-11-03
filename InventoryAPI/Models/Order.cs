using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryAPI.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public int? ItemId { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Total { get; set; }

        public virtual Item Item { get; set; }
    }
}
