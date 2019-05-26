using LearnJohnAThing.Characters.Utility;

namespace LearnJohnAThing.Characters.Monsters
{
    public class Goblin : BaseMonster
    {
        #region Constructors
        public Goblin()
        {
            this.Name = "Goblin";
            this.MaxHP = 3;
            this.HP = 3;
            this.Skill1 = new Skill(7);
        }
        #endregion
    }
}
