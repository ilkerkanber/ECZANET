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
    public partial class SIKAYET : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;

        public static DataSet data;
        public static SqlDataReader read;

        public SIKAYET()
        {
            InitializeComponent();
        }

        public void kayıt()
        {
            String s = "("+comboBox1.Text+") ";
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "INSERT INTO BILDIRIM(TC,ILETI,ZAMAN) VALUES("+label2.Text+",'"+s+richTextBox1.Text+"','"+label3.Text+"')";
           
            komut.ExecuteNonQuery();
            MessageBox.Show("İŞLEM BAŞARILI");
            con.Close();


        }
         public void zaman()
        {
            label3.Text = DateTime.Now.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
      
        private void SIKAYET_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            timer1.Interval = 1000;
            timer1.Start();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            zaman();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
            int l = richTextBox1.TextLength;
            label1.Text = (140
                - l).ToString() + " adet kaldı";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            { MessageBox.Show("ÖNERİ/ŞİKAYET SEÇİNİZ"); }
            else
            {
                kayıt();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            richTextBox1.Enabled = true;
        }

      
    }
}
