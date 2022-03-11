using Consent.Api.Model;
using Dapr.Actors;

namespace Consent.Actors.Contract
{
    public interface IPolicyAccessActor : IActor
    {
        Task<List<Policy>> GetPolicies();
        Task<Policy?> GetPolicy(int policy_id);
        Task<Policy> AddPolicy(Policy policy);
    }
}
