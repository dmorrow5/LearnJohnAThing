namespace LearnJohnAThing.Data
{
    public interface IMonster
    {
        string Name { get; }
        int MaxHP { get; set; }
        int HP { get; set; }
        Skill Skill1 { get; set; }
        Skill Skill2 { get; set; }
        Skill Skill3 { get; set; }
        Skill Skill4 { get; set; }

        void Reset();
        bool IsAlive();
        void TakeDamage(int damage);
    }
}
