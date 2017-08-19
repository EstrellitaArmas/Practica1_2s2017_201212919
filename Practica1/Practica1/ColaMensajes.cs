using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace Practica1
{
    public partial class ColaMensajes : Form
    {
        public ColaMensajes()
        {
            InitializeComponent();
        }
        public static string HttpGet(string URI)
        {
            try
            {
                WebRequest req = System.Net.WebRequest.Create(URI);
                WebResponse resp = req.GetResponse();
                StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch
            {
                return "Verifique conexion con servidor";
            }
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {

            //string url = "http://192.168.10.104:5000/operar";
            string url = "http://192.168.1.5:5000/operar";
            txtInorden.Text = HttpGet(url);
        }
    }
}
