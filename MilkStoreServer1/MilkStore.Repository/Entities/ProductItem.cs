using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities
{
    public partial class ProductItem
    {
        public int ProductItemId { get; set; }

        public string Benefit { get; set; }

        public string Description { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; } // Discount as a percentage

        public double Weight { get; set; }

        public int BrandMilkId { get; set; }

        public string Baby { get; set; }

        public string Mama { get; set; }

        public string BrandName { get; set; }

        public string CountryName { get; set; }

        public string CompanyName { get; set; }

        public int SoldQuantity { get; set; }

        public int StockQuantity { get; set; }
        public string Delete { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual BrandMilk BrandMilk { get; set; }

        public virtual ICollection<AgeRange> AgeRanges { get; set; }
    }
}