﻿using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? DeliveryManId { get; set; } = null;
        public DateTime? OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? StorageId { get; set; } = null;
        public string DeliveryName { get; set; } = null;
        public string DeliveryPhone { get; set; } = null;
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Delete { get; set; } = null!;

        public virtual Customer Customer { get; set; }
        public virtual DeliveryMan DeliveryMan { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual Storage Storage { get; set; }
    }
}