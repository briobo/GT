using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void solicitudesCerradasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void baseDeTalentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            Modelo m = new Modelo();
        }

      
        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ABMCliente v = new ABMCliente();
            v.MdiParent = this;
            v.Show();

        }
    }
}
