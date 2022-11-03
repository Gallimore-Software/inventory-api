using InventoryAPI.Models;

namespace InventoryAPI.ViewModels
{
    public class OrderViewModel
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

        public Order ToEntity()
        {
            return new Order
            {
                Id = Id,
                Name = Name,
                Contact = Contact,
                ItemId = ItemId,
                Quantity = Quantity,
                Price = Price,
                Tax = Tax,
                Total = Total
            };
        }
    }

}
