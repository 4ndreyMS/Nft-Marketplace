using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class User_Company : BaseEntity
    {
        public int IdUserXCompany { get; set; }
        public string IdUser { get; set; }
        public int IdCompany { get; set; }



        public User_Company()
        {

        }

        public User_Company(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                IdUser = infoArray[0];

                var organizacion = 0;
                if (Int32.TryParse(infoArray[1], out organizacion))
                    IdCompany = organizacion;
                else
                    throw new Exception("Id de organización tiene que ser un número");
            }
            else
            {
                throw new Exception("Debe ingresar todos los valores");
            }

        }
    }
}
