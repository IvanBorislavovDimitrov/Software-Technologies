using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookLibraryFinal.Startup))]
namespace BookLibraryFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
