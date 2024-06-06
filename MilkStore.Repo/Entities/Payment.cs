using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }
}
