using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consent.Actors.Contract.Requests
{
    public class ConsentRequest
    {
        public string UserId { get; set; }
        public int FlowId { get; set; }
        public int AppId { get; set; }
        public int PolicyId { get; set; }
    }
}
