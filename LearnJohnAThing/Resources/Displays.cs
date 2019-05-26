using LearnJohnAThing.Characters.Hero;
using LearnJohnAThing.Characters.Monsters;
using LearnJohnAThing.Characters.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnJohnAThing.Resources
{
    public static class Displays
    {
        public static void DisplaySplashScreen()
        {
            Console.Clear();
            Console.WriteLine("**************************************");
            Console.WriteLine("**************************************");
            Console.WriteLine("******** Welcome To Your *************");
            Console.WriteLine("*********** First Game ***************");
            Console.WriteLine("**************************************");
            Console.WriteLine("**************************************");
            Console.WriteLine();
            Console.WriteLine("Press a key to continue:");
            Console.ReadKey();
        }

        internal static void VictoryDisplay()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*********** Victory! *****************");
            Console.WriteLine("**************************************");
            
            System.Threading.Thread.Sleep(1500);
        }

        internal static void GameOverDisplay()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*********** Defeat! ******************");
            Console.WriteLine("**************************************");

            System.Threading.Thread.Sleep(1500);
        }

        #region Combat
        public static void HeroAttack(Hero hero, IMonster monster, Skill attack)
        {
            CombatDisplay(hero, monster);
            PlayerAttack(hero, attack);

            System.Threading.Thread.Sleep(1500);

            PlayerAttackDisplay(hero, monster);
            PlayerAttack(hero, attack);

            System.Threading.Thread.Sleep(1500);

            monster.TakeDamage(attack.Damage);
            CombatDisplay(hero, monster);
        }

        public static void MonsterAttack(Hero hero, IMonster monster, Skill attack)
        {
            CombatDisplay(hero, monster);
            MonsterAttack(monster, attack);

            System.Threading.Thread.Sleep(1500);

            MonsterAttackDisplay(hero, monster);
            MonsterAttack(monster, attack);

            System.Threading.Thread.Sleep(1500);

            hero.TakeDamage(attack.Damage);
            CombatDisplay(hero, monster);
        }

            public static void CombatDisplay(Hero hero, IMonster monster)
        {
            Console.Clear();
            Console.WriteLine("**************************************");
            Console.WriteLine("*                              *     *");
            Console.WriteLine("*    *                        ***    *");
            Console.WriteLine("*   ***                       ***    *");
            Console.WriteLine("*   ***                              *");
            Console.WriteLine("**************************************");
            Console.WriteLine();

            HealthDisplay(hero, monster);
        }

        private static void PlayerAttackDisplay(Hero hero, IMonster monster)
        {
            Console.Clear();
            Console.WriteLine("**************************************");
            Console.WriteLine("*        /                      *    *");
            Console.WriteLine("*    *  /                    ()***   *");
            Console.WriteLine("*   ***/                       ***   *");
            Console.WriteLine("*   ***                              *");
            Console.WriteLine("**************************************");
            Console.WriteLine();

            HealthDisplay(hero, monster);
        }

        private static void MonsterAttackDisplay(Hero hero, IMonster monster)
        {
            Console.Clear();
            Console.WriteLine("**************************************");
            Console.WriteLine("*                              *     *");
            Console.WriteLine("*   *                        /***    *");
            Console.WriteLine("*  ***()                    / ***    *");
            Console.WriteLine("*  ***                     /         *");
            Console.WriteLine("**************************************");
            Console.WriteLine();

            HealthDisplay(hero, monster);
        }

        private static void HealthDisplay(Hero hero, IMonster monster)
        {
            Console.WriteLine("**************************************");
            Console.WriteLine($" {hero.Name} HP: {hero.HP}  |  {monster.Name} HP: {monster.HP}");
            Console.WriteLine("**************************************");
        }

        private static void PlayerAttack(Hero hero, Skill attack)
        {
            Console.WriteLine();
            Console.WriteLine("**************************************");
            Console.WriteLine($"{hero.Name} used {attack.Name} for {attack.Damage} damage");
            Console.WriteLine("**************************************");
        }

        private static void MonsterAttack(IMonster monster, Skill attack)
        {
            Console.WriteLine();
            Console.WriteLine("**************************************");
            Console.WriteLine($"{monster.Name} used {attack.Name} for {attack.Damage} damage");
            Console.WriteLine("**************************************");
        }

        public static Skill PlayerSelectAttack(Hero hero)
        {
            char answer;

            Console.WriteLine();
            Console.WriteLine("Select a skill to use:");

            for (int i = 0; i < hero.Skills.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {hero.Skills[i].Name}: {hero.Skills[i].Damage} damage");
            }
            Console.WriteLine();

            answer = Console.ReadKey().KeyChar;
            while (answer != '1' && answer != '2' && answer != '3' && answer != '4')
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Invalid entry!");
                Console.WriteLine("Select a skill to use:");

                for (int i = 0; i < hero.Skills.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {hero.Skills[i].Name}: {hero.Skills[i].Damage} damage");
                }
                Console.WriteLine();

                answer = Console.ReadKey().KeyChar;
            }

            return hero.Skills[int.Parse(answer.ToString()) - 1];
        }
        #endregion
    }
}
