using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eczanett
{
    public partial class Acılıs : Form
    {
        public Acılıs()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            timer1.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Acılıs_Load(object sender, EventArgs e)
        {
            timer1.Interval = 4100;
            timer1.Start();
        }
    }
}
