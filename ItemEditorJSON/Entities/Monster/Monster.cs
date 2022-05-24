using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Entities.Monster
{
    public class Monster
    {
        public int ID;
        public string Name;
        string Race;
        int Health;
        int Level;
        int Strength;
        int Dexterity;
        int Intellect;
        int ExperienceGiven;
        string ClassType;
        List<LootTable> LootTable;
        public static List<Monster> Monsters = new List<Monster>();
        public Monster(int iD, string name, string race, int health, int level, int strength, int dexterity, int intellect, int experienceGiven, string classType, List<LootTable> lootTable)
        {
            ID = iD;
            Name = name;
            Race = race;
            Health = health;
            Level = level;
            Strength = strength;
            Dexterity = dexterity;
            Intellect = intellect;
            ExperienceGiven = experienceGiven;
            ClassType = classType;
            LootTable = lootTable;
            RegisterMonster(this);
        }
        public void DestroySelf()
        {
            UnRegisterMonster(this);
        }
        public void RegisterMonster(Monster _Monster)
        {
            Monsters.Add(_Monster);
        }
        public void UnRegisterMonster(Monster _Monster)
        {
            Monsters.Remove(_Monster);
        }
    }
}
