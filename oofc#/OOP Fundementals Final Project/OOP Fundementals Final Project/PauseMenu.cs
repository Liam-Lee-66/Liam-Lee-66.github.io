using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class PauseMenu : IPrintingEssentials
    {
        private Hero _hero { get; set; }
        private Game _game { get; set; }

        public PauseMenu(Game game, Hero hero)
        {
            _game = game;
            _hero = hero;
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
        public void PrintLine(string content)
        {
            StringBuilder strBuilder = new StringBuilder();

            PrintStarAtStart();
            strBuilder.Append("    ");
            strBuilder.Append(content);
            AppendEmptyTillEnd(strBuilder);
            Console.Write(strBuilder);
            PrintStarAtEnd();
        }
        private void PrintInventory()
        {
            Console.Clear();

            PrintStarRow();
            PrintHeroStat();
            PrintStarRow();

            if (_hero.ReturnInventory().Count > 0)
            {
                foreach (Item item in _hero.ReturnInventory())
                {
                    PrintLine(item.Name);
                }
            }
            else
            {
                PrintLine("No items to display :(");
            }

            PrintEmptyRow();
            PrintLine("Press any key to return to Menu");
            PrintStarRow();

            Console.ReadKey();      // apparently there's an issue where it prints and immediatly move back to map/fight
            PrintMenu();
        }
        private void PrintOptions(int selected)
        {
            for (int i = 0; i < 4; i++)
            {
                StringBuilder strbuilder = new StringBuilder();

                PrintStarAtStart();
                strbuilder.Append("    ");
                switch (i)
                {
                    case 0:
                        strbuilder.Append("Statistics");
                        break;
                    case 1:
                        strbuilder.Append("Inventory");
                        break;
                    case 2:
                        strbuilder.Append("Resume");
                        break;

                    case 3:
                        strbuilder.Append("Exit Game");
                        break;
                }

                if (i == selected)
                {
                    strbuilder.Append(" <");
                }

                AppendEmptyTillEnd(strbuilder);
                Console.Write(strbuilder.ToString());
                PrintStarAtEnd();
            }
        }
        public void PrintHeroStatistic()
        {
            Console.Clear();

            PrintStarRow();
            PrintHeroStat();
            PrintStarRow();

            if (_hero.ReturnStatistics().Length > 0)
            {
                foreach (string str in _hero.ReturnStatistics())
                {
                    PrintLine(str);
                }
            }
            else
            {
                PrintLine("No info to display :(");     // just in case place holder
            }

            PrintEmptyRow();
            PrintLine("Press any key to return to Menu");
            PrintStarRow();

            Console.ReadKey();      // apparently there's an issue where it prints and immediatly move back to map/fight
            PrintMenu();

        }

        // major code chunk
        private int GettingSelection()
        {
            int selected = 0;
            ConsoleKey input;

            do
            {
                Console.Clear();

                PrintStarRow();
                PrintHeroStat();
                PrintStarRow();
                PrintOptions(selected);
                PrintStarRow();

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
                    selected = 3;
                }
                else if (selected > 3)
                {
                    selected = 0;
                }
            } while (input != ConsoleKey.Enter);

            return selected;
        }

        public void PrintMenu()
        {
            switch (GettingSelection())
            {
                case 0:
                    PrintHeroStatistic();
                    break;

                case 1:
                    PrintInventory();
                    break;

                case 2:
                    // gotta return either Map or Fight
                    // nvm apaprently putting nothing here returns it to game
                    break;

                case 3:
                    // crash game or end it
                    _game.End();
                    break;
            }
        }
    }
}
