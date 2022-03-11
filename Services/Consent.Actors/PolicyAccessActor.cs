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

    public class PolicyAccessActor : Actor, IPolicyAccessActor
    {
        DBRepository _dbRepository;
        DaprClient _daprClient;

        public PolicyAccessActor(ActorHost host, DBRepository dbRepository, DaprClient daprClient)
            : base(host)
        {
            _dbRepository = dbRepository;
            _daprClient = daprClient;
        }

        public async Task<Policy> AddPolicy(Policy policy)
        {
            await _dbRepository.AddPolicy(policy);
            return policy;
        }

        public async Task<Policy> GetPolicy(int policyId) =>
            await _dbRepository.GetPolicy(policyId);

        public async Task<List<Policy>> GetPolicies() =>
            await _dbRepository.GetPolicies();

    }
}
