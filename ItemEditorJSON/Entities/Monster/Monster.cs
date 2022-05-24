using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Entities.Monster
{
    class Monster
    {
        int ID;
        string Name;
        string Race;
        int Health;
        int Level;
        int Strength;
        int Dexterity;
        int Intellect;
        int ExperienceGiven;
        int ClassType;
        List<LootTable> LootTable;
        List<Monster> Monsters = new List<Monster>();
        public Monster(int iD, string name, string race, int health, int level, int strength, int dexterity, int intellect, int experienceGiven, int classType, List<LootTable> lootTable)
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
