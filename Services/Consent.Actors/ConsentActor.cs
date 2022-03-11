namespace BlastAce.Actors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Consent.Actors.Contract;
    using Consent.Actors.Contract.Requests;
    using Consent.Actors.DB;
    using Consent.Api.Model;
    using Dapr.Actors;
    using Dapr.Actors.Client;
    using Dapr.Actors.Runtime;
    using Dapr.Client;

    public class ConsentActor : Actor, IConsentActor
    {
        DBRepository _dbRepository;
        DaprClient _daprClient;

        public ConsentActor(ActorHost host, DBRepository dbRepository, DaprClient daprClient)
            : base(host)
        {
            _dbRepository = dbRepository;
            _daprClient = daprClient;
        }

        public async Task<string> Consent(ConsentRequest req)
        {
            var userId = req.UserId ?? Guid.NewGuid().ToString();
            Console.WriteLine(32);
            var policy = await _dbRepository.GetPolicy(req.PolicyId);
            Console.WriteLine(userId);
            var decision = new Decision
            {
                //DateStart = DateTime.Now,
                //DateEnd = DateTime.Now.AddDays(1),
                Policy = policy,
                UserId = userId
            };
            Console.WriteLine(40);
            try
            {
                await _dbRepository.AddDecision(decision);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine(42);
            return decision.UserId;
        }

        public async Task<List<Decision>> GetDecisions(DecisionsRequest req)
        {
            var appPolicies = await _dbRepository.GetAppPolicies();
            var decisions = await _dbRepository.GetDecisions(req.UserId);
            foreach (var decision in decisions)
            {
                appPolicies = appPolicies.Where(ap => !(ap.PolicyId == decision.PolicyId
                    && (ap.AppId == decision.AppId || !decision.AppId.HasValue)
                    && (ap.FlowId == decision.FlowId || !decision.FlowId.HasValue))).ToList();
            }

            return await _dbRepository.GetDecisions(req.UserId);
        }

        public async Task<List<AppPolicy>> GetDecisions2(DecisionsRequest req)
        {
            var appPolicies = await _dbRepository.GetAppPolicies();
            var decisions = await _dbRepository.GetDecisions(req.UserId);
            foreach (var decision in decisions)
            {
                appPolicies = appPolicies.Where(ap => !(ap.PolicyId == decision.PolicyId
                    && (ap.AppId == decision.AppId || !decision.AppId.HasValue)
                    && (ap.FlowId == decision.FlowId || !decision.FlowId.HasValue))).ToList();
            }

            return appPolicies;
        }

        public async Task<List<AppPolicy>> GetDecisions3(DecisionsRequest2 req)
        {
            var appPolicies = await _dbRepository.GetAppPolicies();
            var decisions = await _dbRepository.GetDecisions(req.UserId);
            
            
            if (req.AppName != null)
            {
                var app = await _dbRepository.GetApp(req.AppName);
                decisions = decisions.Where(d => app.Id == d.AppId).ToList();
            }
            if (req.FlowName != null)
            {
                var flow = await _dbRepository.GetFlow(req.FlowName);
                decisions = decisions.Where(d => flow.Id == d.FlowId).ToList();
            }

            foreach (var decision in decisions)
            {
                appPolicies = appPolicies.Where(ap => ap.PolicyId == decision.PolicyId
                    && (ap.AppId == decision.AppId || !decision.AppId.HasValue)
                    && (ap.FlowId == decision.FlowId || !decision.FlowId.HasValue)).ToList();
            }

            return appPolicies;
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
