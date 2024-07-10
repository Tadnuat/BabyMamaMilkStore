using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities
{
    public partial class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>(); // Added navigation property
    }
}
