using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TreeOfMana
{
    public static class MefConfig
    {
        public static CompositionContainer Container { get; private set; }

        public static void Register()
        {
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "TreeOfMana*.dll", SearchOption.AllDirectories)
                .Where(o => !o.Replace(AppDomain.CurrentDomain.BaseDirectory, "").Contains(@"obj\"));

            var catalogAggregator = new AggregateCatalog();

            foreach (var file in files)
            {
                catalogAggregator.Catalogs.Add(new AssemblyCatalog(Assembly.LoadFrom(file)));
            }

            Container = new CompositionContainer(catalogAggregator);
        }
    }
}