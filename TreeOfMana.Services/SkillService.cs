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
        private readonly IApplicationContext context;

        [ImportingConstructor]
        public SkillService(IApplicationContext context)
        {
            this.context = context;
        }

        public void Import()
        {
            #region Skills TXT

            var skillTxt = @"C#
    Expression Trees
    Threads
    Lambda Expressions
    Async
    Extension Methods
    Assemblies & GAC
    Partial
        Classes
        Methods
    Type categories
        Reference
        Value
    Serialization
    Attributes
    Exception
    Logging
    Interfaces
        IEnumerable<T>
        INotifyPropertyChanged
        IDisposable
    Classes
        Nested Classes
        Delegates
        Events
        Properties
            Auto-properties
        Indexed properties
    Struct
    Naming Guidelines
        Capitalization Conventions
        General Naming Guidelines
        Prefixes and Suffixes
        Class Structure
    Reflection
    Unit Test
    Named arguments
    Covariance / Contravariance
    Special Types
        Generics
        Implicitly typed arrays
        Lazy
        ExpandoObject
        Anonymous Types
    Optional Parameters
    var
    dynamic
    File System
        FileInfo
        DirectoryInfo
    Collections
        Linq
        Lists
        Stacks
        Queues
        Arrays
        Dictionary
    6.0
        nameof operator
        Null propagator
        Exception Filters
        Auto-property Initializer
        Default values for getter only property
        Expression-bodied members
        String Interpolation
        Dictionary Initializer";

            #endregion

            var list = skillTxt.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, Skill> dic = new Dictionary<int, Skill>();

            var result = list.Select(o =>
                {
                    Skill parent = null;
                    Skill skill = new Skill { Name = o.Trim() };

                    int depth = o.TakeWhile(c => c == ' ').Count() / 4;

                    if (depth > 0 && dic.TryGetValue(depth - 1, out parent))
                    {
                        skill.ParentSkill = parent;
                    }

                    dic[depth] = skill;

                    return skill;
                });

            this.context.DeleteDatabase();

            this.context.Set<Skill>().AddRange(result);

            this.context.SaveChanges();
        }

        public IEnumerable<ISkill> Get()
        {
            return this.context.Set<Skill>().OrderBy(o => o.Name).ToList();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
