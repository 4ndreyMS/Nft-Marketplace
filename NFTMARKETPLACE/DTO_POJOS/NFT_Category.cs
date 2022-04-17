using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class NFT_Category : BaseEntity
    {
        public string NFTId { get; set; }
        public int CategoryId { get; set; }
    }
}
