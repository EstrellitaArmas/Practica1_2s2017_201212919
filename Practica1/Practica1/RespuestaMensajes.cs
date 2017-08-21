using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class RespuestaMensajes : Form
    {

        private string IP_LOCAL = "192.168.1.3";
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

        public RespuestaMensajes()
        {
            InitializeComponent();
            string url = "http://" + IP_LOCAL + ":5000/getRespuestas";
            string jsonResponse = HttpGet(url);
            //try
            //{
            
            dynamic stuff = JsonConvert.DeserializeObject(jsonResponse);
            foreach (object rate in stuff)
            {
            
                string respuesta = "{" + rate.ToString() + "}";
                dynamic stuff2 = JsonConvert.DeserializeObject(respuesta);
                Console.WriteLine(stuff2);
                string carnet = HttpGet("http://" + stuff2.ipRecup + ":5000/conectado");
                string[] row1 = { carnet, stuff2.ipRecup, stuff2.inorden, stuff2.postorden, stuff2.resultado };
                dataRespuestas.Rows.Add(row1);
                //MetodoGetConectado(jsonIPs.ip);
                
            }
            //dynamic stuff = JsonConvert.DeserializeObject(jsonResponse);
            //if (stuff != null)
            //{
            //    //JArray respuestas = stuff;
            //    foreach (JProperty respuesta in stuff)
            //    {
            //        //JObject res = respuesta;
            //        dynamic stuff2 = JsonConvert.DeserializeObject(respuesta.ToString());
            //        string carnet = HttpGet("http://" + stuff.ip + ":5000/conectado");
            //        string[] row1 = { carnet, stuff2.ip, stuff2.inorden, stuff2.postorden, stuff2.resultado };
            //        dataRespuestas.Rows.Add(row1);
            //        //MetodoGetConectado(jsonIPs.ip);
            //        Console.WriteLine(respuesta);
            //    }
            //}
            //MetodoGetConectado("192.168.10.104");

            //JObject name = stuff.respuesta+contador;
            //stuff = JsonConvert.DeserializeObject(name.ToString());

            //contador = contador + 1;

            //Console.WriteLine(stuff.ip);
            //estado = "false";
            //if (stuff.carnet.Equals('-'))
            //{
            //    estado = "true";
            //}
            //string[] row2 = { "Nodo" + contador++, stuff.ip, stuff.carnet, estado };
            //dataDash.Rows.Add(row2);

            //}catch { MessageBox.Show(jsonResponse); }

        }
    }
}
