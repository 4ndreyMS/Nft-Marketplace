using System;
using System.Runtime.InteropServices;

namespace DTO_POJOS
{
    public class Auction : BaseEntity
    {
        public int Id { get; set; }
        public string IdOwner { get; set; }
        public string IdBuyer { get; set; }
        public double Amount { get; set; }
        public InfoNFT Nft { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }

    }
}