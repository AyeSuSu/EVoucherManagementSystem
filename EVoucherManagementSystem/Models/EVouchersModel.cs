using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVoucherManagementSystem.Models
{
    public class EVouchersModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime expiryDate { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }
        public string image { get; set; }
        public int amount { get; set; }
        public int quantity { get; set; } = 1;
        public int isActive { get; set; }
        public string user_id { get; set; }
        public string userName { get; set; }

        public string phoneNo { get; set; }

        public string qrCode { get; set; }

        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime? updatedDateTime { get; set; } = DateTime.Now;
    }
}
