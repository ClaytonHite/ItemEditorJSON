using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemEditorJSON
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ItemEditorForm = new ItemEditor();
            this.Visible = false;
            ItemEditorForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form MonsterEditorForm = new MonsterEditor();
            this.Visible = false;
            MonsterEditorForm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form NPCEditorForm = new NPCEditor();
            this.Visible = false;
            NPCEditorForm.ShowDialog();
            this.Close();
        }
    }
}
