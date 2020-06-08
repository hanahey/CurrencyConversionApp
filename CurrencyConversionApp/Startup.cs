using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CurrencyConversionApp.Startup))]
namespace CurrencyConversionApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
