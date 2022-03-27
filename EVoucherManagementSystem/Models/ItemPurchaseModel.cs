using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVoucherManagementSystem.Models
{
    public class ItemPurchaseModel
    {
        public string id { get; set; }
        public string item { get; set; }
        public string promocode { get; set; }
        public int totalamount { get; set; }

        public string userid { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime? updatedDateTime { get; set; } 
    }
}
