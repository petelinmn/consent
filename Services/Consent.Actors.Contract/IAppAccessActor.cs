using Consent.Api.Model;
using Dapr.Actors;

namespace Consent.Actors.Contract
{
    public interface IAppAccessActor : IActor
    {
        Task<List<App>> GetApps();
        Task<App?> GetApp(int app_id);
        Task<App> AddApp(App app);
    }
}
