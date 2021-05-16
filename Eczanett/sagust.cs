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
    public partial class sagust : Form
    {
        public sagust()
        {
            InitializeComponent();
        }

        private void sagust_Load(object sender, EventArgs e)
        {
            timer1.Interval = 3400;
            timer2.Interval = 700;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.Hide();
            timer1.Stop();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            kan k = new kan();
            k.Show();
            timer2.Stop();
        }
    }
}
