using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON
{
    class Item
    {
        public int ID;
        string Article;
        public string Name;
        public int Weight;
        public EquipmentType equipmentType;
        public Attributes Attributes;
        public int ImageNumber;
        public bool Stackable;
        public List<Item> ItemList = new List<Item>();
        //healthAmountPerTick//healthTimeTicks//manaAmountPerTick//manaTimeTicks
        public Item(int _id, string _name, EquipmentType _equipmentType, Attributes _attributes, int _imageNumber, bool _stackable)
        {
            this.ID = _id;
            this.Name = _name;
            this.equipmentType = _equipmentType;
            this.Attributes = _attributes;
            this.ImageNumber = _imageNumber;
            this.Stackable = _stackable;

            RegisterItem(this);
        }
        public void DestroySelf()
        {
            UnRegisterGameObject(this);
        }
        public void RegisterItem(Item _item)
        {
            ItemList.Add(_item);
        }
        public void UnRegisterGameObject(Item _item)
        {
            ItemList.Remove(_item);
        }
    }
}
