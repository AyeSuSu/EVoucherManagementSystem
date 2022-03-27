using System;

namespace EVoucherManagementSystem.Models
{
    public class PaymentMethodsModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public int discountPercent { get; set; }
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime? updatedDateTime { get; set; } = DateTime.Now;
    }
}
