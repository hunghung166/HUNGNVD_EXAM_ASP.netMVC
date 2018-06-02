using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamFinal.Startup))]
namespace ExamFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
