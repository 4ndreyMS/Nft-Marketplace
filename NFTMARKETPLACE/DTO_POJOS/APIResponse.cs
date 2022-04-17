using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJO
{
    public class APIResponse
    {

        public object Data { get; set; }
        public string Message { get; set; }

        public string Status { get; set; }
        public string TransacctionDate { get; set; }
    }
}
