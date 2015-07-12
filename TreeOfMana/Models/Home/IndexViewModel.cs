using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using TreeOfMana.Dependencies;
using TreeOfMana.Dependencies.Models;

namespace TreeOfMana.Models.Home
{
    [Export]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class IndexViewModel
    {
        private readonly ISkillService skillService;

        [ImportingConstructor]
        public IndexViewModel(ISkillService skillService)
        {
            this.skillService = skillService;
            Skills = skillService.Get().OrderBy(o => o.ParentSkillID);
        }

        public IEnumerable<ISkill> Skills { get; set; }
    }
}