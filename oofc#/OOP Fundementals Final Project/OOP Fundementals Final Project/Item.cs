using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    abstract class Item
    {
        public string Name { get; private set; }
        public int[] Grid { get; private set; }

        /*
         *  Armor = Dodge Percentage
         *  Weapon = Hit Percentage
         *  Potion = Chance of double effect
         */
        public int Percent { get; private set;  }       

        public Item(string name, int[] grid, int percent)
        {
            Name = name;
            Grid = grid;
            Percent = percent;
        }
    }
}
