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
    public partial class Mensajes : Form
    {
        public Mensajes()
        {
            InitializeComponent();
        }

        private void btnVerCola_Click(object sender, EventArgs e)
        {
            ColaMensajes colaMensajes = new ColaMensajes();

            colaMensajes.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RespuestaMensajes respuestaMensaje = new RespuestaMensajes();

            respuestaMensaje.Show();
        }
    }
}
