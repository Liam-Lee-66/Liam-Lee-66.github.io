using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal interface IPrintingEssentials
    {
        // basics
        void PrintStarRow();
        void PrintStarAtStart();
        void PrintStarAtEnd();
        void AppendEmptyTillEnd(StringBuilder strBuilder);
        void PrintEmptyRow();

        // major
        void PrintLine(string content);
        void PrintHeroStat();
    }
}
