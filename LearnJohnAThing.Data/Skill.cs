using System;
using System.Collections.Generic;

namespace LearnJohnAThing.Data
{
    public partial class Skill
    {
        public Skill()
        {
            HeroesSkill1Navigation = new HashSet<Heroes>();
            HeroesSkill2Navigation = new HashSet<Heroes>();
            HeroesSkill3Navigation = new HashSet<Heroes>();
            HeroesSkill4Navigation = new HashSet<Heroes>();
            MonstersSkill1Navigation = new HashSet<Monsters>();
            MonstersSkill2Navigation = new HashSet<Monsters>();
            MonstersSkill3Navigation = new HashSet<Monsters>();
            MonstersSkill4Navigation = new HashSet<Monsters>();
        }

        public Guid Id { get; set; }
        public Guid SaveFileId { get; set; }
        public string Name { get; set; }
        public int? Cost { get; set; }
        public int Damage { get; set; }
        public double? Accuracy { get; set; }

        public virtual SaveFile SaveFile { get; set; }
        public virtual ICollection<Heroes> HeroesSkill1Navigation { get; set; }
        public virtual ICollection<Heroes> HeroesSkill2Navigation { get; set; }
        public virtual ICollection<Heroes> HeroesSkill3Navigation { get; set; }
        public virtual ICollection<Heroes> HeroesSkill4Navigation { get; set; }
        public virtual ICollection<Monsters> MonstersSkill1Navigation { get; set; }
        public virtual ICollection<Monsters> MonstersSkill2Navigation { get; set; }
        public virtual ICollection<Monsters> MonstersSkill3Navigation { get; set; }
        public virtual ICollection<Monsters> MonstersSkill4Navigation { get; set; }
    }
}
