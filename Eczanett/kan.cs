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
    public partial class kan : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;
        public static DataSet data;
        public static SqlDataReader read;
        public static int s = 0;
        public kan()
        {
            InitializeComponent();
        }
        public void goster()
        {
            comboBox2.Items.Clear();
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select ilçe from VERI where il='" + comboBox1.Text + "'", con);
            komut.Connection = con;
            komut.CommandType = CommandType.Text;

            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox2.Items.Add(read["ilçe"]);
            } con.Close();
        }
        public void kayıt()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "UPDATE VERI SET TKAN=TKAN+"+textBox1.Text+" WHERE il='"+comboBox1.Text+"'AND ilçe='"+comboBox2.Text+"'";
            komut.ExecuteNonQuery();
          
            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                s = Convert.ToInt32(textBox1.Text);
                if (s > 4) { MessageBox.Show("MAX. 4 MINI KAPSUL VERİLEBİLİR"); s = 0; }
            }
       catch{} }

        private void button1_Click_1(object sender, EventArgs e)
        {
            kayıt();
            if (comboBox1.Text == ""|| comboBox2.Text=="" || textBox1.Text=="") { MessageBox.Show("GEÇERLİ İL GİRİNİZ"); }
            else { MessageBox.Show("KAN VERME İŞLEMİNİZ BAŞARILIYLA GERÇEKLEŞTİ"); }
        }

        private void kan_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            this.Hide();
            F.Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            goster();
        }
    }
}
