using Consent.Api.Model;
using Dapr.Actors;

namespace Consent.Actors.Contract
{
    public interface IAppPolicyAccessActor : IActor
    {
        Task<List<AppPolicy>> GetAppPolicies();
        Task<AppPolicy?> GetAppPolicy(int appPolicyId);
        Task<AppPolicy> AddAppPolicy(AppPolicy appPolicy);
    }
}
