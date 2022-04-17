namespace DTO_POJOS
{
    public class Sms
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }

        public string Phone { get; set; }
        public int Token { get; set; }
        public string Message { get; set; }

        public string ServicePath { get; set; }
    }
}
