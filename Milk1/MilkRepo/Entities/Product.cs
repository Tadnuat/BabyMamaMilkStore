using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? BrandMilkId { get; set; }

    public int? AdminId { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual ICollection<AgeRange> AgeRanges { get; set; } = new List<AgeRange>();

    public virtual BrandMilk? BrandMilk { get; set; }

    public virtual ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
}
