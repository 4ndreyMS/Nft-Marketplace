using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_POJOS;

namespace DTO_POJO
{
    public class ApplicationMessage : BaseEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }

    }
}
