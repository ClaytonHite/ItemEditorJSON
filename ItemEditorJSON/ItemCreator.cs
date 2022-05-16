using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON
{
    class ItemCreator
    {
        public Form1 instance;
        public void AddItem()
        {
            Item itemToAdd = new Item(Convert.ToInt32(instance.ItemIDTextBox.Text), instance.ItemNameTextBox.Text, new EquipmentType(instance.ItemTypeTextBox.Text), new Attributes(null, null, 0, 0), Convert.ToInt32(instance.ImageNumberTextBox.Text), instance.StackableBoolean.Checked);
        }
    }
}
