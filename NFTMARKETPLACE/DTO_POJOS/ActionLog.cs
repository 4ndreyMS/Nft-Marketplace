using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class ActionLog : BaseEntity
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public DateTime ActionDate { get; set; }
        public int UserRole { get; set; }
        public string IdUser { get; set; }

    }
}
