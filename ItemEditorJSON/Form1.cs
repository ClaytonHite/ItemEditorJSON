using ItemEditorJSON.Items.Equipment;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
    public partial class Form1 : Form
    {
        int numberOfImages = 37;
        public Form1()
        {
            InitializeComponent();
            ImageNumberTextBox.Text = "1";
            WeaponPanel.Hide();
            ArmorPanel.Hide();
            ConsumablePanel.Hide();
            AmmoPanel.Hide();
            ToolPanel.Hide();
            CurrencyPanel.Hide();
            ImageNumberTextBox.Text = "1000";
            ItemIDTextBox.Text = ImageNumberTextBox.Text;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + ImageNumberTextBox.Text);
        }
        private void CurrentLoadedItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentLoadedItemsListBox.SelectedIndex < Item.ItemList.Count && CurrentLoadedItemsListBox.SelectedIndex >= 0)
            {
                Item SelectedItem = Item.ItemList[CurrentLoadedItemsListBox.SelectedIndex].Clone();
                string itemType = SelectedItem.ItemType;
                ItemIDTextBox.Text = $"{SelectedItem.ID}";
                ArticleTextBox.Text = $"{SelectedItem.Article}";
                ItemNameTextBox.Text = $"{SelectedItem.Name}";
                ItemTypeDropdownBox.Text = $"{SelectedItem.ItemType}";
                ImageNumberTextBox.Text = $"{SelectedItem.ImageNumber}";
                ItemWeightTextBox.Text = $"{SelectedItem.Weight}";
                StackableBoolean.Checked = SelectedItem.Stackable;
                pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + ImageNumberTextBox.Text);
                switch (itemType)
                {
                    case "Ammo":
                        AmmoPanel.Show();
                        ArmorPanel.Hide();
                        CurrencyPanel.Hide();
                        ConsumablePanel.Hide();
                        ToolPanel.Hide();
                        WeaponPanel.Hide();
                        Ammo DisplayAmmo = Ammo.GetAmmo(SelectedItem.ID);
                        DamageAmountTextBox.Text = $"{DisplayAmmo.Damage}";
                        AmmoPriceTextBox.Text = $"{DisplayAmmo.Price}";
                        break;
                    case "Armor":
                        AmmoPanel.Hide();
                        ArmorPanel.Show();
                        CurrencyPanel.Hide();
                        ConsumablePanel.Hide();
                        ToolPanel.Hide();
                        WeaponPanel.Hide();
                        Armor DisplayArmor = Armor.GetArmor(SelectedItem.ID);
                        ArmorTypeComboBox.Text = $"{DisplayArmor.ArmorType}";
                        ArmorPriceTextBox.Text = $"{DisplayArmor.Price}";
                        ArmorAmountTextBox.Text = $"{DisplayArmor.ArmorAmount}";
                        break;
                    case "Currency":
                        AmmoPanel.Hide();
                        ArmorPanel.Hide();
                        CurrencyPanel.Show();
                        ConsumablePanel.Hide();
                        ToolPanel.Hide();
                        WeaponPanel.Hide();
                        Currency DisplayCurrency = Currency.GetCurrency(SelectedItem.ID);
                        CurrencyPriceTextBox.Text = $"{DisplayCurrency.Price}";
                        break;
                    case "Consumable":
                        AmmoPanel.Hide();
                        ArmorPanel.Hide();
                        CurrencyPanel.Hide();
                        ConsumablePanel.Show();
                        ToolPanel.Hide();
                        WeaponPanel.Hide();
                        Consumable DisplayConsumable = Consumable.GetConsumable(SelectedItem.ID);
                        CurrencyPriceTextBox.Text = $"{DisplayConsumable.Price}";
                        break;
                    case "Miscellaneous":
                        break;
                    case "Tool":
                        AmmoPanel.Hide();
                        ArmorPanel.Hide();
                        CurrencyPanel.Hide();
                        ConsumablePanel.Hide();
                        ToolPanel.Show();
                        WeaponPanel.Hide();
                        Tool DisplayTool = Tool.GetTool(SelectedItem.ID);
                        ToolPriceTextBox.Text = $"{DisplayTool.Price}";
                        ToolDamageTextBox.Text = $"{DisplayTool.ToolDamage}";
                        ToolTypeComboBox.SelectedItem = $"{DisplayTool.ToolType}";
                        break;
                    case "Weapon":
                        AmmoPanel.Hide();
                        ArmorPanel.Hide();
                        CurrencyPanel.Hide();
                        ConsumablePanel.Hide();
                        ToolPanel.Hide();
                        WeaponPanel.Show();
                        Weapon DisplayWeapon = Weapon.GetWeapon(SelectedItem.ID);
                        DamageAmountTextBox.Text = $"{DisplayWeapon.Damage}";
                        WeaponPriceTextBox.Text = $"{DisplayWeapon.Price}";
                        WeaponTwoHandedCheckBox.Checked = DisplayWeapon.Hands;
                        WeaponTypeComboBox.Text = $"{DisplayWeapon.WeaponType}";
                        break;
                }
            }
        }
        private void LeftButtonImage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ImageNumberTextBox.Text) <= 1000)
            {
                ImageNumberTextBox.Text = $"{numberOfImages + 1000}";
            }
            ImageNumberTextBox.Text = $"{Convert.ToInt32(ImageNumberTextBox.Text) - 1}";
            ItemIDTextBox.Text = ImageNumberTextBox.Text;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + ImageNumberTextBox.Text);
        }
        private void RightButtonImage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ImageNumberTextBox.Text) >= 1000 + numberOfImages - 1)
            {
                ImageNumberTextBox.Text = $"{999}";
            }
            ImageNumberTextBox.Text = $"{Convert.ToInt32(ImageNumberTextBox.Text) + 1}";
            ItemIDTextBox.Text = ImageNumberTextBox.Text;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + ImageNumberTextBox.Text);
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            int price;
            int itemDamage;
            string weaponType;
            string armorType;
            int itemID = Convert.ToInt32(ItemIDTextBox.Text);
            string itemName = ItemNameTextBox.Text;
            string itemType = ItemTypeDropdownBox.Text;
            string article = ArticleTextBox.Text;
            int weight = Convert.ToInt32(ItemWeightTextBox.Text);
            int imageNumber = Convert.ToInt32(ImageNumberTextBox.Text);
            bool stackable = StackableBoolean.Checked;
            switch (itemType)
            {
                case "Ammo":
                    itemDamage = Convert.ToInt32(AmmoDamageAmountTextBox.Text);
                    price = Convert.ToInt32(AmmoPriceTextBox.Text);
                    new Ammo(itemID, article, itemName, imageNumber, weight, stackable, itemType, itemDamage, price);
                    break;
                case "Armor":
                    armorType = ArmorTypeComboBox.Text;
                    price = Convert.ToInt32(ArmorPriceTextBox.Text);
                    int itemArmor = Convert.ToInt32(ArmorAmountTextBox.Text);
                    new Armor(itemID, article, itemName, imageNumber, weight, stackable, itemType, armorType, itemArmor, price);
                    break;
                case "Currency":
                    price = Convert.ToInt32(CurrencyPriceTextBox.Text);
                    new Currency(itemID, article, itemName, imageNumber, weight, stackable, itemType, price);
                    break;
                case "Consumable":
                    int HAPT = Convert.ToInt32(HealthAmountPerTick.Text);
                    int MAPT = Convert.ToInt32(ManaAmountPerTick.Text);
                    int FD = Convert.ToInt32(FullDuration.Text);
                    price = Convert.ToInt32(ConsumablePriceTextBox.Text);
                    new Consumable(itemID, article, itemName, imageNumber, weight, stackable, itemType, HAPT, MAPT, FD, price);
                    break;
                case "Miscellaneous":
                    new Miscellaneous(itemID, article, itemName, imageNumber, weight, stackable, itemType);
                    break;
                case "Tool":
                    price = Convert.ToInt32(ToolPriceTextBox.Text);
                    int toolDamage = Convert.ToInt32(ToolDamageTextBox.Text);
                    string toolType = ToolTypeComboBox.Text;
                    new Tool(itemID, article, itemName, imageNumber, weight, stackable, itemType, toolType, toolDamage, price);
                    break;
                case "Weapon":
                    itemDamage = Convert.ToInt32(DamageAmountTextBox.Text);
                    price = Convert.ToInt32(WeaponPriceTextBox.Text);
                    bool hands = WeaponTwoHandedCheckBox.Checked;
                    weaponType = WeaponTypeComboBox.Text;
                    new Weapon(itemID, article, itemName, imageNumber, weight, stackable, itemType, weaponType, itemDamage, hands, price);
                    break;
            }
            RefreshItemList();
        }
        void RefreshItemList()
        {
            CurrentLoadedItemsListBox.Items.Clear();
            Item.ItemList.Sort((x, y) => x.ID.CompareTo(y.ID));
            foreach (Item item in Item.ItemList)
            {
                CurrentLoadedItemsListBox.Items.Add($"{item.ID} -- Name = {item.Name}");
            }
        }

        private void ItemTypeDropdownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ItemTypeDropdownBox.SelectedIndex)
            {
                case 0:
                    AmmoPanel.Show();
                    ArmorPanel.Hide();
                    CurrencyPanel.Hide();
                    ConsumablePanel.Hide();
                    ToolPanel.Hide();
                    WeaponPanel.Hide();
                    break;
                case 1:
                    AmmoPanel.Hide();
                    ArmorPanel.Show();
                    CurrencyPanel.Hide();
                    ConsumablePanel.Hide();
                    ToolPanel.Hide();
                    WeaponPanel.Hide();
                    break;
                case 2:
                    AmmoPanel.Hide();
                    ArmorPanel.Hide();
                    CurrencyPanel.Show();
                    ConsumablePanel.Hide();
                    ToolPanel.Hide();
                    WeaponPanel.Hide();
                    break;
                case 3:
                    AmmoPanel.Hide();
                    ArmorPanel.Hide();
                    CurrencyPanel.Hide();
                    ConsumablePanel.Show();
                    ToolPanel.Hide();
                    WeaponPanel.Hide();
                    break;
                case 4:
                    AmmoPanel.Hide();
                    ArmorPanel.Hide();
                    CurrencyPanel.Hide();
                    ConsumablePanel.Hide();
                    ToolPanel.Hide();
                    WeaponPanel.Hide();
                    break;
                case 5:
                    AmmoPanel.Hide();
                    ArmorPanel.Hide();
                    CurrencyPanel.Hide();
                    ConsumablePanel.Hide();
                    ToolPanel.Show();
                    WeaponPanel.Hide();
                    break;
                case 6:
                    AmmoPanel.Hide();
                    ArmorPanel.Hide();
                    CurrencyPanel.Hide();
                    ConsumablePanel.Hide();
                    ToolPanel.Hide();
                    WeaponPanel.Show();
                    break;
                default:
                    AmmoPanel.Hide();
                    ArmorPanel.Hide();
                    CurrencyPanel.Hide();
                    ConsumablePanel.Hide();
                    ToolPanel.Hide();
                    WeaponPanel.Hide();
                    break;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Item.ItemList.Count >= 1)
            {
                if(CurrentLoadedItemsListBox.SelectedIndex >= 0)
                { 
                Item SelectedItem = Item.ItemList[CurrentLoadedItemsListBox.SelectedIndex];
                    if (SelectedItem != null)
                    {
                        string itemType = SelectedItem.ItemType;
                        AmmoPanel.Hide();
                        ArmorPanel.Hide();
                        CurrencyPanel.Hide();
                        ConsumablePanel.Hide();
                        ToolPanel.Hide();
                        WeaponPanel.Hide();
                        switch (itemType)
                        {
                            case "Ammo":
                                Ammo DisplayAmmo = Ammo.GetAmmo(SelectedItem.ID);
                                DisplayAmmo.DestroySelf();
                                break;
                            case "Armor":
                                Armor DisplayArmor = Armor.GetArmor(SelectedItem.ID);
                                DisplayArmor.DestroySelf();
                                break;
                            case "Currency":
                                Currency DisplayCurrency = Currency.GetCurrency(SelectedItem.ID);
                                DisplayCurrency.DestroySelf();
                                break;
                            case "Consumable":
                                Consumable DisplayConsumable = Consumable.GetConsumable(SelectedItem.ID);
                                DisplayConsumable.DestroySelf();
                                break;
                            case "Miscellaneous":
                                SelectedItem.DestroySelf();
                                break;
                            case "Tool":
                                Tool DisplayTool = Tool.GetTool(SelectedItem.ID);
                                DisplayTool.DestroySelf();
                                break;
                            case "Weapon":
                                Weapon DisplayWeapon = Weapon.GetWeapon(SelectedItem.ID);
                                DisplayWeapon.DestroySelf();
                                break;
                        }
                        if (SelectedItem != null)
                        {
                            SelectedItem.DestroySelf();
                        }
                        RefreshItemList();
                        if (Item.ItemList.Count >= 1)
                        {
                            CurrentLoadedItemsListBox.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Items.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Item.ItemList);
            }
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Ammos.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Ammo.ammoList);
            }
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Armors.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Armor.Armors);
            }
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Currency.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Currency.Currencies);
            }
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Consumables.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Consumable.Consumables);
            }
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Miscellaneous.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Miscellaneous.miscellaneousList);
            }
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Tools.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Tool.Tools);
            }
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\Weapons.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Weapon.Weapons);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
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
            using (StreamReader file = new StreamReader(@".\ItemsJSON\Consumables.json"))
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
            RefreshItemList();
        }
    }
}
