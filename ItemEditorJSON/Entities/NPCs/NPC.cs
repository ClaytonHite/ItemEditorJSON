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
        public int ImageID;
        public string NPCScript;
        static List<NPC> NPCs = new List<NPC>();
        public NPC(int iD, string name, int imageID, string npcScript)
        {
            ID = iD;
            Name = name;
            ImageID = imageID;
            NPCScript = npcScript;
            RegisterNPC(this);
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
        public static void LoadNpcs(List<NPC> npcs)
        {
            NPCs = npcs;
        }
    }
}
