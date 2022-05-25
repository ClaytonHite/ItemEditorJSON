using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    class Miscellaneous : Item
    {
        public int AmountOfItem { get; set; }
        public static List<Miscellaneous> miscellaneousList = new List<Miscellaneous>();
        public Miscellaneous(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            miscellaneousList.Add(this);
        }
    }
}
