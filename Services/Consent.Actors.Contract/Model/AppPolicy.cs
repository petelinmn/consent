namespace Consent.Api.Model
{
    public class AppPolicy
    {
        public int Id { get; set; }
        public int? AppId { get; set; }
        public int? FlowId { get; set; }
        public int? PolicyId { get; set; }
        public App? App { get; set; }
        public Flow? Flow { get; set; }
        public Policy? Policy { get; set; }
    }
}
