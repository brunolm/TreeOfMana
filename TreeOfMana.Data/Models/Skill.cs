using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeOfMana.Dependencies.Models;

namespace TreeOfMana.Data.Models
{
    public class Skill : Entity, ISkill
    {
        public Skill()
        {
            Achievements = new List<Achievement>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public int Intellect { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }

        public int Fortitude { get; set; }

        public int? ParentSkillID { get; set; }

        public Skill ParentSkill { get; set; }

        public IList<Achievement> Achievements { get; set; }


        ISkill ISkill.ParentSkill
        {
            get
            {
                return ParentSkill;
            }
            set
            {
                ParentSkill = (Skill)value;
            }
        }
    }
}
