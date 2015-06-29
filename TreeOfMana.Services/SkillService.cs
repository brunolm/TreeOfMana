using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeOfMana.Data.Models;
using TreeOfMana.Dependencies;
using TreeOfMana.Dependencies.Models;

namespace TreeOfMana.Services
{
    [Export(typeof(ISkillService))]
    public class SkillService : ISkillService
    {
        private readonly IRepository repository;

        [ImportingConstructor]
        public SkillService(IRepository repository)
        {
            this.repository = repository;
        }

        public void Test()
        {
            var x = this.repository.Get<Skill>();
        }
    }
}
