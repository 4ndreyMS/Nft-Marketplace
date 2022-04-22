using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class UserR : BaseEntity
    {

        public string Cedula { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nickname { get; set; }
        public string Status { get; set; }
        public int Otp { get; set; }
        public string IdOrganization { get; set; }
        public string Password { get; set; }
        public Company Company { get; set; }
        public string Type { get; set; }

        public UserR()
        {
            UserPassword Password = new UserPassword();
        }
    }
}
