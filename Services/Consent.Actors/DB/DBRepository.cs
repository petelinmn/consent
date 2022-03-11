using Consent.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consent.Actors.DB
{
    public class DBRepository
    {
        private readonly ApplicationContext _context;

        public DBRepository(ApplicationContext context)
        {
            _context = context;
        }

        //App
        public async Task<List<App>> GetApps()
        {
            return await _context.Apps.ToListAsync();
        }

        public async Task<App?> GetApp(int app_id)
        {
            return await _context.Apps.FindAsync(app_id);
        }

        public async Task<App?> GetApp(string appName)
        {
            return await _context.Apps.FirstOrDefaultAsync(a => a.Name == appName);
        }

        public async Task<App> AddApp(App app)
        {
            await _context.Apps.AddAsync(app);
            _context.SaveChanges();

            return app;
        }

        //Flow
        public async Task<List<Flow>> GetFlows()
        {
            return await _context.Flows.ToListAsync();
        }

        public async Task<Flow?> GetFlow(int app_id)
        {
            return await _context.Flows.FindAsync(app_id);
        }

        public async Task<Flow?> GetFlow(string flowName)
        {
            return await _context.Flows.FirstOrDefaultAsync(f => f.Name == flowName);
        }

        public async Task<int> AddFlow(Flow app)
        {
            await _context.Flows.AddAsync(app);
            _context.SaveChanges();

            return app.Id;
        }

        //Policy
        public async Task<List<Policy>> GetPolicies()
        {
            return await _context.Policies.ToListAsync();
        }

        public async Task<Policy?> GetPolicy(int app_id)
        {
            return await _context.Policies.FindAsync(app_id);
        }

        public async Task<int> AddPolicy(Policy app)
        {
            await _context.Policies.AddAsync(app);
            _context.SaveChanges();

            return app.Id;
        }

        //AppPolicy
        public async Task<List<AppPolicy>> GetAppPolicies()
        {
            return await _context.AppPolicies
                .Include(ap => ap.Policy)
                .Include(ap => ap.App)
                .Include(ap => ap.Flow)
                .ToListAsync();
        }


        public async Task<AppPolicy?> GetAppPolicy(int app_id)
        {
            return await _context.AppPolicies.FindAsync(app_id);
        }

        public async Task<int> AddAppPolicy(AppPolicy appPolicy)
        {
            await _context.AppPolicies.AddAsync(appPolicy);
            _context.SaveChanges();

            return appPolicy.Id;
        }

        //Decision
        public async Task<List<Decision>> GetDecisions(string userId)
        {
            return await _context.Decisions.Where(user => user.UserId == userId).ToListAsync();
        }

        public async Task<List<Decision>> GetAllDecisions()
        {
            return await _context.Decisions.ToListAsync();
        }

        public async Task<Decision?> GetDecision(int app_id)
        {
            return await _context.Decisions.FindAsync(app_id);
        }

        public async Task<int> AddDecision(Decision app)
        {
            await _context.Decisions.AddAsync(app);
            _context.SaveChanges();

            return app.Id;
        }
    }
}
