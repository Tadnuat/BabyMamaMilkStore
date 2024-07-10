using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class Storage
{
    public int StorageId { get; set; }

    public string StorageName { get; set; } = null!;
    public string Delete { get; set; } = null!;

    public virtual ICollection<DeliveryMan> DeliveryMen { get; set; } = new List<DeliveryMan>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
