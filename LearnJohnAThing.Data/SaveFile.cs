using System;
using System.Collections.Generic;

namespace LearnJohnAThing.Data
{
    public partial class SaveFile
    {
        public SaveFile()
        {
            Heroes = new HashSet<Heroes>();
            Skill = new HashSet<Skill>();
        }

        public Guid Id { get; set; }
        public DateTime LastSavedOn { get; set; }

        public virtual ICollection<Heroes> Heroes { get; set; }
        public virtual ICollection<Skill> Skill { get; set; }
    }
}
