using ItemEditorJSON.Items.Equipment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemEditorJSON
{
    public partial class Form1 : Form
    {
        int numberOfImages = 0;
        public Form1()
        {
            InitializeComponent();
            ItemIDTextBox.Text = "1";
            ImageNumberTextBox.Text = "1";
            WeaponPanel.Hide();
            ArmorPanel.Hide();
            FoodPanel.Hide();
            ImageNumberTextBox.Text = "1000";
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LeftButtonImage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ImageNumberTextBox.Text) <= 1000)
            {
                ImageNumberTextBox.Text = $"{numberOfImages + 1000}";
            }
        }
        private void RightButtonImage_Click(object sender, EventArgs e)
        {

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
                case "Weapon":
                    itemDamage = Convert.ToInt32(DamageAmountTextBox.Text);
                    price = Convert.ToInt32(WeaponPriceTextBox.Text);
                    bool hands = WeaponTwoHandedCheckBox.Checked;
                    weaponType = WeaponTypeComboBox.Text;
                    new Weapon(itemID, article, itemName, imageNumber, weight, stackable, weaponType, itemDamage, hands, price);
                    break;
                case "Armor":
                    armorType = ArmorTypeComboBox.Text;
                    price = Convert.ToInt32(ArmorPriceTextBox.Text);
                    int itemArmor = Convert.ToInt32(ArmorAmountTextBox.Text);
                    new Armor(itemID, article, itemName, imageNumber, weight, stackable, armorType, itemArmor, price);
                    break;
                case "Ammo":
                    itemDamage = Convert.ToInt32(AmmoDamageTextBox.Text);
                    price = Convert.ToInt32(AmmoPriceTextBox.Text);
                    new Ammo(itemID, article, itemName, imageNumber, weight, stackable, itemType, itemDamage, price);
                    break;
                case "food":

                    break;
                case "Miscellaneous":
                    break;
            }
            RefreshItemList();
        }
        void RefreshItemList()
        {
            listBox1.Items.Clear();
            foreach (Item item in Item.ItemList)
            {
                listBox1.Items.Add($"{item.ID} -- Name = {item.Name}");
            }
        }

        private void ItemTypeDropdownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ItemTypeDropdownBox.SelectedIndex == 0)
            {
                WeaponPanel.Hide();
                WeaponTypeComboBox.SelectedIndex = 0;
                DamageAmountTextBox.Text = "0";
                FoodPanel.Hide();
                HealthAmountPerTick.Text = "0";
                ManaAmountPerTick.Text = "0";
                FullDuration.Text = "0";
                ArmorPanel.Show();
            }
            if (ItemTypeDropdownBox.SelectedIndex == 1)
            {
                WeaponPanel.Show();
                FoodPanel.Hide();
                HealthAmountPerTick.Text = "0";
                ManaAmountPerTick.Text = "0";
                FullDuration.Text = "0";
                ArmorPanel.Hide();
                ArmorTypeComboBox.SelectedIndex = 0;
                ArmorAmountTextBox.Text = "0";
            }
            if (ItemTypeDropdownBox.SelectedIndex == 2)
            {
                WeaponPanel.Hide();
                WeaponTypeComboBox.SelectedIndex = 0;
                DamageAmountTextBox.Text = "0";
                FoodPanel.Show();
                ArmorPanel.Hide();
                ArmorTypeComboBox.SelectedIndex = 0;
                ArmorAmountTextBox.Text = "0";
            }
            if(ItemTypeDropdownBox.SelectedIndex >= 3)
            {
                WeaponPanel.Hide();
                WeaponTypeComboBox.SelectedIndex = 0;
                DamageAmountTextBox.Text = "0";
                FoodPanel.Hide();
                HealthAmountPerTick.Text = "0";
                ManaAmountPerTick.Text = "0";
                FullDuration.Text = "0";
                ArmorPanel.Hide();
                ArmorTypeComboBox.SelectedIndex = 0;
                ArmorAmountTextBox.Text = "0";
            }
        }
    }
}
