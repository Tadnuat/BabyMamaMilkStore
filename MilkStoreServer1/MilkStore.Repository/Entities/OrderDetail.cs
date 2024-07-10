namespace MilkStore.Repo.Entities
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int? OrderId { get; set; }

        public int? CustomerId { get; set; } // Added CustomerId property

        public int? ProductItemId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public string ItemName { get; set; } = null!;

        public string? Image { get; set; }

        public int? OrderStatus { get; set; }

        public decimal? Discount { get; set; } // Added Discount property

        public int? StockQuantity { get; set; } // Added StockQuantity property

        public virtual Order? Order { get; set; }

        public virtual ProductItem? ProductItem { get; set; }

        public virtual Customer? Customer { get; set; } // Added navigation property
    }
}
