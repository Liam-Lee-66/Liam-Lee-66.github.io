using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class Potion : Item
    {
        public string What { get; set; }
        public int Boost { get; set; }

        public Potion (string name, int[] grid, string what, int boost, int percent) : base(name, grid, percent)
        {
            What = what;
            Boost = boost;
        }
    }
}
