using ItemEditorJSON.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON
{
    public class Item
    {
        public int ID;
        public string Article;
        public string Name;
        public int Weight;
        public int ImageNumber;
        public bool Stackable;
        public string ItemType;
        public static List<Item> ItemList = new List<Item>();
        public Item(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType)
        {
            this.ID = _id;
            this.Article = article;
            this.Name = _name;
            this.ImageNumber = _imageNumber;
            this.Weight = _weight;
            this.Stackable = _stackable;
            this.ItemType = _slotType;
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
        public Item Clone()
        {
            return new Item(ID,Article,Name,ImageNumber,Weight,Stackable,ItemType);
        }
    }
}
