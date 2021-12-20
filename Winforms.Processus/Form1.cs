using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms.Processus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/search?q=" + txtRecherche.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                txtFile.Text = fileName;
                btnOuvrir.Visible = true;

            }
   

        }

        private void btnOuvrir_Click(object sender, EventArgs e)
        {
            Process.Start(txtFile.Text);
            txtFile.Text = "";
            btnOuvrir.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Récupérer les infos mémoire:

            double giga = 1024 * 1024 * 1024;
            ComputerInfo info = new ComputerInfo();
            lblTotale.Text = Math.Round(info.TotalPhysicalMemory / giga,2).ToString();
            lblDispo.Text = (info.AvailablePhysicalMemory / giga).ToString(".00");
            lblUtilisee.Text = ((info.TotalPhysicalMemory - info.AvailablePhysicalMemory) / giga).ToString(".00");
            lblApplication.Text = (Process.GetCurrentProcess().WorkingSet64 / giga).ToString(".00");

            //Affichage de l'heure
            lblHeure.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHeure.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
