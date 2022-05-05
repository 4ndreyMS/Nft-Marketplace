using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class Offer : BaseEntity
    {
        public int Id { get; set; }
        public string NFT { get; set; }
        public string BidderID { get; set; }
        public string OwnerID { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
