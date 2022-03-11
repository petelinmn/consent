using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consent.Actors.Contract.Requests
{
    public class DecisionsRequest
    {
        public string UserId { get; set; }
        public int? AppId { get; set; }
        public int? FlowId { get; set; }
    }

    public class DecisionsRequest2
    {
        public string UserId { get; set; }
        public string? AppName { get; set; }
        public string FlowName { get; set; }
    }
}
