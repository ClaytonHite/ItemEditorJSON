using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    class Armor : Item
    {
        public int ArmorAmount { get; set; }
        public int Hands { get; set; }
        public int Price { get; set; }
        public string ArmorType { get; set; }
        public ItemAttribute Attributes { get; set; }
        public static List<Armor> Armors = new List<Armor>();
        public Armor(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable,string _slotType, string _armorType, int _armor, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            ArmorAmount = _armor;
            Price = _price * _armor;
            ArmorType = _armorType;
            Armors.Add(this);
            RegisterItem(this);
        }
        public static Armor GetArmor(int itemID)
        {
            foreach (Armor armor in Armors)
            {
                if (armor.ID == itemID)
                {
                    return armor;
                }
            }
            return null;
        }
    }
}
