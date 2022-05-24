using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Entities.Monster
{
    class LootTable
    {
        public Item LootItem;
        public int LootCount;
        public int LootChance;
        public static List<LootTable> MonsterLootTable = new List<LootTable>();
        public LootTable(Item lootItem, int lootCount, int lootChance)
        {
            LootItem = lootItem;
            LootCount = lootCount;  
            LootChance = lootChance;
            RegisterLootTable(this);
        }
        public void RegisterLootTable(LootTable _item)
        {
            MonsterLootTable.Add(_item);
        }
        public void UnRegisterLootTable(LootTable _item)
        {
            MonsterLootTable.Remove(_item);
        }
    }
}
