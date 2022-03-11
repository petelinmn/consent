//using Consent.Api.DB;
//using Consent.Api.Dto;
//using Consent.Api.Model;
using Consent.Actors.Contract;
using Consent.Api.Model;
using Dapr.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;

namespace Consent.Api.Controllers
{
    [ApiController]
    [Route("service/v1")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }

        [Route("app")]
        [HttpGet]
        public async Task<IEnumerable<App>> Get() =>
            await ActorProxy.Create<IAppAccessActor>(new ActorId("GetAllApps"), "AppAccessActor")
                .GetApps();

        [Route("app/{appId}")]
        [HttpGet]
        public async Task<App?> Get([FromRoute] int appId) =>
            await ActorProxy.Create<IAppAccessActor>(new ActorId($"GetApp_{appId}"), "AppAccessActor")
                .GetApp(appId);

        [Route("app")]
        [HttpPut]
        public async Task<App?> Put([FromBody] App app) =>
            await ActorProxy.Create<IAppAccessActor>(new ActorId($"AddApp_{app?.Name}"), "AppAccessActor")
                .AddApp(app);

        [Route("flow")]
        [HttpGet]
        public async Task<IEnumerable<Flow>> GetFlow() =>
            await ActorProxy.Create<IFlowAccessActor>(new ActorId("GetAllFlows"), "FlowAccessActor")
                .GetFlows();

        [Route("flow/{flowId}")]
        [HttpGet]
        public async Task<Flow?> GetFlow([FromRoute] int flowId) =>
            await ActorProxy.Create<IFlowAccessActor>(new ActorId($"GetFlow_{flowId}"), "FlowAccessActor")
                .GetFlow(flowId);

        [Route("flow")]
        [HttpPut]
        public async Task<Flow?> Put([FromBody] Flow flow) =>
            await ActorProxy.Create<IFlowAccessActor>(new ActorId($"AddFlow_{flow?.Name}"), "FlowAccessActor")
                .AddFlow(flow);

        [Route("policy")]
        [HttpGet]
        public async Task<IEnumerable<Policy>> GetPolicy() =>
            await ActorProxy.Create<IPolicyAccessActor>(new ActorId("GetAllPolicies"), "PolicyAccessActor")
                .GetPolicies();

        [Route("policy/{policyId}")]
        [HttpGet]
        public async Task<Policy?> GetPolicy([FromRoute] int policyId) =>
            await ActorProxy.Create<IPolicyAccessActor>(new ActorId($"GetPolicy_{policyId}"), "PolicyAccessActor")
                .GetPolicy(policyId);

        [Route("policy")]
        [HttpPut]
        public async Task<Policy?> Put([FromBody] Policy policy) =>
            await ActorProxy.Create<IPolicyAccessActor>(new ActorId($"AddPolicy_{policy?.Name}"), "PolicyAccessActor")
                .AddPolicy(policy);

        [Route("decision")]
        [HttpGet]
        public async Task<IEnumerable<Decision>> GetDecision() =>
            await ActorProxy.Create<IDecisionAccessActor>(new ActorId("GetAllDecisions"), "DecisionAccessActor")
                .GetAllDecisions();

        [Route("decision/{decisionId}")]
        [HttpGet]
        public async Task<Decision?> GetDecision([FromRoute] int decisionId) =>
            await ActorProxy.Create<IDecisionAccessActor>(new ActorId($"GetDecision_{decisionId}"), "DecisionAccessActor")
                .GetDecision(decisionId);

        [Route("decision")]
        [HttpPut]
        public async Task<Decision?> Put([FromBody] Decision decision) =>
            await ActorProxy.Create<IDecisionAccessActor>(new ActorId($"AddPolicy"), "DecisionAccessActor")
                .AddDecision(decision);

        [Route("apppolicy")]
        [HttpGet]
        public async Task<IEnumerable<AppPolicy>> GetAppPolicy() =>
            await ActorProxy.Create<IAppPolicyAccessActor>(new ActorId("GetAllPolicies"), "AppPolicyAccessActor")
                .GetAppPolicies();

        [Route("apppolicy/{apppolicyId}")]
        [HttpGet]
        public async Task<AppPolicy?> GetAppPolicy([FromRoute] int appPolicyId) =>
            await ActorProxy.Create<IAppPolicyAccessActor>(new ActorId($"GetPolicy_{appPolicyId}"), "AppPolicyAccessActor")
                .GetAppPolicy(appPolicyId);

        [Route("apppolicy")]
        [HttpPut]
        public async Task<AppPolicy?> Put([FromBody] AppPolicy policy) =>
            await ActorProxy.Create<IAppPolicyAccessActor>(new ActorId($"AddAppPolicy"), "AppPolicyAccessActor")
                .AddAppPolicy(policy);

        /*
        //App
        [HttpGet("app")]
        public async Task<IEnumerable<App>> GetApps()
        {
            return await _repository.GetApps();
        }

        [HttpGet("app/{appId}")]
        public async Task<App?> GetApp([FromRoute] int appId)
        {
            return await _repository.GetApp(appId);
        }

        [HttpPut("app")]
        public async Task<int> AddApp([FromBody] App app)
        {
            return await _repository.AddApp(app);
        }

        //Flow
        [HttpGet("flow")]
        public async Task<IEnumerable<Flow>> GetFlows()
        {
            return await _repository.GetFlows();
        }

        [HttpGet("flow/{flowId}")]
        public async Task<Flow?> GetFlow([FromRoute] int flowId)
        {
            return await _repository.GetFlow(flowId);
        }

        [HttpPut("flow")]
        public async Task<int> AddFlow([FromBody] Flow flow)
        {
            return await _repository.AddFlow(flow);
        }


        //Policy
        [HttpGet("policy")]
        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            return await _repository.GetPolicies();
        }

        [HttpGet("policy/{policyId}")]
        public async Task<Policy?> GetPolicy([FromRoute] int policyId)
        {
            return await _repository.GetPolicy(policyId);
        }

        [HttpPut("policy")]
        public async Task<int> AddPolicy([FromBody] Policy policy)
        {
            return await _repository.AddPolicy(policy);
        }

        //AppPolicy
        [HttpGet("apppolicy")]
        public async Task<IEnumerable<AppPolicy>> GetAppPolicies()
        {
            return await _repository.GetAppPolicies();
        }
        
        [HttpGet("apppolicy/{appPolicyId}")]
        public async Task<AppPolicy?> GetAppPolicy([FromRoute] int appPolicyId)
        {
            return await _repository.GetAppPolicy(appPolicyId);
        }

        [HttpPut("apppolicy")]
        public async Task<int> AddAppPolicy([FromBody] AppPolicyDto policy)
        {
            return await _repository.AddAppPolicy(policy);
        }

        //Decision
        [HttpGet("decision")]
        public async Task<IEnumerable<Decision>> GetDecisions()
        {
            return await _repository.GetDecisions();
        }

        [HttpGet("decision/{decisionId}")]
        public async Task<Decision?> GetDecision([FromRoute] int decisionId)
        {
            return await _repository.GetDecision(decisionId);
        }

        [HttpPut("decision")]
        public async Task<int> AddDecision([FromBody] Decision flow)
        {
            return await _repository.AddDecision(flow);
        }
         */
    }
}