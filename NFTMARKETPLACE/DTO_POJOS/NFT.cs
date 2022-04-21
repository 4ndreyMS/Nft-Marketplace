using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class NFT : BaseEntity
    {
        public string Id { get; set; }
        public string NftName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdCollection { get; set; }
        public string IdCreator { get; set; }
        public string IdOwner { get; set; }
        public string Image { get; set; }
        public int IdCategory { get; set; }
        public NFTCollection collection { get; set; }
    }
}
