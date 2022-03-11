//using Consent.Api.DB;
//using Consent.Api.Dto;
//using Consent.Api.Model;
using Consent.Actors.Contract;
using Consent.Actors.Contract.Requests;
using Consent.Api.Model;
using Dapr.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;

namespace Consent.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        //private readonly IDBRepository _repository;

        public ApiController(ILogger<ApiController> logger/*, IDBRepository repository*/)
        {
            _logger = logger;
            //_repository = repository;
        }

        [HttpGet("app")]
        public async Task<string> GetApps()
        {
            return "Hello";
        }

        [Route("consent")]
        [HttpPost]
        public async Task<string?> Consent([FromBody] ConsentRequest req)
        {
            Console.WriteLine("1");
            var actor = ActorProxy.Create<IConsentActor>(new ActorId($"Consent_{req.UserId ?? "unknown"}"), "ConsentActor");

            Console.WriteLine("2");
            var result = await actor.Consent(req);
            Console.WriteLine("3");
            return "result";
        }

        [Route("decisions/{appId}/{flowId}/{userId}")]
        [HttpGet]
        public async Task<List<Decision>> Decisions([FromRoute] int? appId, [FromRoute] int? flowId, [FromRoute] string userId) =>
            await ActorProxy.Create<IConsentActor>(new ActorId($"Consent_{userId ?? "unknown"}"), "ConsentActor")
                .GetDecisions(new DecisionsRequest
                {
                    AppId = appId,
                    UserId = userId,
                    FlowId = flowId
                });

        [Route("decisions2/{appId}/{flowId}/{userId}")]
        [HttpGet]
        public async Task<List<AppPolicy>> Decisions2([FromRoute] int? appId, [FromRoute] int? flowId, [FromRoute] string userId) =>
            await ActorProxy.Create<IConsentActor>(new ActorId($"Consent_{userId ?? "unknown"}_{flowId ?? 0}"), "ConsentActor")
                .GetDecisions2(new DecisionsRequest
                {
                    AppId = appId,
                    UserId = userId,
                    FlowId = flowId
                });

        [Route("decisions3/{appName}/{flowName}/{userId}")]
        [HttpGet]
        public async Task<List<AppPolicy>> Decisions3([FromRoute] string appName, [FromRoute] string flowName, [FromRoute] string userId) =>
            await ActorProxy.Create<IConsentActor>(new ActorId($"Consent_{userId ?? "unknown"}_{flowName ?? "some"}"), "ConsentActor")
                .GetDecisions3(new DecisionsRequest2
                {
                    AppName = appName,
                    UserId = userId,
                    FlowName = flowName
                });
    }
}