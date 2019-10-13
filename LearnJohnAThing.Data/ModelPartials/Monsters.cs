namespace LearnJohnAThing.Data
{
    public partial class Monsters
    {
        #region Properties
        public int MaxHP { get; set; }
        public int HP { get; set; }
        #endregion

        #region Methods
        public void Reset()
        {
            this.HP = MaxHP;
        }

        public bool IsAlive()
        {
            return this.HP > 0;
        }

        public void TakeDamage(int damage)
        {
            this.HP -= damage;
        }
        #endregion
    }
}
