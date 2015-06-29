using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeOfMana.Dependencies;

namespace TreeOfMana.Services.Tests
{
    [TestClass]
    public class SkillServiceTests
    {
        private CompositionContainer container;

        public SkillServiceTests()
        {
            container = new CompositionContainer(new DirectoryCatalog(".", "*.dll"));
            container.SatisfyImportsOnce(this);
        }

        [TestMethod]
        public void TestMethod1()
        {
            //var xxxx = container.GetExportedValue<IRepository<string>>();
        }
    }
}
