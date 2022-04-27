using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class InfoNFT : BaseEntity
    {
        public string Id { get; set; }
        public string NftName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public string CollectionName { get; set; }
        public string CreatorName { get; set; }
        public string CreatorImage { get; set; }
        public string Image { get; set; }
        
    }
}
