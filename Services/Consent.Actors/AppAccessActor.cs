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

    public class AppAccessActor : Actor, IAppAccessActor
    {
        DBRepository _dbRepository;
        DaprClient _daprClient;

        public AppAccessActor(ActorHost host, DBRepository dbRepository, DaprClient daprClient)
            : base(host)
        {
            _dbRepository = dbRepository;
            _daprClient = daprClient;
        }

        public async Task<App> AddApp(App app)
        {
            await _dbRepository.AddApp(app);
            return app;
        }

        public async Task<App> GetApp(int appId) =>
            await _dbRepository.GetApp(appId);

        public async Task<List<App>> GetApps() =>
            await _dbRepository.GetApps();

    }
}
