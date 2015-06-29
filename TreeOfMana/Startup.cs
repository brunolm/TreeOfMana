using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Mvc;
using TreeOfMana.Web;
using TreeOfMana.Dependencies;

[assembly: OwinStartupAttribute(typeof(TreeOfMana.Startup))]
namespace TreeOfMana
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            MefConfig.Register();

            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(MefConfig.Container));
        }
    }
}
