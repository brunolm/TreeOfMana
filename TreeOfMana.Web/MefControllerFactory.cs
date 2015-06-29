using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TreeOfMana.Web
{
    public class MefControllerFactory : DefaultControllerFactory
    {
        private readonly CompositionContainer container;

        public MefControllerFactory(CompositionContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            IController result = null;

            var export = container.GetExports(typeof(IController), null, controllerType.FullName)
                .SingleOrDefault();

            if (null != export)
            {
                result = export.Value as IController;
            }

            if (null != result)
            {
                container.SatisfyImportsOnce(result);
            }

            return result;
        }
    }
}
