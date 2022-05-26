using ItemEditorJSON.Entities.NPCs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemEditorJSON
{
    public partial class NPCEditor : Form
    {
        int NumberOfNPCImages;
        List<Image> MonsterImages = new List<Image>();
        public NPCEditor()
        {
            InitializeComponent();
            NPCImageIDTextBox.Text = $"{2000}";
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + NPCImageIDTextBox.Text);
            for (int i = 2000; i < 2500; i++)
            {
                if ((Image)Properties.Resources.ResourceManager.GetObject("_" + i) != null)
                {
                    MonsterImages.Add((Image)Properties.Resources.ResourceManager.GetObject("_" + i));
                    NumberOfNPCImages++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form StartForm = new StartForm();
            this.Visible = false;
            StartForm.ShowDialog();
            this.Close();
        }
        void RefreshNpcListBox()
        {
            listBox1.Items.Clear();
            foreach(NPC npc in NPC.GetNPCList())
            {
                listBox1.Items.Add($"NPC ID = {npc.ID}, Name = {npc.Name}, Script = {npc.NPCScript}");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new NPC(Convert.ToInt32(NPCIDTextBox.Text), NPCNameTextBox.Text, Convert.ToInt32(NPCImageIDTextBox.Text), NPCScriptTextBox.Text);
            RefreshNpcListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {//left button
            if (Convert.ToInt32(NPCImageIDTextBox.Text) <= 2000)
            {
                NPCImageIDTextBox.Text = $"{NumberOfNPCImages + 2000}";
            }
            NPCImageIDTextBox.Text = $"{Convert.ToInt32(NPCImageIDTextBox.Text) - 1}";
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + NPCImageIDTextBox.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {//right button
            if (Convert.ToInt32(NPCImageIDTextBox.Text) >= 2000 + NumberOfNPCImages - 1)
            {
                NPCImageIDTextBox.Text = $"{1999}";
            }
            NPCImageIDTextBox.Text = $"{Convert.ToInt32(NPCImageIDTextBox.Text) + 1}";
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + NPCImageIDTextBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Create(@".\ItemsJSON\NPCs.json").Close();
            using (StreamWriter file = File.CreateText(@".\ItemsJSON\NPCs.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, NPC.GetNPCList());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (StreamReader file = new StreamReader(@".\ItemsJSON\NPCs.json"))
            {
                string json = file.ReadToEnd();
                List<NPC> npcs = JsonConvert.DeserializeObject<List<NPC>>(json);
                NPC.LoadNpcs(npcs);
            }
            RefreshNpcListBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedItem != null)
            {
                List<NPC> npcs = NPC.GetNPCList();
                npcs[listBox1.SelectedIndex].DestroySelf();
            }
            RefreshNpcListBox();
        }
    }
}
