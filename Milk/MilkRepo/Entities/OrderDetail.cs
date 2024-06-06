using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductItemId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public string? OrderDetailStatus { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ProductItem? ProductItem { get; set; }
}
