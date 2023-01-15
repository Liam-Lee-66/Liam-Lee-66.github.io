using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class Armor : Item
    {
        public int Defence { get; private set; }

        public Armor(string name, int[] grid, int defence, int percent) : base(name, grid, percent)
        {
            Defence = defence;
        }
    }
}
