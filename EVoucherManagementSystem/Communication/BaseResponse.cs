namespace EVoucherManagementSystem.Communication
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public object error { get; set; }
    }
    public class BaseResponsePromoCode
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string promocode { get; set; }
        public object error { get; set; }
    }
    public class ResponsePaging
    {
        public int page { get; set; }
        public int count { get; set; }
        public int total_page { get; set; }
        public int total_count { get; set; }
    }


    public class ResponseModel
    {
        public bool success { get; set; }
        public bool error { get; set; }
        public bool warning { get; set; }
        public string message { get; set; }
    }
}
