using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class Validation: BaseEntity
    {
        public string EmailTo { get; set; }
        public string PhoneTo { get; set; }
        public string Title { get; set; }
        public string Msj { get; set; }
        public int Otp { get; set; }
        public string NFTAsset { get; set; }

    }
}
