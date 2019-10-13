namespace LearnJohnAThing.Data
{
    public class Goblin : Monsters
    {
        #region Constructors
        public Goblin()
        {
            this.Name = "Goblin";
            this.MaxHP = 3;
            this.HP = 3;
            //this.Skill1 = new Skill(7);
        }
        #endregion
    }
}
