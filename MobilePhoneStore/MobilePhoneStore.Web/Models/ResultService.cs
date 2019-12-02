using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneStore.Web
{
    public class ResultService
    {
        public int ErrorCode { get; set; }
        public Status Status { get; set; }
        public object Data { get; set; }
    }
}
