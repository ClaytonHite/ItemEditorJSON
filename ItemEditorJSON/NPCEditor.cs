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
    public partial class NPCEditor : Form
    {
        public NPCEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form StartForm = new StartForm();
            this.Visible = false;
            StartForm.ShowDialog();
            this.Close();
        }
    }
}
