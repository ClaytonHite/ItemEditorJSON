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
        public void AddItem(int itemID, string article, string itemName, string equipmentType, int[] attributes, int imageNumber, bool stackable)
        {
            new Item(itemID, article, itemName, new EquipmentType(equipmentType), new Attributes(null, null, attributes[0], attributes[1]), imageNumber, stackable);
        }
    }
}
