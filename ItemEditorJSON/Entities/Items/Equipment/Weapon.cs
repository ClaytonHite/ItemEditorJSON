using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public bool Hands { get; set; }
        public int Price { get; set; }
        public string WeaponType { get; set; }
        public ItemAttribute Attribute { get; set; }
        public static List<Weapon> Weapons = new List<Weapon>();
        public Weapon(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType, string _weaponType, int _damage, bool _hands, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            Damage = _damage;
            Hands = _hands;
            Price = _price * _damage;
            WeaponType = _weaponType;
            Weapons.Add(this);
            ItemList.Add(this);
        }
        public static Weapon GetWeapon(int itemID)
        {
            foreach (Weapon weapon in Weapons)
            {
                if(weapon.ID == itemID)
                {
                    return weapon;
                }
            }
            return null;
        }
        public new Weapon Clone()
        {
            return new Weapon(ID,Article,Name,ImageNumber,Weight,Stackable,ItemType,WeaponType,Damage,Hands,Price);
        }
    }
}
