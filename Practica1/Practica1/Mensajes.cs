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
        public void MetodoPost(string ip , string mensaje)
        {
            using (var cliente = new WebClient())
            {
                var variablesEnviar = new System.Collections.Specialized.NameValueCollection();
                variablesEnviar["inorden"] = mensaje;

                var respuestaMetodo = cliente.UploadValues("http://"+ ip +":5000/mensaje", variablesEnviar);
                var respuestaConvertidaString = Encoding.Default.GetString(respuestaMetodo);
                Console.WriteLine(respuestaConvertidaString);
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

        static List<NodoCola> listaCola;
        static int contadorNodosCola;
        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            listaCola = new List<NodoCola>();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                String xml = sr.ReadToEnd();
                MessageBox.Show(xml);
                string url = "http://192.168.1.5:5000/cargaXML";
                //MessageBox.Show(HttpPost(url, openFileDialog1.FileName));
                AnalizarXML(xml);
                sr.Close();
            }

            foreach (var cola in listaCola)
            {
                 MetodoPost(cola.ip , cola.mensaje);
            }

        }
      
        public  void AnalizarXML(string cadena)
        {
            int inicioestado = 0;
            int estadoprincipal = 0;
            char cadenaconcatenar;
            string ip = "";
            string mensaje = "";

            for (inicioestado = 0; inicioestado < cadena.Length; inicioestado++)
            {
                cadenaconcatenar = cadena[inicioestado];

                switch (estadoprincipal)
                {
                    case 0:
                        switch (cadenaconcatenar)
                        {
                            case ' ':
                            case '\r':
                            case '\t':
                            case '\n':
                            case '\b':
                            case '\f':
                                estadoprincipal = 0;
                                break;

                            case '<':
                                estadoprincipal = 1;
                                break;
                        }
                        break;

                    case 1: //Mensaje Nodo
                        if (char.IsLetter(cadenaconcatenar) || cadenaconcatenar.Equals('<') || cadenaconcatenar.Equals('>') || cadenaconcatenar.Equals('/'))
                        {
                            if (cadenaconcatenar.Equals('I'))
                            {
                                estadoprincipal = 2;
                            }
                            else
                            {
                                estadoprincipal = 1;
                            }
                        }
                        break;

                    case 2://Ip - Numeros
                        if (char.IsLetter(cadenaconcatenar) || cadenaconcatenar.Equals('<') || cadenaconcatenar.Equals('>'))
                        {
                            if (cadenaconcatenar.Equals('t'))
                            {
                                estadoprincipal = 3;
                            }
                            else
                            {
                                estadoprincipal = 2;
                            }
                        }
                        else if (char.IsNumber(cadenaconcatenar) || cadenaconcatenar.Equals('.'))
                        {
                            ip += cadenaconcatenar;
                            estadoprincipal = 2;
                        }
                        else if (cadenaconcatenar.Equals('/'))
                        {
                            if (ip != "" || mensaje != "")
                            {
                                AgregaraCola(ip, mensaje);
                                Console.WriteLine(ip + mensaje);
                                ip = "";
                                mensaje = "";
                            }
                            estadoprincipal = 2;
                        }
                        break;

                    case 3: //texto
                        if (char.IsLetter(cadenaconcatenar) || cadenaconcatenar.Equals('>'))
                        {
                            estadoprincipal = 3;
                        }
                        else if (cadenaconcatenar.Equals('('))
                        {
                            mensaje += cadenaconcatenar;
                            estadoprincipal = 4;
                        }
                        break;

                    case 4: //TextoMensaje
                        if (char.IsNumber(cadenaconcatenar) || cadenaconcatenar.Equals('+') || cadenaconcatenar.Equals('/') || cadenaconcatenar.Equals('-') || cadenaconcatenar.Equals('*') || cadenaconcatenar.Equals('(') || cadenaconcatenar.Equals(')'))
                        {
                            mensaje += cadenaconcatenar;
                            estadoprincipal = 4;
                        }
                        else if (cadenaconcatenar.Equals('<'))
                        {
                            if (ip != "" || mensaje != "")
                            {
                                AgregaraCola(ip, mensaje);
                                Console.WriteLine(ip + mensaje);
                                ip = "";
                                mensaje = "";
                            }
                            estadoprincipal = 5;
                        }
                        break;

                    case 5: //Mensajes
                        if (char.IsLetter(cadenaconcatenar) || cadenaconcatenar.Equals('>') || cadenaconcatenar.Equals('/'))
                        {
                            estadoprincipal = 5;
                        }
                        else if (cadenaconcatenar.Equals('<'))
                        {
                            estadoprincipal = 1;
                        }
                        break;
                }
            }
        }

        ////////Codigo para agregar
        public void AgregaraCola(string ip, string mensaje)
        {
            NodoCola nodo = new NodoCola();
            nodo.ip = ip;
            nodo.mensaje = mensaje;

            if (mensaje != "")
            {
                foreach (var cola in listaCola)
                {
                    if (cola.mensaje == "")
                    {
                        cola.mensaje = mensaje;
                    }
                }
            }
            else
            {
                listaCola.Add(nodo);
                contadorNodosCola++;
            }
        }


        //////Lista Cola en c#
        public class NodoCola
        {
            public string ip { get; set; }
            public string mensaje { get; set; }
        }
    }
}
