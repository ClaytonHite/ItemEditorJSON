using ItemEditorJSON.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON
{
    class ArmorAttributes : Armor
    {
        public string[] magicalAttribute = { "Assassin's", "Banishing", "Frenzied", "Celestial", "Divine", "Flaming", "Frozen", "Precise", "Reliable", "Shadowed", "Sharp", "Shocking", "Vengeful" };
        public string[] materialAttribute = { "Adamantine", "Alder", "Ash", "Bone", "Bronze", "Bronzewood", "Copper", "Golden", "Iron", "Mithril", "Oak", "Stone", "Wooden", "Yew" };
        public string MagicalAttributeString;
        public string MaterialAttributeString;
        public int ArmorAttribute;
        public ArmorAttributes(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType, string _armorType, int _armor, int _price, string magic, string material, int armor) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType, _armorType, _armor, _price)
        {
            this.MagicalAttributeString = magic;
            this.MagicalAttributeString = material;
            this.ArmorAttribute = armor;
        }
    }
}