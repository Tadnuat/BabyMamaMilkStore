using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class ProductItem
{
    public int ProductItemId { get; set; }

    public string? Benefit { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string ItemName { get; set; } = null!;
    public decimal? Price { get; set; }

    public double? Weight { get; set; }

    public int? ProductId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product? Product { get; set; }
}
