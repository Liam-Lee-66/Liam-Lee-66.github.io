using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal interface IFightable
    {
        int ReturnATK();
        void TakeDMG(int incomingDMG);
        void Heal(int incomingHeal);

    }
}
