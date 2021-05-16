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
    public partial class solalt : Form
    {
        public solalt()
        {
            InitializeComponent();
        }

        private void solalt_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer2.Interval = 1000;
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
            drone d = new drone();
            d.Show();
            timer2.Stop();

        }
    }
}
