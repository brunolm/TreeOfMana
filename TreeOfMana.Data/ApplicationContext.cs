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
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Skill> Skills { get; set; }

        public DbSet<Achievement> Achievements { get; set; }

        public bool DeleteDatabase()
        {
            return base.Database.Delete();
        }
    }
}
