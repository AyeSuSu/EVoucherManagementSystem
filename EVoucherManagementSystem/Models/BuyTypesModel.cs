using System;

namespace EVoucherManagementSystem.Models
{
    public class BuyTypesModel
    {
        public string id { get; set; }
        public bool isMyself { get; set; }
        public bool isGiftOthers { get; set; }
        public int eVoucher_maxlimit { get; set; }=0;
        public int giftUser_maxlimit { get; set; } = 0;
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime? updatedDateTime { get; set; } = DateTime.Now;
    }
}
