using Consent.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consent.Actors.DB
{
    public interface IDBRepository
    {
        Task<IEnumerable<App>> GetApps();
        Task<App?> GetApp(int app_id);
        Task<int> AddApp(App app);

        /*Task<IEnumerable<Flow>> GetFlows();
        Task<Flow?> GetFlow(int app_id);
        Task<int> AddFlow(Flow app);

        Task<IEnumerable<Policy>> GetPolicies();
        Task<Policy?> GetPolicy(int app_id);
        Task<int> AddPolicy(Policy app);

        Task<IEnumerable<AppPolicy>> GetAppPolicies();
        Task<AppPolicy?> GetAppPolicy(int app_id);
        Task<int> AddAppPolicy(AppPolicyDto appPolicy);

        Task<IEnumerable<Decision>> GetDecisions();
        Task<Decision?> GetDecision(int app_id);
        Task<int> AddDecision(Decision app);*/
    }
}
