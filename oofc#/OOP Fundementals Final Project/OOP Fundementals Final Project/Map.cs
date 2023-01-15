using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class Map
    {
        public Hero Hero { get; private set; }
        public List<Monster> Monsters { get; private set; }
        public List<Item> Items { get; private set; }

        private int[,] GridMonster = new int[(int)Game.Grids.EdgeGridPositiveX, (int)Game.Grids.EdgeGridPositiveY];
        private int[,] GridItem = new int[(int)Game.Grids.EdgeGridPositiveX, (int)Game.Grids.EdgeGridPositiveY];


        public Map(Hero hero)
        {
            Hero = hero;
            Monsters = new List<Monster>();
            Items = new List<Item>();
        }

        // Marking and Demarking monsters and items
        public void AddMonster(Monster m)
        {
            Monsters.Add(m);
            
            int x = m.Grid[0];
            int y = m.Grid[1];

            GridMonster[x, y] = Monsters.Count;        // adding monster's list order on grid (cabn't do 0) = remember to -1 when returning monster
        }
        public void DemarkMonster(Monster m)        // when monster is defeated
        {
            int x = m.Grid[0];
            int y = m.Grid[1];

            GridMonster[x, y] = -1;                      // make function where null = x on map
        }
        public void AddItem(Item i)
        {
            Items.Add(i);

            int x = i.Grid[0];
            int y = i.Grid[1];

            GridItem[x, y] = Items.Count;             
        }
        public void DemarkItem(Item i)
        {
            int x = i.Grid[0];
            int y = i.Grid[1];

            GridItem[x, y] = -1;                      // make function where null = . on map
        }

        // Functions checking if player is on monster or item
        public Monster ReturnMonsterOnUser()
        {
            Monster monster = null;
            int x = Hero.Grid[0];
            int y = Hero.Grid[1];

            if (GridMonster[x, y] > 0)
            {
                monster = Monsters[GridMonster[x, y] - 1];
            }

            return monster;
        }
        public Item ReturnItemOnUser()
        {
            Item item = null;
            int x = Hero.Grid[0];
            int y = Hero.Grid[1];

            if (GridItem[x, y] > 0)
            {
                item = Items[GridItem[x, y] - 1];
            }

            return item;
        }

        // main public 
        public void PrintMap()
        {
            StringBuilder buildingMap = new StringBuilder();
            for (int y = 0; y < (int) Game.Grids.EdgeGridPositiveY; y++)
            {
                if (y == 0 || y == 15)              // edges
                {
                    buildingMap.Append("*********************************************************");
                }
                else
                {
                    for (int x = 0; x < (int)Game.Grids.EdgeGridPositiveX; x++)
                    {
                        if (x == 0 || x == 56)      // edges
                        {
                            buildingMap.Append("*");
                        }
                        else if (Hero.Grid[0] == x && Hero.Grid[1] == y)        // Player
                        {
                            buildingMap.Append("@");
                        }
                        // Item location if statement
                        else if (GridItem[x, y] > 0)
                        {
                            buildingMap.Append("$");
                        }
                        // Monster location if statements 
                        else if (GridMonster[x, y] > 0)    // Monster is there
                        {
                            buildingMap.Append("?");
                        }
                        else if (GridMonster[x, y] == -1)       // Monster was there = its ded
                        { 
                            buildingMap.Append("x");
                        }
                        // Empty space
                        else 
                        {
                            buildingMap.Append(" ");
                        }
                    }
                }
                buildingMap.Append('\n');
            }
            Console.WriteLine(buildingMap);
        }
    }
}
