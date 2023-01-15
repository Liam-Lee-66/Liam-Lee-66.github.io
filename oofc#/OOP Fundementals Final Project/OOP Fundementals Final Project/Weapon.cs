using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class Weapon : Item
    {
        
        public int Damage { get; private set; }
        
        public Weapon(string name, int[] grid, int dmg, int percent) : base(name, grid, percent)
        {
            Damage = dmg;
        }
    }
}
