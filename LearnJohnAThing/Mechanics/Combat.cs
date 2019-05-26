using LearnJohnAThing.Characters.Hero;
using LearnJohnAThing.Characters.Monsters;
using LearnJohnAThing.Characters.Utility;
using LearnJohnAThing.Resources;
using System;

namespace LearnJohnAThing.Mechanics
{
    public static class Combat
    {
        public static void StartBattle(Hero hero, IMonster monster)
        {
            monster.Reset();
            Displays.CombatDisplay(hero, monster);

            while (monster.IsAlive() && hero.IsAlive())
            {
                HeroTurn(hero, monster);
                MonsterTurn(hero, monster);
            }

            if (hero.IsAlive())
            {
                Displays.VictoryDisplay();
            }
            else
                Displays.GameOverDisplay();
        }

        private static void HeroTurn(Hero hero, IMonster monster)
        {
            Skill attack = Displays.PlayerSelectAttack(hero);
            Displays.HeroAttack(hero, monster, attack);

        }

        private static void MonsterTurn(Hero hero, IMonster monster)
        {
            if (!monster.IsAlive())
                return;

            Displays.MonsterAttack(hero, monster, monster.Skill1);
        }
    }
}
