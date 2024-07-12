using System;

namespace MilkStore.API.Models.OrderModel
{
    public class RequestCreateOrderModel
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? DeliveryManId { get; set; } = null;
        public DateTime? OrderDate { get; set; } // Chuyển sang DateTime
        public string ShippingAddress { get; set; } = string.Empty;
        public decimal? TotalAmount { get; set; }
        public int? StorageId { get; set; }
        public string DeliveryName { get; set; } = string.Empty; // Đặt giá trị mặc định nếu cần
        public string DeliveryPhone { get; set; } = string.Empty; // Đặt giá trị mặc định nếu cần
        public string PaymentMethod { get; set; } = string.Empty; // Đặt giá trị mặc định nếu cần
        public string Status { get; set; } = string.Empty; // Đặt giá trị mặc định nếu cần
    }
}
