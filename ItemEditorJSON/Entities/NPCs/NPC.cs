using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemEditorJSON.Entities.NPCs
{
    public class NPC
    {
        public int ID;
        public string Name;
        public string Race;
        public int ImageID;
        public string QuestScript;
        public static List<NPC> NPCs = new List<NPC>();
        public NPC(int iD, string name, string race, int imageID, string questScript)
        {
            ID = iD;
            Name = name;
            Race = race;
            ImageID = imageID;
            QuestScript = questScript;
        }
        public void DestroySelf()
        {
            UnRegisterNPC(this);
        }
        public void RegisterNPC(NPC _NPC)
        {
            NPCs.Add(_NPC);
        }
        public void UnRegisterNPC(NPC _NPC)
        {
            NPCs.Remove(_NPC);
        }
        public static List<NPC> GetNPCList()
        {
            return NPCs;
        }
    }
}
