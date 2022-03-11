using Consent.Actors.Contract.Requests;
using Consent.Api.Model;
using Dapr.Actors;

namespace Consent.Actors.Contract
{
    public interface ITestActor : IActor
    {
        Task<App> Consent(int test);
    }
}
