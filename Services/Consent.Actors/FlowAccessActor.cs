namespace BlastAce.Actors
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Consent.Actors.Contract;
    using Consent.Actors.DB;
    using Consent.Api.Model;
    using Dapr.Actors;
    using Dapr.Actors.Client;
    using Dapr.Actors.Runtime;
    using Dapr.Client;

    public class FlowAccessActor : Actor, IFlowAccessActor
    {
        DBRepository _dbRepository;
        DaprClient _daprClient;

        public FlowAccessActor(ActorHost host, DBRepository dbRepository, DaprClient daprClient)
            : base(host)
        {
            _dbRepository = dbRepository;
            _daprClient = daprClient;
        }

        public async Task<Flow> AddFlow(Flow flow)
        {
            await _dbRepository.AddFlow(flow);
            return flow;
        }

        public async Task<Flow> GetFlow(int flowId) =>
            await _dbRepository.GetFlow(flowId);

        public async Task<List<Flow>> GetFlows() =>
            await _dbRepository.GetFlows();

    }
}
