using Consent.Actors.Contract.Requests;
using Consent.Api.Model;
using Dapr.Actors;

namespace Consent.Actors.Contract
{
    public interface IConsentActor : IActor
    {
        Task<string> Consent(ConsentRequest req);
        Task<List<Decision>> GetDecisions(DecisionsRequest req);
        Task<List<AppPolicy>> GetDecisions2(DecisionsRequest req);
        Task<List<AppPolicy>> GetDecisions3(DecisionsRequest2 req);
    }
}
