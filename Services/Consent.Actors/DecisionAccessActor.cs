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

    public class DecisionAccessActor : Actor, IDecisionAccessActor
    {
        DBRepository _dbRepository;
        DaprClient _daprClient;

        public DecisionAccessActor(ActorHost host, DBRepository dbRepository, DaprClient daprClient)
            : base(host)
        {
            _dbRepository = dbRepository;
            _daprClient = daprClient;
        }

        public async Task<Decision> AddDecision(Decision decision)
        {
            await _dbRepository.AddDecision(decision);
            return decision;
        }

        public async Task<Decision?> GetDecision(int decisionId) =>
            await _dbRepository.GetDecision(decisionId);

        public async Task<List<Decision>> GetDecisions(string userId) =>
            await _dbRepository.GetDecisions(userId);

        public async Task<List<Decision>> GetAllDecisions() =>
            await _dbRepository.GetAllDecisions();
    }
}
