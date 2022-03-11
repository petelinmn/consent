using System.Runtime.Serialization;

namespace Consent.Api.Model
{
    public class Decision
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "Test";
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? PolicyId { get; set; }
        public Policy Policy { get; set; }
        public int? FlowId { get; set; }
        public Flow? Flow { get; set; }
        public int? AppId { get; set; }
        public App App { get; set; }
    }
}
