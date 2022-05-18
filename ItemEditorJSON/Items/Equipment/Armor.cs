using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    class Armor : Item
    {
        int ArmorAmount { get; set; }
        int Hands { get; set; }
        int Price { get; set; }
        public Armor(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable,string _slotType, int _armor, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            ArmorAmount = _armor;
            Price = _price * _armor;
            RegisterItem(this);
        }
    }
}
