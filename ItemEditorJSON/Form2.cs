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
        int numberOfMonsterImages = 8;
        public Form2()
        {
            InitializeComponent();
            LoadItems();
            MonsterIDTextBox.Text = "500";
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + MonsterIDTextBox.Text);
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
            if (ItemListBox.SelectedIndex >= 0 && ItemListBox.SelectedItem != null && MonsterItemDropCountTextBox.Text != "" && ItemDropPercentage.Text != "") 
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (MonsterLootTable.SelectedIndex >= 0 && MonsterLootTable.SelectedItem != null)
            {
                LootTable.MonsterLootTable[MonsterLootTable.SelectedIndex].DestroySelf();
            }
            RefreshMonsterLootTable();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                new Monster(Convert.ToInt32(MonsterIDTextBox.Text), MonsterNameTextBox.Text, MonsterRaceTextBox.Text,
                    Convert.ToInt32(MonsterHealthTextBox.Text), Convert.ToInt32(MonsterLevelTextBox.Text),
                    Convert.ToInt32(MonsterStrengthTextBox.Text), Convert.ToInt32(MonsterDexterityTextBox.Text),
                    Convert.ToInt32(MonsterIntellectTextBox.Text), Convert.ToInt32(MonsterXPGivenTextBox.Text),
                    MonsterClassTypeComboBox.Text, LootTable.MonsterLootTable);
            }
            catch
            {
                MessageBox.Show("All Fields were not completed.");
            }
            RefreshMonsterList();
        }
        void RefreshMonsterList()
        {
            MonsterList.Items.Clear();
            Monster.Monsters.Sort((x, y) => x.ID.CompareTo(y.ID));
            foreach (Monster monster in Monster.Monsters)
            {
                MonsterList.Items.Add($"ID: {monster.ID}, Name -- {monster.Name}");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (MonsterList.SelectedIndex >= 0 && MonsterList.SelectedItem != null)
            {
                Monster.Monsters[MonsterList.SelectedIndex].DestroySelf();
            }
            RefreshMonsterList();
        }

        private void button6_Click(object sender, EventArgs e)
        {//save button
            File.Create(@".\ItemsJSON\Monsters.json").Close();
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Monsters.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Monster.Monsters);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {//picturebox button left
            if (Convert.ToInt32(MonsterIDTextBox.Text) <= 500)
            {
                MonsterIDTextBox.Text = $"{numberOfMonsterImages + 500}";
            }
            MonsterIDTextBox.Text = $"{Convert.ToInt32(MonsterIDTextBox.Text) - 1}";
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + MonsterIDTextBox.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {//picturebox button right
            if (Convert.ToInt32(MonsterIDTextBox.Text) >= 500 + numberOfMonsterImages - 1)
            {
                MonsterIDTextBox.Text = $"{499}";
            }
            MonsterIDTextBox.Text = $"{Convert.ToInt32(MonsterIDTextBox.Text) + 1}";
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + MonsterIDTextBox.Text);
        }
    }
}
