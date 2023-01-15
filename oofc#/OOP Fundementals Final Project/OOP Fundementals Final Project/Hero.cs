using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SD_300___OOP_Fundamentals___Final_Project
{
    internal class Hero : IFightable
    {
        public string Name { get; private set; }
        public int BaseStrength { get; private set; }       
        public int BaseDefence { get; private set; }
        public int OriginalHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public Weapon EquippedWeapon { get; private set; }
        public Armor EquippedArmor { get; private set; }
        public List<Armor> ArmorBag { get; private set; }               // instead of seperate I would've made into one List<Item>
        public List<Weapon> WeaponBag { get; private set; }             // instead of seperate I would've made into one List<Item>
        public int[] Grid { get; private set; }

        public int EncounteredEnemies { get; set; } = 0;                // Num of games --> num of encountered enemies
        public int DefeatedEnemies { get; set; } = 0;                   // Num of wins --> num of defeated enemies
        public int RanAwayFromEnemies { get; set; } = 0;                // etc --> num of ran away from enemies

        public Hero(string name)
        {
            Name = name;                        // I don't think most games allow name changing after start?
            BaseStrength = 4;                   // hardset value depending on game difficulty
            BaseDefence = 5;                    // hardset value depending on game difficulty
            OriginalHealth = 20;
            CurrentHealth = OriginalHealth;     // game just started; must be same as original
            EquippedWeapon = null;              // game just started = null
            EquippedArmor = null;               // game jsu stared = null
            ArmorBag = new List<Armor>();
            WeaponBag = new List<Weapon>();
            Grid = new int[] { 26, 12 };        // default user location
        }

        // required funcitons
        public string ReturnStats()                // ShowStats --> ReturnStats; not hero class' job to print stuff
        {
            return $"HP: {CurrentHealth}/{OriginalHealth}    ATK: {ReturnATK()}    DEF: {ReturnDEF()}";
        }
        public List<Item> ReturnInventory()        // ShowInventory --> ReturnInventory; not hero class' job to print stuff
        {
            List<Item> returning = new List<Item>();

            returning.AddRange(ArmorBag);
            returning.AddRange(WeaponBag);

            return returning;
        }
        public string[] ReturnStatistics()
        {
            return new string[]
            {
                $"Encountered Enemies: {EncounteredEnemies}",
                $"Defeated Enemies: {DefeatedEnemies}",
                $"Ran away from Enemies: {RanAwayFromEnemies}"
            };
        }

        // Equiping & Unequipping stuff
        public void EquipArmor(Armor armor)
        {
            if (EquippedArmor == null)
            {
                EquippedArmor = armor;
                ArmorBag.Remove(armor);
            }
            else
            {
                ArmorBag.Add(EquippedArmor);
                EquippedArmor = armor;
                ArmorBag.Remove(armor);
            }
        }
        public void UnequipArmor()
        {
            if (EquippedArmor != null)
            {
                ArmorBag.Remove(EquippedArmor);
                EquippedArmor = null;
            }
        }
        public void EquipWeapon(Weapon weapon)
        {
            if (EquippedWeapon == null)
            {
                EquippedWeapon = weapon;
                WeaponBag.Remove(weapon);
            }
            else
            {
                WeaponBag.Add(EquippedWeapon);      // need process to bring equipping item back to inventory
                EquippedWeapon = weapon;
                WeaponBag.Remove(weapon);
            }
        }
        public void EquipItem(Item item)
        {
            if (item is Armor)
            {
                EquipArmor((Armor)item);
            }
            else if (item is Weapon)
            {
                EquipWeapon((Weapon)item);
            }
        }
        public void UnequipWeapon()
        {
            if (EquippedWeapon != null)
            {
                WeaponBag.Add(EquippedWeapon);
                EquippedWeapon = null;
            }
        }

        // Inventory Adding and Removing
        public void AddToInventory(Item item)
        {
            if (item is Armor)
            {
                ArmorBag.Add((Armor)item);          // telesense did this not me
            }
            else if (item is Weapon)
            {
                WeaponBag.Add((Weapon)item);        // telesense did this not me
            }
        }
        public void RemoveFromInventoy(Item item)
        {
            if (item is Armor)
            {
                ArmorBag.Remove((Armor)item);       // telesense did this not me
            }
            else if (item is Weapon)
            {
                WeaponBag.Remove((Weapon)item);     // telesense did this not me
            }
        }

        // Player Location 
        public void AddToGrid(int x, int y)
        {
            Grid[0] += x;
            Grid[1] += y;
        }

        // IFightable stuff
        public int ReturnATK()
        {
            if (EquippedWeapon != null)
            {
                return EquippedWeapon.Damage + BaseStrength;
            }
            else
            {
                return BaseStrength;
            }
        }
        public int ReturnDEF()
        {
            if (EquippedArmor != null)
            {
                return EquippedArmor.Defence + BaseDefence;
            }
            else
            {
                return BaseDefence;
            }
        }
        public void TakeDMG(int incomingDMG)
        {
            if (incomingDMG > ReturnDEF())
            {
                CurrentHealth -= (incomingDMG - ReturnDEF());
            }
        }
        public void Heal(int incomingHeal)
        {
            CurrentHealth += incomingHeal;
        }
    }
}
