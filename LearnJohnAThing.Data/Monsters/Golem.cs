namespace LearnJohnAThing.Data
{
    public class Golem : Monsters
    {
        #region Constructors
        public Golem()
        {
            this.Name = "Golem";
            this.MaxHP = 9;
            this.HP = 9;
            //this.Skill1 = new Skill(1);
        }
        #endregion
    }
}
