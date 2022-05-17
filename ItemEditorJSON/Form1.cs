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
        ItemCreator instance = new ItemCreator();
        public Form1()
        {
            InitializeComponent();
            ItemIDTextBox.Text = "1";
            ImageNumberTextBox.Text = "1";
            WeaponPanel.Hide();
            ArmorPanel.Hide();
            FoodPanel.Hide();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LeftButtonImage_Click(object sender, EventArgs e)
        {

        }
        private void RightButtonImage_Click(object sender, EventArgs e)
        {

        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            int itemID = Convert.ToInt32(ItemIDTextBox.Text);
            string itemName = ItemNameTextBox.Text;
            string itemType = ItemTypeDropdownBox.Text;
            string weaponType = WeaponTypeComboBox.Text;
            string armorType = ArmorTypeComboBox.Text;
            string article = ArticleTextBox.Text;
            int itemDamage = Convert.ToInt32(DamageAmountTextBox.Text);
            int itemArmor = Convert.ToInt32(ArmorAmountTextBox.Text);
            int[] itemAttributes = {itemDamage, itemArmor};
            int imageNumber = Convert.ToInt32(ImageNumberTextBox.Text);
            bool stackable = StackableBoolean.Checked;
            instance.AddItem(itemID, article, itemName, itemType, itemAttributes, imageNumber, stackable);
            RefreshItemList();
        }
        void RefreshItemList()
        {
            listBox1.Items.Clear();
            foreach (Item item in Item.ItemList)
            {
                listBox1.Items.Add($"{item.ID} -- {item.Name}");
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
