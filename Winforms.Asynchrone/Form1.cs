using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms.Asynchrone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Appel de la méthode synchrone
            //DownloadHTML("http://www.dawan.fr");

            //Appel de la méthode Asynchrone
            await DownloadHTMLAsync("http://www.dawan.fr");

           
        }

        //Méthode synchrone
        public void DownloadHTML(string url)
        {
            //Simulation d'une tâche boquante
            var webClient = new WebClient();
            Thread.Sleep(2000);
            var html = webClient.DownloadString(url);
            using (var sw = new StreamWriter(@"c:\monRep\html.txt"))
            {
                sw.Write(html);
            }

        }

        //Méthode Asynchrone
        public async Task DownloadHTMLAsync(string url)
        {
            var webClient = new WebClient();
            string html = await webClient.DownloadStringTaskAsync(url);
            //Thread.Sleep(5000);
            await Task.Delay(5000);
            using (var sw = new StreamWriter(@"c:\monRep\html2.txt"))
            {
                await sw.WriteAsync(html);
            }
        }

        private void Afficher(object sender, EventArgs e)
        {
           
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            lblTelecherger.Text = "Traitement du fichier. Patientez SVP........";
            int nb = await nombreCharAsync();
            lblTelecherger.Text = "Le nombre de caractères: " + nb;
        }

        public async Task<int> nombreCharAsync()
        {
            //Simulation d'une tâche bloquante
            int count = 0;
            var sr = new StreamReader(@"c:\monRep\html.txt");
            var contenu = await sr.ReadToEndAsync();
            count = contenu.Length;
            await Task.Delay(5000);
            return count;
        }
    }
}
