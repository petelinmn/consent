using Consent.Api.Model;
using Dapr.Actors;

namespace Consent.Actors.Contract
{
    public interface IFlowAccessActor : IActor
    {
        Task<List<Flow>> GetFlows();
        Task<Flow?> GetFlow(int flow_id);
        Task<Flow> AddFlow(Flow flow);
    }
}
