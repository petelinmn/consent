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

    public class AppPolicyAccessActor : Actor, IAppPolicyAccessActor
    {
        DBRepository _dbRepository;
        DaprClient _daprClient;

        public AppPolicyAccessActor(ActorHost host, DBRepository dbRepository, DaprClient daprClient)
            : base(host)
        {
            _dbRepository = dbRepository;
            _daprClient = daprClient;
        }

        public async Task<AppPolicy> AddAppPolicy(AppPolicy appPolicy)
        {
            await _dbRepository.AddAppPolicy(appPolicy);
            return appPolicy;
        }

        public async Task<AppPolicy> GetAppPolicy(int appPolicyId) =>
            await _dbRepository.GetAppPolicy(appPolicyId);

        public async Task<List<AppPolicy>> GetAppPolicies() =>
            await _dbRepository.GetAppPolicies();

    }
}
