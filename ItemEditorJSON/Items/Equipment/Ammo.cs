using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    class Ammo : Item
    {
        public int Damage { get; set; }
        public int Price { get; set; }
        public int AmountOfItem { get; set; }
        public static List<Ammo> ammoList = new List<Ammo>();
        public Ammo(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType, int _damage, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            Damage = _damage;
            Price = _price * _damage;
            ammoList.Add(this);
            RegisterItem(this);
        }
        public static Ammo GetAmmo(int itemID)
        {
            foreach (Ammo ammo in ammoList)
            {
                if (ammo.ID == itemID)
                {
                    return ammo;
                }
            }
            return null;
        }
    }
}
