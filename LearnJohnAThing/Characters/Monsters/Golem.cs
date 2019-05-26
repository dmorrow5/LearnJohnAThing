using LearnJohnAThing.Characters.Utility;

namespace LearnJohnAThing.Characters.Monsters
{
    public class Golem : BaseMonster
    {
        #region Constructors
        public Golem()
        {
            this.Name = "Golem";
            this.MaxHP = 9;
            this.HP = 9;
            this.Skill1 = new Skill(1);
        }
        #endregion
    }
}
