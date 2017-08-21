using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Practica1
{
    public partial class Dashboard : Form
    {
        private string IP_LOCAL = "192.168.1.3";
        public Dashboard()
        {
            InitializeComponent();
            string url = "http://"+IP_LOCAL+":5000/get_my_ip";
            txtIp.Text = HttpGet(url);

        }
        public string HttpGet(string URI)
        {
            try
            {
                WebRequest req = System.Net.WebRequest.Create(URI);
                WebResponse resp = req.GetResponse();
                StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch { return null ; }
        }
        public string HttpPost(string URI, string Parameters)
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
            catch { MessageBox.Show("verifique conexion");
                return null;
            }    
        }
        public static void CambiarIp(string ip_address, string subnet_mask)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();
            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP = objMO.GetMethodParameters("EnableStatic");
                        newIP["IPAddress"] = new string[] { ip_address };
                        newIP["SubnetMask"] = new string[] { subnet_mask };
                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
                    }
                    catch (Exception) { throw; }
                }
            }
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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);                
            }
        }
        public void MetodoPost(string json)
        {
            using (var cliente = new WebClient())
            {
                var variablesEnviar = new System.Collections.Specialized.NameValueCollection();
                variablesEnviar["json"] = json;
                //variablesEnviar["var2"] = "Mundo";

                var respuestaMetodo = cliente.UploadValues("http://192.168.10.102:5000/cargaJSON", variablesEnviar);
                var respuestaConvertidaString = Encoding.Default.GetString(respuestaMetodo);
                Console.WriteLine(respuestaConvertidaString);
                jsonResponse = respuestaConvertidaString;
            }
        }

        static string jsonResponse;
       
        static int contadorNodosCola;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string json = sr.ReadToEnd();
                string url = "http://" + IP_LOCAL + ":5000/cargaJSON";
                jsonResponse = HttpPost(url, json);
                if (jsonResponse == null)
                {
                    MessageBox.Show("VerifiqueConexion");
                }
                else
                {
                    getStatus(jsonResponse);                    
                }
                sr.Close();
                //refresh();
            }

        }

        public void getStatus(string jsonResponse)
        {            
            dynamic stuff = JsonConvert.DeserializeObject(jsonResponse);
            Console.WriteLine("1" + stuff.primero.ip);
            string estado = "false";
            int contador = 1;
            if (!stuff.primero.carnet.Equals('-'))
            {
                estado = "true";
            }
            string[] row0 = { "Nodo"+ contador++, stuff.primero.ip, stuff.primero.carnet, estado };
            dataDash.Rows.Add(row0);
            if (stuff.primero.prox != null)
            {
                JObject name = stuff.primero.prox;
                stuff = JsonConvert.DeserializeObject(name.ToString());
                while (stuff.prox != null)
                {
                    Console.WriteLine(stuff.ip);
                    estado = "false";
                    if (!stuff.carnet.Equals('-'))
                    {
                        estado = "true";
                    }
                    string[] row1 = { "Nodo" + contador++, stuff.ip, stuff.carnet, estado };
                    dataDash.Rows.Add(row1);
                    name = stuff.prox;
                    stuff = JsonConvert.DeserializeObject(name.ToString());

                }
                Console.WriteLine(stuff.ip);
                estado = "false";
                if (stuff.carnet.Equals('-'))
                {
                    estado = "true";
                }
                string[] row2 = { "Nodo" + contador++, stuff.ip, stuff.carnet, estado };
                dataDash.Rows.Add(row2);
            }
        
    }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataDash.Rows.Clear();
            jsonResponse = HttpGet("http://" + IP_LOCAL + ":5000/getStatus");
            getStatus(jsonResponse);
        }
        
    }
}
