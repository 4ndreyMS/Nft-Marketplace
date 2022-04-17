using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class Prices : BaseEntity
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
    }
}
