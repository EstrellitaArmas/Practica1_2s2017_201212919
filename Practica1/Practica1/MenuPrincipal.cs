using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();

            Dashboard dashboard = new Dashboard();

            dashboard.Show();
        }

        private void btnAdminMensajes_Click(object sender, EventArgs e)
        {
            Mensajes mensajes = new Mensajes();

            mensajes.Show();
        }

        private void btnVerReportes_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes();

            reportes.Show();
        }
    }
}
