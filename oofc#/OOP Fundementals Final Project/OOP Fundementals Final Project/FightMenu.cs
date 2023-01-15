using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class FightMenu : IPrintingEssentials
    {
        private Monster _monster { get; set; }
        private Hero _hero { get; set; }

        private Game _gameGame { get; set; }     // NOT MY FAULT NAME IS GAMEGAME TELESENSE DID IT
        private Map _mapMap { get; set; }        // okay this one I did it cuz of consistency
        private PauseMenu _pauseMenu { get; set; }

        public List<string> Logs { get; set; }

        public FightMenu(Monster m, Hero h, Game g, Map mapmap, List<string> logs)
        {
            _monster = m;
            _hero = h;
            _gameGame = g;
            _mapMap = mapmap;
            Logs = logs;
            _pauseMenu = _gameGame.PauseMenu;
        }

        // IPrintingEssentials stuff
        public void PrintStarRow()
        {
            Console.WriteLine("*********************************************************");
        }
        public void PrintStarAtStart()
        {
            Console.Write("*");
        }
        public void PrintStarAtEnd()
        {
            Console.WriteLine("*");
        }
        public void AppendEmptyTillEnd(StringBuilder strBuilder)
        {
            while (strBuilder.Length < (int)Game.Grids.GridPositiveX)      // not 56 cuz star located at 56
            {
                strBuilder.Append(" ");
            }
        }
        public void PrintEmptyRow()
        {
            StringBuilder stringBuilder = new StringBuilder();
            PrintStarAtStart();
            AppendEmptyTillEnd(stringBuilder);
            Console.Write(stringBuilder);
            PrintStarAtEnd();
        }
        public void PrintLine(string content)           // be sure to only use if line cannot be selected
        {
            StringBuilder strBuilder = new StringBuilder();

            PrintStarAtStart();
            strBuilder.Append("    ");
            strBuilder.Append(content);
            AppendEmptyTillEnd(strBuilder);
            Console.Write(strBuilder);
            PrintStarAtEnd();
        }   

        // I'm wondering which one of these two functions below is considered more "efficient"
        // One uses a forloop and the other doens't
        private void PrintMonsterStat()
        {
            StringBuilder monsterStat = new StringBuilder();

            // First line = Monster.Name Print
            PrintLine(_monster.Name);

            // Second line = Monster.CurrentHealth Print
            PrintLine($"HP: {_monster.CurrentHealth}/{_monster.OriginalHealth}    ATK: {_monster.Strength}    DEF: {_monster.Defence}");
        }
        public void PrintHeroStat()
        {
            for (int i = 0; i < 2; i++)
            {
                // Player Info stuff
                if (i == 0)             // Player name
                {
                    PrintLine(_hero.Name);
                }
                else if (i == 1)        // Player stat
                {
                    PrintLine(_hero.ReturnStats());
                }
            }
        }

        private void PrintHeroOptions(int selectedOption)
        {
            StringBuilder stringBuilder = new StringBuilder();


            for (int i = 0; i < 3; i++)
            {
                stringBuilder.Clear();

                PrintStarAtStart();
                stringBuilder.Append("    ");

                switch (i)
                {
                    case 0:
                        stringBuilder.Append("Attack");
                        break;

                    case 1:
                        stringBuilder.Append("Item");
                        break;

                    case 2:
                        stringBuilder.Append("Run");
                        break;
                }

                if (selectedOption == i)
                {
                    stringBuilder.Append(" <");
                }

                AppendEmptyTillEnd(stringBuilder);

                Console.Write(stringBuilder);

                PrintStarAtEnd();
            }
        }
        private void PrintHeroItemOptions(int selectedOption)
        {
            StringBuilder stringBuilder = new StringBuilder();

            List<Item> tems = _hero.ReturnInventory();           // when I get lazy in my language saying "item" I usally say "tem" so here it is

            // Priting all items
            for (int i = 0; i < tems.Count + 3; i++)
            {
                stringBuilder.Clear();

                PrintStarAtStart();
                stringBuilder.Append("    ");

                if (i == tems.Count)
                {
                    stringBuilder.Append("Unequip Weapon");
                }
                else if (i == tems.Count + 1)
                {
                    stringBuilder.Append("Unequip Armor");
                }
                else if (i == tems.Count + 2)
                {
                    stringBuilder.Append("Back");
                }
                else
                {
                    stringBuilder.Append($"{tems[i].Name}");
                }

                // appedning item stat; returning errors
                if (i < tems.Count)
                {
                    stringBuilder.Append("    ");
                    if (tems[i] is Weapon)
                    {
                        Weapon x = (Weapon)tems[i];
                        stringBuilder.Append($"ATK: {x.Damage}");
                    }
                    else if (tems[i] is Armor)
                    {
                        stringBuilder.Append($"DEF: {((Armor)tems[i]).Defence}");
                    }
                }

                // append if on hover
                if (selectedOption == i)
                {
                    stringBuilder.Append(" <");
                }

                AppendEmptyTillEnd(stringBuilder);

                Console.Write(stringBuilder);

                PrintStarAtEnd();
            }

            PrintStarRow();
        }
        private void PrintSectionImg()
        {
            PrintStarRow();

            foreach (string str in _monster.Img)
            {
                PrintLine(str);
            }
            PrintStarRow();
        }

        // Sub Main(?) Print Section
        private void PrintSectionMonster()
        {
            PrintSectionImg();
            PrintMonsterStat();
            PrintStarRow();
        }
        private void PrintSectionTxt(int selected)
        {
            for (int y = 0; y < 7; y++)
            {
                switch (y)
                {
                    case 0:         // print player name
                        // if statement here for colour change
                        PrintHeroStat();        // prints 2 rows
                        y++;
                        break;

                    case 3:         // print options 
                        PrintHeroOptions(selected);     // prints 3 rows
                        y += 2;
                        break;

                    case 6:
                        PrintStarRow();
                        break;

                    default:
                        PrintEmptyRow();
                        break;
                }
            }
        }
        private void PrintSectionLog()
        {
            if (Logs.Count < 5)
            {
                foreach (string str in Logs)
                {
                    PrintLine(str);
                }
            }
            else
            {
                for (int i = Logs.Count - 5; i < Logs.Count; i++)
                {
                    PrintLine(Logs[i]);
                }
            }
            PrintStarRow();
        }

        // Character Attack Section
        private void HeroAttack()
        {
            Logs.Add($"{_hero.Name} attacked {_monster.Name}");

            if (_hero.EquippedWeapon == null)        // since its literal fists, 100% hit chance
            {
                _monster.TakeDMG(_hero.ReturnATK());
                Logs.Add($"Attack was successful");
            }
            else                                    // hit chance vary depending weapon hit %
            {
                if (_gameGame.RNG1(100) <= _hero.EquippedWeapon.Percent)       // missing percentage < attacking percentage
                {
                    _monster.TakeDMG(_hero.ReturnATK());
                    Logs.Add($"{_hero.Name}'s attack was successful");
                }
                // else; user missed their attack lol
                else
                {
                    Logs.Add($"{_hero.Name}'s attack missed");
                }
            }
        }
        private void MonsterAttack()
        {
            Logs.Add($"{_monster.Name} attacked {_hero.Name}");

            if (_hero.EquippedArmor != null)
            {
                if (_gameGame.RNG1(100) <= _hero.EquippedArmor.Percent)      // player dodge chance
                {
                    Logs.Add($"{_hero.Name} dodged the attack");
                }
                else
                {
                    _hero.TakeDMG(_monster.ReturnATK());
                    Logs.Add($"{_monster.Name}'s attack was successful");
                }
            }
            else
            {
                // player dodge chance is 70% default
                if (_gameGame.RNG1(100) <= 70)      // miss
                {
                    Logs.Add($"{_hero.Name} dodged the attack");
                }
                else                                // hit
                {
                    _hero.TakeDMG(_monster.ReturnATK());
                    Logs.Add($"{_monster.Name}'s attack was successful");
                }
            }
        }

        // Main Print Section
        private int PrintWhatDoMenu()
        {
            int selected = 0;

            // Checking and comparing userinput 
            ConsoleKey input;

            do
            {
                Console.Clear();


                // Monster Section
                PrintSectionMonster();

                // log section
                PrintSectionLog();

                // text section
                PrintSectionTxt(selected);

                input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        selected--;
                        break;

                    case ConsoleKey.DownArrow:
                        selected++;
                        break;
                    case ConsoleKey.Escape:
                        _pauseMenu.PrintMenu();
                        break;
                }

                if (selected < 0)
                {
                    selected = 2;
                }
                else if (2 < selected)
                {
                    selected = 0;
                }
            } while (input != ConsoleKey.Enter);

            return selected;
        }
        private int ItemSelcted()
        {
            int selected = 0;

            ConsoleKey input;

            do
            {
                Console.Clear();

                PrintSectionMonster();
                PrintHeroItemOptions(selected);

                input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        selected--;
                        break;

                    case ConsoleKey.DownArrow:
                        selected++;
                        break;
                }

                if (selected < 0)
                {
                    selected = _hero.ReturnInventory().Count + 2;
                }
                else if (_hero.ReturnInventory().Count + 2 < selected)
                {
                    selected = 0;
                }

            } while (input != ConsoleKey.Enter);

            return selected;
        }
        private void ItemMenu()
        {
            int selected = ItemSelcted();

            if (selected == _hero.ReturnInventory().Count)               // unequip weapon
            {
                Logs.Add($"{_hero.Name} unequipped weapon");
                _hero.UnequipWeapon();
            }
            else if (selected == _hero.ReturnInventory().Count + 1)      // unequip weapon
            {
                Logs.Add($"{_hero.Name} unequipped armor");
                _hero.UnequipArmor();
            }
            else if (selected == _hero.ReturnInventory().Count + 2)      // back
            {
                // doign nothing = goes back
            }
            else                                                        // item selected
            {
                Logs.Add($"{_hero.Name} equipped {_hero.ReturnInventory()[selected].Name}");
                _hero.EquipItem(_hero.ReturnInventory()[selected]);
            }
        }

        // Main Public Section
        public void PrintMenu()
        {
            do
            {
                switch (PrintWhatDoMenu())
                {
                    // Attack
                    case 0:
                        // LEEEROOOOY JENKINS
                        HeroAttack();

                        if (_monster.CurrentHealth > 0)      // there was some issue where the monster would attack after its death
                        {
                            MonsterAttack();
                        }
                        break;

                    // Items
                    case 1:
                        // items
                        ItemMenu();
                        break;

                    // Run
                    case 2:
                        // make statistic save number of Run
                        _hero.RanAwayFromEnemies++;

                        // return to map
                        _gameGame.MapMode();
                        break;
                }
            } while (_hero.CurrentHealth > 0 && _monster.CurrentHealth > 0);

            if (_hero.CurrentHealth <= 0)
            {
                // Game over
                _gameGame.End("Game Over");
            }
            else if (_monster.CurrentHealth <= 0)
            {
                // Monster ded
                _mapMap.DemarkMonster(_monster);

                // Make statistic save num of fight won
                _hero.DefeatedEnemies++;

                // return to map
                _gameGame.MapMode();
            }
        }
    }
}
