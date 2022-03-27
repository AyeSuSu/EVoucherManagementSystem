using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVoucherManagementSystem.Models
{
    public class PurchaseEVouchersModel
    {
        public string id { get; set; }
        public string eVoucher_id { get; set; }
        public string buyType_id { get; set; }
        public string paymentMethod_id { get; set; }
        public int netAmount { get; set; }
        public string promoCode { get; set; }
        public int isUsed { get; set; }
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime? updatedDateTime { get; set; } = DateTime.Now;
    }
}
