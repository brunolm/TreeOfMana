using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeOfMana.Dependencies.Models;

namespace TreeOfMana.Data.Models
{
    public abstract class Entity : IEntity
    {
        public int ID { get; set; }
    }
}
