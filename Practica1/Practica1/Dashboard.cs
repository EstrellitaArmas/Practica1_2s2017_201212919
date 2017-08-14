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

namespace Practica1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            string url = "http://127.0.0.1:5000/get_my_ip";
            txtIp.Text = HttpGet(url);

        }
        public static string HttpGet(string URI)
        {
            WebRequest req = System.Net.WebRequest.Create(URI);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        public static string HttpPost(string URI, string Parameters)
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
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               StreamReader sr = new StreamReader(openFileDialog1.FileName);
               String json = sr.ReadToEnd();

                string url = "http://127.0.0.1:5000/cargaJSON";
                MessageBox.Show(HttpPost(url, json));

                sr.Close();
            }

            //WebRequest request = WebRequest.Create("http://127.0.0.1:5000/metodo2");
            //request.Credentials = CredentialCache.DefaultCredentials;
            //request.Method = "POST";
            //string postData = "This is a test that posts this string to a Web server.";
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //// Set the ContentType property of the WebRequest.
            //request.ContentType = "/h";
            //// Set the ContentLength property of the WebRequest.
            //request.ContentLength = byteArray.Length;
            //// Get the request stream.
            //Stream dataStream = request.GetRequestStream();
            //// Write the data to the request stream.
            //dataStream.Write(byteArray, 0, byteArray.Length);
            //// Close the Stream object.
            //dataStream.Close();
            //// Get the response.
            //WebResponse response = request.GetResponse();
            //// Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //// Get the stream containing content returned by the server.
            //dataStream = response.GetResponseStream();
            //// Open the stream using a StreamReader for easy access.
            //StreamReader reader = new StreamReader(dataStream);
            //// Read the content.
            //string responseFromServer = reader.ReadToEnd();
            //// Display the content.
            //Console.WriteLine(responseFromServer);
            //// Clean up the streams.
            //reader.Close();
            //dataStream.Close();
            //response.Close();

        }            

    }
}
