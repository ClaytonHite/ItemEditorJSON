using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON
{
    public class Attributes
    {
        public string[] magicalAttribute = { "Assassin's", "Banishing", "Frenzied", "Celestial", "Divine", "Flaming", "Frozen", "Precise", "Reliable", "Shadowed", "Sharp", "Shocking", "Vengeful" };
        public string[] materialAttribute = { "Adamantine", "Alder", "Ash", "Bone", "Bronze", "Bronzewood", "Copper", "Golden", "Iron", "Mithril", "Oak", "Stone", "Wooden", "Yew" };
        public string MagicalAttributeString;
        public string MaterialAttributeString;
        public int DamageAttribute;
        public int ArmorAttribute;
        public Attributes(string magic, string material, int damage, int armor)
        {
            this.MagicalAttributeString = magic;
            this.MagicalAttributeString = material;
            this.DamageAttribute = damage;
            this.ArmorAttribute = armor;
        }
    }
}