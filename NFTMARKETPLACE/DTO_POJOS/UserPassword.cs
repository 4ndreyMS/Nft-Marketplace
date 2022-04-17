using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class UserPassword: BaseEntity
    {

        public string Password { get; set; }  
        
        public DateTime DateCreation { get; set; }

        public string Cedula { get; set; }

        public int IdHistorial { get; set; }


        public override string ToString()
        {
            return Password + Environment.NewLine+ DateCreation + Environment.NewLine + Cedula + Environment.NewLine+ IdHistorial + Environment.NewLine;
        }
    }
}
