using LearnJohnAThing.Data;
using LearnJohnAThing.Mechanics;
using LearnJohnAThing.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnJohnAThing
{
    class Program
    {
        private static bool _running = true;
        private static Heroes _selectedHero;
        private static List<Heroes> _heroes = new List<Heroes>();
        private static List<Monsters> _monsters = new List<Monsters>();
        private static List<Skill> _skills= new List<Skill>();
        private static List<SaveFile> _saveFiles = new List<SaveFile>();
        private static Monsters _selectedMonster;

        static void Main(string[] args)
        {
            if (NoSaveFiles())
            {
                SeedDb();
            }

            InitializeSaveFiles();
            InitializeSkills();
            InitiateHeroes();
            InitiateMonsters();

            Displays.DisplaySplashScreen();

            LoadData();

            //_hero.Initialize();
            SelectMonster();

            while (_running)
            {
                //Combat.StartBattle(_hero, _monsters[(int)_selectedMonster]);

                Console.Clear();
                Console.WriteLine("Would you like to battle again? (Y/N)");
                Console.WriteLine();
                char answer = Console.ReadKey().KeyChar;

                while (answer != 'y' && answer != 'Y' && answer != 'n' && answer != 'N' && _selectedHero.Health > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Invalid answer!");
                    Console.WriteLine("Would you like to battle again? (Y/N)");
                    Console.WriteLine();
                    answer = Console.ReadKey().KeyChar;
                }

                if (answer == 'y' || answer == 'Y')
                    continue;

                Console.WriteLine("\n\nExiting, press a key to exit...");
                Console.ReadKey();
                _running = false;
            }
        }

        private static bool NoSaveFiles()
        {
            using (var context = new GameDataContext())
            {
                if (context.SaveFile.Any())
                {
                    return false;
                }
            }

            return true;
        }

        private static void SeedDb()
        {
            using (var context = new GameDataContext())
            {
                #region SaveFiles
                var saveFile = new SaveFile
                {
                    Id = new Guid(),
                    LastSavedOn = DateTime.Now,
                };
                context.Add(saveFile);
                #endregion SaveFiles

                #region Heroes
                var basicAttackSkill = new Skill
                {
                    Id = new Guid(),
                    Name = "Basic Attack",
                    Cost = 0,
                    Damage = 2,
                    Accuracy = 1,
                    SaveFile = saveFile,
                };
                context.Add(basicAttackSkill);

                var fireballSkill = new Skill
                {
                    Id = new Guid(),
                    Name = "Fireball",
                    Cost = 2,
                    Damage = 4,
                    Accuracy = 1,
                    SaveFile = saveFile,
                };
                context.Add(fireballSkill);

                var waitSkill = new Skill
                {
                    Id = new Guid(),
                    Name = "Wait",
                    Cost = 0,
                    Damage = 0,
                    Accuracy = 1,
                    SaveFile = saveFile,
                };
                context.Add(waitSkill);

                var endgameSkill = new Skill
                {
                    Id = new Guid(),
                    Name = "Endgame",
                    Cost = 0,
                    Damage = 200,
                    Accuracy = 1,
                    SaveFile = saveFile,
                };
                context.Add(endgameSkill);

                var hero = new Heroes
                {
                    Id = new Guid(),
                    SaveFile = saveFile,
                    Name = "Roland",
                    Health = 10,
                    Mana = 5,
                    Skill1Navigation = basicAttackSkill,
                    Skill2Navigation = fireballSkill,
                    Skill3Navigation = waitSkill,
                    Skill4Navigation = endgameSkill
                };
                context.Add(hero);
                #endregion Heroes

                #region Monsters
                var stab = new Skill
                {
                    Name = "Stab",
                    Cost = 0,
                    Damage = 6,
                    Accuracy = .9,
                    SaveFile = saveFile,
                };
                context.Add(stab);

                var goblin = new Monsters
                {
                    Id = new Guid(),
                    Name = "Goblin",
                    Health = 3,
                    Skill1Navigation = stab,
                };
                context.Add(goblin);

                var rockSlam = new Skill
                {
                    Name = "Rock Slam",
                    Cost = 0,
                    Damage = 2,
                    Accuracy = .7,
                    SaveFile = saveFile,
                };
                context.Add(rockSlam);

                var golem = new Monsters
                {
                    Id = new Guid(),
                    Name = "Golem",
                    Health = 9,
                    Skill1Navigation = rockSlam,
                };
                context.Add(golem);

                var slash = new Skill
                {
                    Name = "Slash",
                    Cost = 0,
                    Damage = 3,
                    Accuracy = .8,
                    SaveFile = saveFile,
                };
                context.Add(slash);

                var skeleton = new Monsters
                {
                    Id = new Guid(),
                    Name = "Skeleton",
                    Health = 7,
                    Skill1Navigation = slash,
                };
                context.Add(skeleton);
                #endregion Monsters

                context.SaveChanges();
            }
        }

        private static void LoadData()
        {
            using (var context = new GameDataContext())
            {
                var heroes = context.Heroes.ToList();
            }
        }

        private static void SelectMonster()
        {
            char answer;

            Console.Clear();
            Console.WriteLine("Select a monster to battle:");

            for (int i = 0; i < _monsters.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {_monsters[i].Name}");
            }
            Console.WriteLine();

            answer = Console.ReadKey().KeyChar;
            while (answer != '1' && answer != '2' && answer != '3')
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Invalid entry!");
                Console.WriteLine("Select a monster to battle:");

                for (int i = 0; i < _monsters.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {_monsters[i].Name}");
                }
                Console.WriteLine();

                answer = Console.ReadKey().KeyChar;
            }

            _selectedMonster = _monsters[int.Parse(answer.ToString()) - 1];
        }

        private static void InitializeSaveFiles()
        {
            using (var context = new GameDataContext())
            {
                context.SaveFile.ToList().ForEach(saveFile =>
                {
                    _saveFiles.Add(saveFile);
                });
            }
        }

        private static void InitializeSkills()
        {
            using (var context = new GameDataContext())
            {
                context.Skill.ToList().ForEach(skill =>
                {
                    _skills.Add(skill);
                });
            }
        }

        private static void InitiateHeroes()
        {
            using (var context = new GameDataContext())
            {
                context.Heroes.ToList().ForEach(hero =>
                {
                    _heroes.Add(hero);
                });

                _selectedHero = _heroes.FirstOrDefault();
            }
        }

        private static void InitiateMonsters()
        {
            using (var context = new GameDataContext())
            {
                context.Monsters.ToList().ForEach(monster =>
                {
                    _monsters.Add(monster);
                });
            }
        }
    }
}
