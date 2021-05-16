using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Eczanett
{
    public partial class oes : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;
        public static DataSet data;
        public static SqlDataReader read;
        

        public static int say = 0;
        public static Boolean durum = false;

        public oes()
        {
            InitializeComponent();
        }
        public void giriskontrol()
        {
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
                komut = new SqlCommand();
                
                komut.Connection = con;
                komut.CommandText = "SELECT * FROM OESKAYIT WHERE TC=@TC AND SIFRE=@SIFRE";
                komut.Parameters.AddWithValue("@TC", textBox1.Text);
                komut.Parameters.AddWithValue("@SIFRE", textBox2.Text);
                con.Open(); 
                read = komut.ExecuteReader();
                if (read.HasRows) { 
                    MessageBox.Show("GİRİŞ BAŞARILI"); durum = true;  }
                else { MessageBox.Show("HATALI TC VEYA OESNO"); durum = false; }
            }
           
            catch { }
         
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            giriskontrol();
            if (durum==true)
            {
                timer1.Interval = 350;
                timer2.Interval = 350;
                timer3.Interval = 350;
                timer4.Interval = 350;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            while (say != 20) { say++; ovalShape1.Top++; ovalShape1.BackColor = Color.Green; }
            say = 0;
            timer1.Stop(); timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            while (say != 20) { say++; ovalShape2.Top--; ovalShape2.BackColor = Color.Green; }
            say = 0;
            timer2.Stop(); timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            while (say != 20) { say++; ovalShape3.Top++; ovalShape3.BackColor = Color.Green; }
            say = 0;
            timer3.Stop(); timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            while (say != 20) { say++; ovalShape4.Top--; ovalShape4.BackColor = Color.Green; }
            say = 0;
            timer4.Stop();
            timer5.Start();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            
            timer5.Interval = 5;
           
                    oessecım o = new oessecım();
                    o.label13.Text = textBox1.Text;
                    
                    this.Hide();o.Show();
                    timer5.Stop();
              
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oeskayıt oe = new oeskayıt();
            this.Hide();
            oe.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void oes_Load(object sender, EventArgs e)
        {

        }

        private void yETKILIGIRISIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YETKILIKONTROL y = new YETKILIKONTROL();
            this.Hide();
            y.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

     
    }
}
