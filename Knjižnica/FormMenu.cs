using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjižnica
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void knjigaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new FormKnjige();
            myForm.ShowDialog();
        }
        
        private void knjiznicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new FormKnjiznica();
            myForm.ShowDialog();
        }

        private void članKnjižniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new FormClanKnjiznice();
            myForm.ShowDialog();
        }

        private void zaposlenikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new FormZaposlenik();
            myForm.ShowDialog();
        }

        private void posudbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new FormPosudbe();
            myForm.ShowDialog();
        }

        private void FormMenu_Shown(object sender, EventArgs e)
        {
            var myForm = new FormLogin();
            myForm.ShowDialog();

            if (Util.KnjiznicaID == 0)
                this.Close();
        }
    }
}
