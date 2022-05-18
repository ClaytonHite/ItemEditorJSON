using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    class Weapon : Item
    {
        int Damage { get; set; }
        bool Hands { get; set; }
        int Price { get; set; }
        public Weapon(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType, int _damage, bool _hands, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            Damage = _damage;
            Hands = _hands;
            Price = _price * _damage;
            RegisterItem(this);
        }
    }
}
