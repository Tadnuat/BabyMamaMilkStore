namespace MilkStore.API.Models.OrderModel
{
    public class RequestUpdateOrderModel
    {
        public int? CustomerId { get; set; }

        public int? DeliveryManId { get; set; }

        public DateTime? OrderDate { get; set; }

        public string ShippingAddress { get; set; } = null!;

        public decimal? TotalAmount { get; set; }

        public int? StorageId { get; set; }

        public string DeliveryName { get; set; } // Thêm DeliveryName cho thông tin đơn vị giao hàng

        public string DeliveryPhone { get; set; } // Thêm PhoneNumber cho số điện thoại liên lạc

        public string PaymentMethod { get; set; } // Thêm PaymentMethod cho phương thức thanh toán

        public string Status { get; set; } // Thêm Status cho trạng thái đơn hàng
    }
}
