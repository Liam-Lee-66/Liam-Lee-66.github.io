using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class Game
    {
        private Hero _hero { get; set; }
        private List<Monster> _monsters { get; set; }
        private List<Item> _items { get; set; }
        private Map _map { get; set; }
        public PauseMenu PauseMenu { get; private set; }
        private List<string> _logs { get; set; }

        public enum Grids         // FightMenu, Map needs access
        {
            EdgeGridPositiveX = 57,            // full Positive X
            EdgeGridPositiveY = 16,         
            EdgeGridNegativeXY = 0,

            GridPositiveX = 55,
            GridPositiveY = 14,
            GridNegativeXY = 1
        }

        public Game()
        {
            _hero = new Hero(AskForName());                         
            _map = new Map(_hero);
            _items = new List<Item>();
            _monsters = new List<Monster>();
            PauseMenu = new PauseMenu(this, _hero);
            _logs = new List<string>();
        }

        // unique stuff
        private string AskForName()                 // NEED VALIDATION; made it
        {
            string input = "NULL";
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("Enter Name:");
                Console.Write("> ");

                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Name is empty. Try again.");
                }
            }

            return input;
        }
        private void PrintHeroStatistic()
        {
            foreach (string str in _hero.ReturnStatistics())
            {
                Console.WriteLine($"{str}");    
            }
        }

        // RNGs; all other needs access?
        public int RNG0(int numOfChance)            // start count from 0
        {
            Random random = new Random();
            return random.Next(numOfChance);
        }
        public int RNG1(int numOfChance)            // start count from 1
        {
            return RNG0(numOfChance) + 1;
        }

        // Creating Monsters
        // Here you can modify, add or remove Monsters
        // Not the greatest way to create things I think?   
        private void CreateRandomMonster()
        {
            int[] newGridPos = new int[] { RNG1((int)Grids.GridPositiveX), RNG1((int)Grids.GridPositiveY) };

            Monster newM = null;
            int RN = RNG0(100);


            // Frog 25%   
            if (RN < 25)
            {
                newM = new Monster("Frog", 7, 3, 20, newGridPos,
                    "▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░▒▒░░░░░░░░▒▒▒▒\n▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒░░░░░░░░░░▒▒\n▒▒▒▒░░░░░░░░░░░░░░░░░░▒▒░░░░░░░░░░\n▒▒░░░░░░░░░░      ██  ▒▒      ██  \n░░░░░░░░░░░░░░    ████▒▒▒▒    ████\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n░░░░░░░░▒▒▒▒██████████████████████\n░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒\n▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒");
            }

            // Skeleton 25%
            else if (RN < 50)
            {
                newM = new Monster("Skeleton", 10, 0, 5, newGridPos,
                    "░░░░░░▄▄▄░░▄██▄░░░\n░░░░░▐▀█▀▌░░░░▀█▄░░░\n░░░░░▐█▄█▌░░░░░░▀█▄░░\n░░░░░░▀▄▀░░░▄▄▄▄▄▀▀░░\n░░░░▄▄▄██▀▀▀▀░░░░░░░\n░░░█▀▄▄▄█░▀▀░░\n░░░▌░▄▄▄▐▌▀▀▀░░\n▄░▐░░░▄▄░█░▀▀ ░░\n▀█▌░░░▄░▀█▀░▀ ░░\n░░░░░░░▄▄▐▌▄▄░░░\n░░░░░░░▀███▀█░▄░░\n░░░░░░▐▌▀▄▀▄▀▐▄░░\n░░░░░░▐▀░░░░░░▐▌░░\n░░░░░░█░░░░░░░░█░░░");
            }

            // Slime 25%
            else if (RN < 75)
            {
                newM = new Monster("Slime", 4, 5, 20, newGridPos,
                    "          ██████████\n      ████░░░░░░░░░░████\n    ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██\n  ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██\n  ██▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒▒██\n██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒██\n██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒██\n██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██\n██▒▒▒▒▒▒▒▒██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒██\n██▓▓▒▒▒▒▒▒▒▒██████▒▒▒▒▒▒▒▒▓▓██\n  ██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██\n    ██████████████████████");
            }

            // Ogre 20%
            else if (RN < 95)
            {
                newM = new Monster("Ogre", 13, 5, 30, newGridPos,
                    "                      _____\n                   ,-'     `._\n                 ,'           `.        ,-.\n               ,'               |       ),.\n     ,.       /                  |     /(  |;\n    /'||     ,o.        ,ooooo.   |  ,'  `-')\n    )) )'. d8P\"\"Y8.    ,8P\"\"\"\"Y8.  `'  .--\"\"'\n   (`-'   `Y'  `Y8    dP       `'     /\n    `----.(   __ `    ,' ,---.       (\n           ),--.`.   (  ;,---.        )\n          / |O_,' )   |  |O_,'        |\n         ;  `-- ,'       `---'        |\n         |    -'         `.           |\n        _;    ,            )          :");
            }

            // Zacharias the Pissed 5%
            else if (RN < 100)
            {
                newM = new Monster("Zacharias the not so Angy", 50, 50, 50, newGridPos,
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&#BGPPP5YYJYG#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&BBGGGGGGGGP5YYYJJJ?Y#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@####&&&###BPYJ7!!~~~~^!?J5P#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&BBGGP5?!~~^^^^^~!!!!!?Y5G@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&GJ7!~~~~^^^7!~~^^~~~JP#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BP5YJ!~~~^^^:^^^^::^^~JP@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BY7!!!!7!~^:^!~JP?. ^~~?GBBB&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&57?!!!^~?7~^^~^?5J:.^^^^^~!7?P@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&PPJ!PB? ~J7~^^^:::^^^^^~~^^^!J@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BP5J?7~^?5Y?77~:::^^^^~~~^::?&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&PYJ?77J5P5J!~^:::^~~~~~~~7J&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#BBGPYJJJJY5Y??JYYY7^^~~~~~Y@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#BBBBBPYJ?J5PG##&&&&5^~~~!!5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&##BGGP5YYYYYB##GPPP^^~!!!5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&& &#BP5YJJJJJ?77!~^~!!~5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&BPPPPP55Y?!~~!7!~~5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BPGGGPPYJ ???7!~^.:B@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#GBPPPGBBGP5J?7?JY5? .7G@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&BPYJJJYB###BBGPYJJYP####B~ ::!JP#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&P7!7?7?YPBPGPGBGGPPGB###B#B?.^:. ::?&@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@P7!~~!??J5PBBGGGYJ7:::^7YGGGB7:^:::^::~B@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@B7~~~~~!YYY5GGGPJ!^~~:^^^^^!!^^^^^:^~^:^:^5@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&Y^^!!~^^!Y5YY5J7!~~~~::^^^^^^~^:^^^^~!~::::.J@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@G7 ^^^~77~!Y5YJ?777777!~~~~~~~~~~!!!!!7777^:::::Y@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@5~!~~~~!?!JPYYJ???777??!?J777777!!!!!!!7??~^^^^^^P@@@@@@@@@@@@@@@@@@@@@@@");
            }


            _monsters.Add(newM);            // no worries it can't be null 
            _map.AddMonster(newM);
        }
        private void CreateBoss()
        {
            Monster Zack = new Monster("Zacharias the Angy", 100, 100, 100, new int[] { RNG1((int)Grids.GridPositiveX), RNG1((int)Grids.GridPositiveY) },
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&#BGPPP5YYJYG#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&BBGGGGGGGGP5YYYJJJ?Y#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@####&&&###BPYJ7!!~~~~^!?J5P#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&BBGGP5?!~~^^^^^~!!!!!?Y5G@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&GJ7!~~~~^^^7!~~^^~~~JP#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BP5YJ!~~~^^^:^^^^::^^~JP@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BY7!!!!7!~^:^!~JP?. ^~~?GBBB&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&57?!!!^~?7~^^~^?5J:.^^^^^~!7?P@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&PPJ!PB? ~J7~^^^:::^^^^^~~^^^!J@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BP5J?7~^?5Y?77~:::^^^^~~~^::?&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&PYJ?77J5P5J!~^:::^~~~~~~~7J&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#BBGPYJJJJY5Y??JYYY7^^~~~~~Y@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#BBBBBPYJ?J5PG##&&&&5^~~~!!5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&##BGGP5YYYYYB##GPPP^^~!!!5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&& &#BP5YJJJJJ?77!~^~!!~5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&BPPPPP55Y?!~~!7!~~5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BPGGGPPYJ ???7!~^.:B@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#GBPPPGBBGP5J?7?JY5? .7G@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&BPYJJJYB###BBGPYJJYP####B~ ::!JP#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&P7!7?7?YPBPGPGBGGPPGB###B#B?.^:. ::?&@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@P7!~~!??J5PBBGGGYJ7:::^7YGGGB7:^:::^::~B@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@B7~~~~~!YYY5GGGPJ!^~~:^^^^^!!^^^^^:^~^:^:^5@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&Y^^!!~^^!Y5YY5J7!~~~~::^^^^^^~^:^^^^~!~::::.J@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@G7 ^^^~77~!Y5YJ?777777!~~~~~~~~~~!!!!!7777^:::::Y@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@5~!~~~~!?!JPYYJ???777??!?J777777!!!!!!!7??~^^^^^^P@@@@@@@@@@@@@@@@@@@@@@@");
            _monsters.Add(Zack);
            _map.AddMonster(Zack);
        }
        private void MonsterSetup()
        {
            for (int i = 0; i < 10; i++)  // 10 = max num of monsters
            {
                CreateRandomMonster();
            }
            CreateBoss();
        }

        // Creating Items
        // Here you can modify, add or remove items 
        private void CreateRandomArmor()
        {
            int[] newGridPos = new int[] { RNG1(55), RNG1(14) };
            Armor armor = null;

            /*
             *  Imma have some fun here
             *  Although this game is seriously dependent on weapons to defeat bosses
             *  I think it would be funny if there was a small chance where the boss is literally unbeatable
             *  due to the bad items randomly getting generated lol
             */
            switch (RNG0(4))
            {
                // Leather Armor
                case 0:
                    armor = new Armor("Leather Armor", newGridPos, 3, 65);
                    break;

                // Chainmail Armor
                case 1:
                    armor = new Armor("Chainmail Armor", newGridPos, 5, 65);
                    break;

                // Iron Armor
                case 2:
                    armor = new Armor("Iron Armor", newGridPos, 10, 50);
                    break;

                // Le Chonk Armor
                case 3:
                    armor = new Armor("Le Chonk Armor", newGridPos, 85, 0);
                    break;
            }

            _items.Add(armor);
            _map.AddItem(armor);
        }
        private void CreateRandomWeapon()
        {
            int[] newGridPos = new int[] { RNG1(55), RNG1(14) };
            Weapon weapon = null;

            /*
             *  Imma have some fun here
             *  Although this game is seriously dependent on weapons to defeat bosses
             *  I think it would be funny if there was a small chance where the boss is literally unbeatable
             *  due to the bad items randomly getting generated lol
             */
            switch (RNG0(4))
            {
                // Wooden Bat
                case 0:
                    weapon = new Weapon("Wooden Bat", newGridPos, 3, 100);
                    break;

                // Sharp Icicle = replaced Rusty sword (high return item but "one use"),    couldn't implement that
                // 
                case 1:
                    weapon = new Weapon("Sharp Icicle", newGridPos, 5, 90);
                    break;

                // Iron Sword
                case 2:
                    weapon = new Weapon("Iron Sword", newGridPos, 10, 75);
                    break;

                // Gun
                case 3:
                    weapon = new Weapon("Colt 45", newGridPos, 150, 25);
                    break;
            }

            _items.Add(weapon);
            _map.AddItem(weapon);
        }
        private void CreateRandomPotion()
        {
            int[] newGridPos = new int[] {RNG1((int)Grids.GridPositiveX), RNG1((int)Grids.GridPositiveY) };

            switch (RNG0(3))
            {
                case 0:

                    break;

                case 1:

                    break;

                case 2:

                    break;
            }
        }
        private void ItemsSetup()
        {
            for (int i = 0; i < 4; i++)
            {
                CreateRandomArmor();
                CreateRandomWeapon();
                // CreateRandomPotion();
            }
        }


        // Game Modes
        public void MapMode()           // FightMenu needs access to it
        {

            ConsoleKey input;

            do
            {
                Console.Clear();

                _map.PrintMap();

                input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        if (_hero.Grid[1] > (int)Grids.GridNegativeXY)
                        {
                            _hero.AddToGrid(0, -1);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (_hero.Grid[1] < (int)Grids.GridPositiveY)
                        {
                            _hero.AddToGrid(0, 1);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (_hero.Grid[0] < (int)Grids.GridPositiveX)
                        {
                            _hero.AddToGrid(1, 0);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (_hero.Grid[0] > (int)Grids.GridNegativeXY)
                        {
                            _hero.AddToGrid(-1, 0);
                        }
                        break;
                    case ConsoleKey.Escape:
                        PauseMenu.PrintMenu();
                        break;
                }

                // if statement for picking up item
                if (_map.ReturnItemOnUser() != null)
                {
                    _logs.Add($"{_hero.Name} picked up {_map.ReturnItemOnUser().Name}");
                    _hero.AddToInventory(_map.ReturnItemOnUser());
                    _map.DemarkItem(_map.ReturnItemOnUser());
                }
            } while (_map.ReturnMonsterOnUser() == null);


            _logs.Add($"{_hero.Name} encountered {_map.ReturnMonsterOnUser().Name}");
            FightMode(_map.ReturnMonsterOnUser());

        }
        private void FightMode(Monster emeny)
        {
            Console.Clear();

            // Make statistic save num of fight encounter
            _hero.EncounteredEnemies++;

            FightMenu fightMenu = new FightMenu(_map.ReturnMonsterOnUser(), _hero, this, _map, _logs);
            fightMenu.PrintMenu();           // Player should be able to access 
        }

        // START FUNCTION
        public void Start()
        {
            MonsterSetup();
            ItemsSetup();
            MapMode();                  // pause menu need to check for input during MapMode() & FightMode()
        }
        public void End(string extraMessage ="")
        {
            Console.Clear();

            if (extraMessage.Count() > 0)
            {
                Console.WriteLine(extraMessage);
                Console.WriteLine();
            }

            // PauseMenu.PrintHeroStatistic(); won't work need alternative version
            PrintHeroStatistic();
            Console.WriteLine();
            Console.WriteLine("Thanks for playing!");

            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
