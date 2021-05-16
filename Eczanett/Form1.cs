using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Eczanett
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphicsPath sekil = new GraphicsPath();
            sekil.AddEllipse(0, 0, this.Width, this.Height);
            Region sekilbolge = new Region(sekil);
            this.Region = sekilbolge;
        }

        private void ovalShape2_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape2.BackColor = Color.Green;
            label1.BackColor = Color.Green;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape3.BackColor = Color.Green;
            label2.BackColor = Color.Green;
        }

        private void ovalShape3_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape3.BackColor = Color.Green;
            label2.BackColor = Color.Green;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape2.BackColor = Color.Green;
            label1.BackColor = Color.Green;
        }

        private void ovalShape4_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape4.BackColor = Color.Green;
            label3.BackColor = Color.Green;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape4.BackColor = Color.Green;
            label3.BackColor = Color.Green;
        }

        private void ovalShape5_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape5.BackColor = Color.Green;
            label4.BackColor = Color.Green;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape5.BackColor = Color.Green;
            label4.BackColor = Color.Green;
        }

        private void ovalShape1_MouseMove(object sender, MouseEventArgs e)
        {
            ovalShape2.BackColor = Color.White;
            ovalShape3.BackColor = Color.White;
            ovalShape4.BackColor = Color.White;
            ovalShape5.BackColor = Color.White;
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
            label3.BackColor = Color.White;
            label4.BackColor = Color.White;
        }

        private void lineShape1_MouseMove(object sender, MouseEventArgs e)
        {
            {
                ovalShape2.BackColor = Color.White;
                ovalShape3.BackColor = Color.White;
                ovalShape4.BackColor = Color.White;
                ovalShape5.BackColor = Color.White;
            }
        }

        private void lineShape2_MouseMove(object sender, MouseEventArgs e)
        {
            {
                ovalShape2.BackColor = Color.White;
                ovalShape3.BackColor = Color.White;
                ovalShape4.BackColor = Color.White;
                ovalShape5.BackColor = Color.White;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            solust s = new solust();
            s.Show();
            this.Hide();
        }

        private void ovalShape2_Click(object sender, EventArgs e)
        {
            solust s = new solust();
            s.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            sagust s = new sagust();
            this.Hide();
            s.Show();
        }

        private void ovalShape3_Click(object sender, EventArgs e)
        {
            sagust s = new sagust();
            this.Hide();
            s.Show();
        }

        private void ovalShape5_Click(object sender, EventArgs e)
        {
            sagalt s = new sagalt();
            this.Hide();
            s.Show();
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            sagalt s = new sagalt();
            this.Hide();
            s.Show();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            solalt s = new solalt();
            this.Hide();
            s.Show();
        }

        private void ovalShape4_Click(object sender, EventArgs e)
        {
            solalt s = new solalt();
            this.Hide();
            s.Show();
        }

        private void ovalShape2_MouseLeave(object sender, EventArgs e)
        {
            ovalShape2.BackColor = Color.White;
            label1.BackColor = Color.White;
        }

        private void ovalShape4_MouseLeave(object sender, EventArgs e)
        {
            ovalShape4.BackColor = Color.White;
            label3.BackColor = Color.White;
        }

        private void ovalShape5_MouseLeave(object sender, EventArgs e)
        {
            ovalShape5.BackColor = Color.White;
            label4.BackColor = Color.White;
        }

        private void ovalShape3_MouseLeave(object sender, EventArgs e)
        {
            ovalShape3.BackColor = Color.White;
            label2.BackColor = Color.White;
        }
    }
}