namespace BlastAce.Actors
{
    //using Consent.Actors.DB;
    using Dapr.Client;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new DaprClientBuilder().Build());
            //services.AddSingleton(new DBRepository(new ApplicationContext()));
            services.AddActors(options =>
            {
                //options.Actors.RegisterActor<AppAccessActor>();
                //options.Actors.RegisterActor<FlowAccessActor>();
                //options.Actors.RegisterActor<PolicyAccessActor>();
                //options.Actors.RegisterActor<DecisionAccessActor>();
                //options.Actors.RegisterActor<AppPolicyAccessActor>();
                options.Actors.RegisterActor<TestActor>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapActorsHandlers();
            });
        }
    }
}
