using LearnJohnAThing.Characters.Utility;
using System;

namespace LearnJohnAThing.Characters.Hero
{
    public class Hero
    {
        #region Properties
        private string _name = "Some Dude";
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    this._name = value;
            }
        }

        private int _hp = 20;
        public int HP
        {
            get
            {
                return this._hp;
            }
            set
            {
                this._hp = value;
            }
        }

        private Skill[] _skills = new Skill[4];
        public Skill[] Skills
        {
            get
            {
                return this._skills;
            }
            set
            {
                this._skills = value;
            }
        }
        #endregion

        #region Constructors
        public Hero() {
            this._skills[0] = new Skill();
        }

        public Hero(string name, int hp, Skill[] skills)
        {
            this._name = name;
            this._hp = hp;
            this._skills = skills;
        }
        #endregion

        #region Methods
        public void Initialize()
        {
            Console.Clear();
            Console.Write("Enter your heroes name: ");
            Name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Time to set up your 4 skills. Press a key to continue:");
            Console.ReadKey();

            for (int i = 1; i <= 4; i++)
            {
                string skillName = "skill";
                int skillCost = 3;
                int skillDamage = 5;
                double skillAccuracy = 1;
                char answer;

                Console.Clear();
                Console.WriteLine($"Skill #{i}:");
                Console.WriteLine();
                Console.Write("Skill name: ");
                skillName = Console.ReadLine();

                Console.Write("Skill cost: ");
                while (!int.TryParse(Console.ReadLine(), out skillCost))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input! Please enter an integer");
                    Console.Write("Skill cost: ");
                }

                Console.Write("Skill damage: ");
                while (!int.TryParse(Console.ReadLine(), out skillDamage))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input! Please enter an integer");
                    Console.Write("Skill damage: ");
                }

                Console.Write("Skill accuracy: ");
                while (!double.TryParse(Console.ReadLine(), out skillAccuracy) && skillAccuracy > 0 && skillAccuracy <= 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input! Please enter a value between 0 and 1");
                    Console.Write("Skill accuracy: ");
                }

                Console.WriteLine();
                Console.WriteLine($"Skill #{i} will be named {skillName}, cost {skillCost}, deal {skillDamage}, and have {skillAccuracy * 100}% accuracy.");
                Console.WriteLine("Confirm (Y/N)");
                answer = Console.ReadKey().KeyChar;

                while (answer != 'y' && answer != 'Y' && answer != 'n' && answer != 'N')
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Invalid answer!");
                    Console.WriteLine($"Skill #{i} will be named {skillName} and deal {skillDamage}.");
                    Console.WriteLine("Confirm (Y/N)");
                    answer = Console.ReadKey().KeyChar;
                }

                if (answer == 'y' || answer == 'Y')
                    Skills[i - 1] = new Skill(skillName, skillCost, skillDamage, skillAccuracy);
                else
                    i--;
            }
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
