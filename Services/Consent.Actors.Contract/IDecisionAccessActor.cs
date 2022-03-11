using Consent.Api.Model;
using Dapr.Actors;

namespace Consent.Actors.Contract
{
    public interface IDecisionAccessActor : IActor
    {
        Task<List<Decision>> GetAllDecisions();
        Task<List<Decision>> GetDecisions(string userId);
        Task<Decision?> GetDecision(int decision_id);
        Task<Decision> AddDecision(Decision decision);
    }
}
