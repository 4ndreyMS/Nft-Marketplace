using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class User : BaseEntity
    {

        public string Cedula { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nickname { get; set; }
        public string Status { get; set; }
        public int Otp   {  get; set; }
        public string IdOrganization { get; set;}
        public string Password { get; set; }
        public Company Company { get; set; }
        public string UserPic { get; set;}


        public User()
        {
            UserPassword Password = new UserPassword();
        }
    }
}
