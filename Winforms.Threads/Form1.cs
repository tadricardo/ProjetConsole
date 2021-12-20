using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms.Threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Simuler une t^che qui dure 5 secondes
            //Thread.Sleep(5000);

            //Isolation de la tâche bloquante dans un Thread
            Thread t = new Thread(() => Thread.Sleep(5000));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tâche2.........");
        }
    }
}
