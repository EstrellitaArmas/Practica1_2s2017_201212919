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
using Newtonsoft.Json;

namespace Practica1
{
    public partial class ColaMensajes : Form
    {
        private string IP_LOCAL = "192.168.1.3";
        public ColaMensajes()
        {
            InitializeComponent();
            txtCantidad.Text = HttpGet("http://"+IP_LOCAL+":5000/cntCola");
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

        private static string carnet;
        private void btnOperar_Click(object sender, EventArgs e)
        {

            string url = "http://" + IP_LOCAL + ":5000/operar";
            string jsonResponse = HttpGet(url);
            try
            {
                dynamic stuff = JsonConvert.DeserializeObject(jsonResponse);
                txtInorden.Text = stuff.inorden;
                txtPost.Text = stuff.postorden;
                txtResultado.Text = stuff.resultado;
                string ip = stuff.ipRecup;
                txtIp.Text = ip;
                MetodoGetConectado(ip);
                //txtCarnet.Text = HttpGet("http://" + stuff.ipRecup + ":5000/conectado");
                txtCarnet.Text = carnet;
                txtCantidad.Text = HttpGet("http://" + IP_LOCAL + ":5000/cntCola");
                txtCola.Text = stuff.colaEjecucion;
            }
            catch { MessageBox.Show(jsonResponse); }

        }
        
        public void MetodoGetConectado(string ipCarnet)
        {
            try
            {
                using (var cliente = new WebClient())
                {
                    //var respuestaConvertidaString = cliente.DownloadString("http://192.168.1.5:5000/conectado");
                    var respuestaConvertidaString = cliente.DownloadString("http://"+ipCarnet+":5000/conectado");
                    Console.WriteLine(respuestaConvertidaString);
                    carnet = respuestaConvertidaString;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ColaMensajes_Load(object sender, EventArgs e)
        {

        }

        private void txtCarnet_Click(object sender, EventArgs e)
        {

        }

        private void txtResultado_Click(object sender, EventArgs e)
        {

        }

        private void txtInorden_Click(object sender, EventArgs e)
        {

        }

        private void txtIp_Click(object sender, EventArgs e)
        {

        }

        private void txtPost_Click(object sender, EventArgs e)
        {

        }
    }
}
