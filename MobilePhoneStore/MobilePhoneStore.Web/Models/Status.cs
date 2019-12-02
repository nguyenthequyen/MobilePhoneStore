using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneStore.Web
{
    public class Status
    {
        public string Type { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
    }
}
