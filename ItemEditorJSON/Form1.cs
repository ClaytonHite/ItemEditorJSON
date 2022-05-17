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
            string article = "a";
            int itemDamage = 0;
            int itemArmor = 0;
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
    }
}
