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
    public partial class oeskayıt : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;
        public static DataSet data;
        public oeskayıt()
        {
            InitializeComponent();
        }

        private void oeskayıt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eCZANETDataSet4.OESKAYIT' table. You can move, or remove it, as needed.
            this.oESKAYITTableAdapter.Fill(this.eCZANETDataSet4.OESKAYIT);
            // TODO: This line of code loads data into the 'eCZANETDataSet3.OESKAYIT' table. You can move, or remove it, as needed.
          
            yenile();
            

        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 11) { MessageBox.Show("EKSİK TC"); }
            else if (textBox2.Text == "") { MessageBox.Show("ADSOYAD BOŞ BIRAKILAMAZ"); }
            else if (textBox3.Text == "") { MessageBox.Show("YAŞ BOŞ BIRAKILAMAZ"); }
            else if (comboBox1.Text == "") { MessageBox.Show("CİNSİYET SEÇİNİZ"); }
            else if (textBox5.Text == "") { MessageBox.Show("TELEFON NO YAZINIZ"); }
            else if (textBox5.TextLength < 11) { MessageBox.Show("EKSİK TELNO"); }
            else if (comboBox2.Text == "") { MessageBox.Show("SAĞLIK GÜVENCESİNİ SEÇİNİZ"); }
            else if (textBox7.Text == "" || textBox8.Text == "") { MessageBox.Show("ŞİFRE ALANI BOŞ BIRAKILAMAZ"); }
            else if (textBox7.Text != textBox8.Text)
             {
                 MessageBox.Show("Şifreniz uyuşmuyor");
             }
             else
            {
                MessageBox.Show("KAYDINIZ TAMAMLANDI");
                 ekle();
                 yenile();
             }
        }
        public void yenile()
        {

            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            adap = new SqlDataAdapter("Select * from OESKAYIT",con);
            data = new DataSet();
            con.Open();
            adap.Fill(data, "OESKAYIT");
            dataGridView1.DataSource = data.Tables["OESKAYIT"];
            con.Close();
           
        }
        public void ekle()
        {   
            try{
                komut = new SqlCommand();
                con.Open();
                komut.Connection = con;
                komut.CommandText = "insert into OESKAYIT(TC,SIFRE,ADSOYAD,YAS,CINSIYET,TELNO,SAGLIKGUVENCE,PUAN) values ( " + textBox1.Text + "," + textBox7.Text + ",'" + textBox2.Text + "'," + textBox3.Text + ",'" + comboBox1.Text + "'," + textBox5.Text + ",'" + comboBox2.Text + "'," + 0 + ")";
                komut.ExecuteNonQuery();
                con.Close();
                yenile();
            }
                catch{}
           
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void ovalShape9_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 11) { MessageBox.Show("EKSİK TC"); }
            else if (textBox2.Text == "") { MessageBox.Show("ADSOYAD BOŞ BIRAKILAMAZ"); }
            else if (textBox3.Text == "") { MessageBox.Show("YAŞ BOŞ BIRAKILAMAZ"); }
            else if (comboBox1.Text == "") { MessageBox.Show("CİNSİYET SEÇİNİZ"); }
            else if (textBox5.Text == "") { MessageBox.Show("TELEFON NO YAZINIZ"); }
            else if (textBox5.TextLength < 11) { MessageBox.Show("EKSİK TELNO"); }
            else if (comboBox2.Text == "") { MessageBox.Show("SAĞLIK GÜVENCESİNİ SEÇİNİZ"); }
            else if (textBox7.Text == "" || textBox8.Text == "") { MessageBox.Show("ŞİFRE ALANI BOŞ BIRAKILAMAZ"); }
            else if (textBox7.Text != textBox8.Text)
            {
                MessageBox.Show("Şifreniz uyuşmuyor");
            }
            else
            {
                MessageBox.Show("KAYDINIZ TAMAMLANDI");
                ekle();
                yenile();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
