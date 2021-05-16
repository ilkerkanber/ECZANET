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
    public partial class drone : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;
        public static DataSet data;
        public static SqlDataReader read;
        public drone()
        {
            InitializeComponent();
        }
        public void zaman()
        {
            textBox8.Text = DateTime.Now.ToString();
        
        }
        public void yenile()
        {

            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            adap = new SqlDataAdapter("Select * from ADRES", con);
            data = new DataSet();
            con.Open();
            adap.Fill(data, "ADRES");
            dataGridView1.DataSource = data.Tables["ADRES"];
            con.Close();

        }
        public void goster()
        {
            comboBox2.Items.Clear();
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select ilçe from VERI where il='"+comboBox1.Text+"'", con);
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
            komut = new SqlCommand();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "insert into ADRES(HASTATC,IL,ILCE,MAHALLE,CADDE,APARTMAN,DAIRE,KTARIH) VALUES('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+textBox7.Text+"','"+textBox8.Text+"')";
            komut.ExecuteNonQuery();
            MessageBox.Show("İŞLEM BAŞARILI");
            con.Close();
            yenile();
        }

        private void drone_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eCZANETDataSet2.ADRES' table. You can move, or remove it, as needed.
            this.aDRESTableAdapter.Fill(this.eCZANETDataSet2.ADRES);
        
            yenile();
            timer1.Start();
           

        }

        private void comboBox1_MouseMove(object sender, MouseEventArgs e)
        {
            goster();
        }

        private void comboBox2_MouseMove(object sender, MouseEventArgs e)
        {
            goster();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            zaman();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 11 && comboBox1.Text != "" && comboBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "")
                try
                {

                    kayıt();
                }
                catch { }
            else { MessageBox.Show("EKSİK YER BIRAKMAYINIZ"); }
        }

        private void rectangleShape9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }     
    }
}
