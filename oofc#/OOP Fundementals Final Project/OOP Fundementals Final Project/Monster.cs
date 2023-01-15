using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class Monster : IFightable
    {
        public string Name { get; private set; }    
        public int Strength { get; private set; }
        public int Defence { get; private set; }
        public int OriginalHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int[] Grid { get; private set; }
        public string[] Img { get; private set; }

        public Monster(string name, int strength, int defence, int originalHealth, int[] gridPosition, string img)
        {
            Name = name;
            Strength = strength;
            Defence = defence;
            OriginalHealth = originalHealth;
            CurrentHealth = originalHealth;
            Grid = gridPosition;
            Img = img.Split("\n");
        }

        public void printImg()
        {
            foreach(string str in Img)
            {
                Console.WriteLine(str); 
            }
        }

        // IFightable stuff
        public int ReturnATK()          // functions exist for just in case if i decided to give monsters weapons
        {
            return Strength;
        }
        public void TakeDMG(int incomingDMG)
        {
            if (incomingDMG > Defence)          // no need to care abt incoming dmg if lower than defence
            {
                CurrentHealth -= (incomingDMG - Defence);
            }
        }
        public void Heal(int incomingHeal)
        {
            CurrentHealth += incomingHeal;
        }

    }

    /*
     *  Different Monster ideas:
     *      0 Goblin                        25%                           
     *      1 Skeleton                      25%
     *      2 Slime                         25%
     *      3 WereWolf                      20%
     *      4 Zack? (easter egg monster)     5%
     *          literally just rants at player and get banned for inapproiate behaviour 
     */
}
