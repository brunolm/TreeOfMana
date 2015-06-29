using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TreeOfMana.Data.Models;
using TreeOfMana.Dependencies;

namespace TreeOfMana.Data
{
    [Export(typeof(IApplicationContext))]
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<SkillSet> SkillSets { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Achievement> Achievements { get; set; }
    }
}
