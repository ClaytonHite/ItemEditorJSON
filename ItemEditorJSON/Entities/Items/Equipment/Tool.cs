using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Items.Equipment
{
    class Tool : Item
    {
        public int ToolDamage { get; set; }
        public int Hands { get; set; }
        public int Price { get; set; }
        public string ToolType { get; set; }
        public static List<Tool> Tools = new List<Tool>();
        public Tool(int _id, string article, string _name, int _imageNumber, int _weight, bool _stackable, string _slotType, string _ToolType, int _ToolDamage, int _price) : base(_id, article, _name, _imageNumber, _weight, _stackable, _slotType)
        {
            ToolDamage = _ToolDamage;
            Price = _price * _ToolDamage;
            ToolType = _ToolType;
            Tools.Add(this);
            RegisterItem(this);
        }
        public static Tool GetTool(int itemID)
        {
            foreach (Tool Tool in Tools)
            {
                if (Tool.ID == itemID)
                {
                    return Tool;
                }
            }
            return null;
        }
    }
}
