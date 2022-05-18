using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    class Food : Item
    {
        int HealthAmount { get; set; }
        int ManaAmount { get; set; }
        int FullDuration { get; set; }
        int Price { get; set; }
        int AmountOfItem { get; set; }
        public Food(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType, int _healthAmount, int _manaAmount, int _fullDuration, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            HealthAmount = _healthAmount;
            ManaAmount = _manaAmount;
            FullDuration = _fullDuration;
            Price = _price;
            RegisterItem(this);
        }
    }
}
