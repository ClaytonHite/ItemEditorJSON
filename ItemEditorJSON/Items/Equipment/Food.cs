using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    class Food : Item
    {
        public int HealthAmountPerTick { get; set; }
        public int ManaAmountPerTick { get; set; }
        public int FullDuration { get; set; }
        public int Price { get; set; }
        public int AmountOfItem { get; set; }
        public Food(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType, int _healthAmountPerTick, int _manaAmountPerTick, int _fullDuration, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            HealthAmountPerTick = _healthAmountPerTick;
            ManaAmountPerTick = _manaAmountPerTick;
            FullDuration = _fullDuration;
            Price = _price;
            RegisterItem(this);
        }
    }
}
