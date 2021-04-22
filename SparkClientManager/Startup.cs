using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SparkClientManager.Startup))]
namespace SparkClientManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
