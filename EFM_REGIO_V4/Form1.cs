using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFM_REGIO_V4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f= new Form2();
            f.Show();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3();
            ff.Show();
        }
    }
}
