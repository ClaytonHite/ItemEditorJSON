using ItemEditorJSON.Entities.Monster;
using ItemEditorJSON.Items.Equipment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemEditorJSON
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadItems();
        }
        public void LoadItems()
        {
            using (StreamReader file = new StreamReader(@".\ItemsJSON\Ammos.json"))
            {
                string json = file.ReadToEnd();
                Ammo.ammoList = JsonConvert.DeserializeObject<List<Ammo>>(json);
            }
            using (StreamReader file = new StreamReader(@".\ItemsJSON\Armors.json"))
            {
                string json = file.ReadToEnd();
                Armor.Armors = JsonConvert.DeserializeObject<List<Armor>>(json);
            }
            using (StreamReader file = new StreamReader(@".\ItemsJSON\Currency.json"))
            {
                string json = file.ReadToEnd();
                Currency.Currencies = JsonConvert.DeserializeObject<List<Currency>>(json);
            }
            using (StreamReader file = new StreamReader(@".\ItemsJSON\Consumable.json"))
            {
                string json = file.ReadToEnd();
                Consumable.Consumables = JsonConvert.DeserializeObject<List<Consumable>>(json);
            }
            using (StreamReader file = new StreamReader(@".\ItemsJSON\Miscellaneous.json"))
            {
                string json = file.ReadToEnd();
                Miscellaneous.miscellaneousList = JsonConvert.DeserializeObject<List<Miscellaneous>>(json);
            }
            using (StreamReader file = new StreamReader(@".\ItemsJSON\Tools.json"))
            {
                string json = file.ReadToEnd();
                Tool.Tools = JsonConvert.DeserializeObject<List<Tool>>(json);
            }
            using (StreamReader file = new StreamReader(@".\ItemsJSON\Weapons.json"))
            {
                string json = file.ReadToEnd();
                Weapon.Weapons = JsonConvert.DeserializeObject<List<Weapon>>(json);
            }
            RefreshItemListForMonster();
        }
        void RefreshItemListForMonster()
        {
            ItemListBox.Items.Clear();
            Item.ItemList.Sort((x, y) => x.ID.CompareTo(y.ID));
            foreach (Item item in Item.ItemList)
            {
                ItemListBox.Items.Add($"{item.ID} -- Name = {item.Name}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ItemListBox.SelectedIndex >= 0 && ItemListBox.SelectedItem != null)
            {
                new LootTable(Item.ItemList[ItemListBox.SelectedIndex], Convert.ToInt32(MonsterItemDropCountTextBox.Text), Convert.ToInt32(ItemDropPercentage.Text));
                RefreshMonsterLootTable();
            }
        }
        void RefreshMonsterLootTable()
        {
            MonsterLootTable.Items.Clear();
            LootTable.MonsterLootTable.Sort((x, y) => x.LootItem.ID.CompareTo(y.LootItem.ID));
            foreach (LootTable loot in LootTable.MonsterLootTable)
            {
                MonsterLootTable.Items.Add($"ID:{loot.LootItem.ID}, {loot.LootItem.Name}, # = {loot.LootCount}, % = {loot.LootChance}");
            }
        }
    }
}
