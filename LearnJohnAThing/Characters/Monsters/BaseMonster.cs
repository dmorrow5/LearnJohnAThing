using LearnJohnAThing.Characters.Utility;

namespace LearnJohnAThing.Characters.Monsters
{
    public abstract class BaseMonster : IMonster
    {
        #region Properties
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public Skill Skill1 { get; set; } = new Skill();
        public Skill Skill2 { get; set; }
        public Skill Skill3 { get; set; }
        public Skill Skill4 { get; set; }
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
