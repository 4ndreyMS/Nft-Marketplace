namespace DTO_POJOS
{
    public class Wallet : BaseEntity
    {
        public string Identifier { get; set; }//hexa
        public string CoinName { get; set; }
        public double Amount { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }


    }
}