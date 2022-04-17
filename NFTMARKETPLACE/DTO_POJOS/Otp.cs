namespace DTO_POJOS
{
    public class Otp : BaseEntity
    {
        public int NumMin { get; set; }
        public int NumMax { get; set; }
        public int Code { get; set; }
        public int Response { get; set; }
    }
}
