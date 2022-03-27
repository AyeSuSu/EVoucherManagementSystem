using System;

namespace EVoucherManagementSystem.Models
{
    public class UsersModel
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string phoneNo { get; set; }
        public string password { get; set; }
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime? updatedDateTime { get; set; } = DateTime.Now;
    }
}
