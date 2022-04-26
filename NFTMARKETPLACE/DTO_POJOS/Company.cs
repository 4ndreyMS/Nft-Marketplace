using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class Company : BaseEntity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string status    { get; set; }
        public DateTime creationDate { get; set; }
        public int walletPin { get; set; }
    }
}
