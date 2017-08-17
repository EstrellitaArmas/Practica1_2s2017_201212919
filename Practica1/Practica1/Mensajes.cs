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
    public partial class Mensajes : Form
    {
        public Mensajes()
        {
            InitializeComponent();
        }
        public static string HttpPost(string URI, string Parameters)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
                //req.Proxy = new System.Net.WebProxy(ProxyString, true);
                //Add these, as we're doing a POST
                req.ContentType = "application/json";
                req.Method = "POST";
                //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
                req.ContentLength = bytes.Length;
                System.IO.Stream os = req.GetRequestStream();
                os.Write(bytes, 0, bytes.Length); //Push it out there
                os.Close();
                System.Net.WebResponse resp = req.GetResponse();
                if (resp == null) return null;
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch
            {
                return "Verifique conexion con servidor";
            }
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

        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                String xml = sr.ReadToEnd();
                //MessageBox.Show(xml);
                string url = "http://192.168.10.104:5000/cargaXML";
                MessageBox.Show(HttpPost(url, openFileDialog1.FileName));

                sr.Close();
            }
        }
    }
}
