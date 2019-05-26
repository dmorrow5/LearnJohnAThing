using System;
using System.Collections.Generic;

namespace LearnJohnAThing.Data
{
    public partial class Monsters
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public Guid? Skill1 { get; set; }
        public Guid? Skill2 { get; set; }
        public Guid? Skill3 { get; set; }
        public Guid? Skill4 { get; set; }

        public virtual Skill Skill1Navigation { get; set; }
        public virtual Skill Skill2Navigation { get; set; }
        public virtual Skill Skill3Navigation { get; set; }
        public virtual Skill Skill4Navigation { get; set; }
    }
}
