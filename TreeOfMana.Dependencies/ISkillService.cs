using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeOfMana.Dependencies
{
    public interface ISkillService : IDisposable
    {
        void Import();

        IEnumerable<Models.ISkill> Get();
    }
}
