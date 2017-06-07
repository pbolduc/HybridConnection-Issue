using Hangfire;
using Hangfire.Dashboard;
using Owin;

namespace SimpleWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("db");

            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions { Authorization = new[] { new EveryoneAllowedAuthorizationFilter() } });
        }
    }

    public class EveryoneAllowedAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}