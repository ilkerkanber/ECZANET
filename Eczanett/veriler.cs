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
    public partial class veriler : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut,komut2;

        public static DataSet data;
        public static SqlDataReader read;

        public static int toplamhasta = 0;
        public static String s;
        public veriler()
        {
            InitializeComponent();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
        public void hastasayısı()
        {
            toplamhasta = 0;
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select * from KULLANICI ", con);
     
            komut.Connection = con;
           
            komut.CommandType = CommandType.Text;

            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                toplamhasta++;
            }
            con.Close();
            MessageBox.Show("ÜLKEDE TÜKETİLEN TOPLAM İLAÇ SAYISI :"+toplamhasta.ToString());
        }
        public void illerhastasayısı()
        {
            try
            {
                toplamhasta = 0;
                con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
                komut = new SqlCommand("Select * from ADRES WHERE IL='" + comboBox1.Text + "' ", con);
                komut2 = new SqlCommand("SELECT SUM(tkan) FROM VERI WHERE il='" + comboBox1.Text + "'", con);
                komut.Connection = con; 
                komut.CommandType = CommandType.Text;

                con.Open();
                read = komut.ExecuteReader();
                while (read.Read())
                {
                    toplamhasta++;
                }
                
                con.Close();
                MessageBox.Show(comboBox1.Text + " \n " + "TOPLAM DRONE KULLANACAK HASTA SAYISI:" + toplamhasta.ToString());
            }
            catch { MessageBox.Show("GİRDİ YOK"); }
        }
        public void toplamkan()
        {

            s = "";
              con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
               komut = new SqlCommand("SELECT SUM(tkan) FROM VERI WHERE il='" + comboBox1.Text + "'", con);
                komut.Connection = con;
                komut.CommandType = CommandType.Text;

                con.Open();
                read = komut.ExecuteReader();
                while (read.Read())
                {
                    s = read[""].ToString();
                }
                MessageBox.Show(comboBox1.Text+"\n"+"TOPLAM KAN: " + s);

                con.Close();
         
           
        }
        public void ulketoplamkan()
        {

            s = "";
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("SELECT SUM(tkan) FROM VERI ", con);
            komut.Connection = con;
            komut.CommandType = CommandType.Text;

            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                s = read[""].ToString();
            }
            MessageBox.Show("ÜLKEDE TOPLANAN MINI KAPSULLU KAN TOPLAMI: " + s);

            con.Close();


        }



        private void button82_Click(object sender, EventArgs e)
        {
            hastasayısı();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            toplamkan();
            illerhastasayısı();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button81_Click(object sender, EventArgs e)
        {
            ulketoplamkan();
        }
    }
}
