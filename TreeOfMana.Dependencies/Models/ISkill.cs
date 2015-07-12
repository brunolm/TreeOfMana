using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeOfMana.Dependencies.Models
{
    public interface ISkill : IEntity
    {
        //IList<Achievement> Achievements { get; set; }

        int Charisma { get; set; }

        string Description { get; set; }

        int Fortitude { get; set; }

        int Intellect { get; set; }

        string Name { get; set; }

        int Order { get; set; }
        ISkill ParentSkill { get; set; }

        int? ParentSkillID { get; set; }

        int Wisdom { get; set; }
    }
}
