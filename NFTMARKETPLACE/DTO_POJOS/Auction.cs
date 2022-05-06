using System;
using System.Runtime.InteropServices;

namespace DTO_POJOS
{
    public class Auction : BaseEntity
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Buyer { get; set; }
        public double Amount { get; set; }
        public NFTC Nft { get; set; }
        public DateTime EndDate { get; set; }
    }
}