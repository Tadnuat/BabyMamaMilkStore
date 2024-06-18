using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? DeliveryManId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public decimal? TotalAmount { get; set; }

    public int? StorageId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual DeliveryMan? DeliveryMan { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Storage? Storage { get; set; }
}
