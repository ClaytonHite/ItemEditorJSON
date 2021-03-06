using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    internal class Currency : Item
    {
        public int Price { get; set; }
        public int AmountOfItem { get; set; }
        public static List<Currency> Currencies = new List<Currency>();
        public Currency(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            Price = _price;
            switch (AmountOfItem)
            {
                case 1:
                    break;
                case 2:
                    _imageNumber = _imageNumber + 1;
                    break;
                case 3:
                    _imageNumber = _imageNumber + 2;
                    break;
                case 4:
                    _imageNumber = _imageNumber + 3;
                    break;
                default:
                    _imageNumber = _imageNumber + 4;
                    break;
            }
            Currencies.Add(this);
            RegisterItem(this);
        }
        public static Currency GetCurrency(int itemID)
        {
            foreach (Currency currency in Currencies)
            {
                if (currency.ID == itemID)
                {
                    return currency;
                }
            }
            return null;
        }
    }
}
