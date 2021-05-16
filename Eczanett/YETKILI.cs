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
    public partial class YETKILI : Form
    {
        Random r = new Random();
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;

        public static DataSet data;
        public static SqlDataReader read;
        public YETKILI()
        {
            InitializeComponent();
        }

        public void ekle() 
        {
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
                komut = new SqlCommand();
                con.Open();
                komut.Connection = con;
                komut.CommandText = "INSERT INTO ILAC(ILACID,ILACADI,ILACPUAN)VALUES(" + r.Next(0, 500) + ",'" + textBox1.Text + "'," + textBox2.Text + ")";

                komut.ExecuteNonQuery();
                MessageBox.Show("İŞLEM BAŞARILI");
                con.Close();
            }
            catch { ekle(); }
        
        }
        public void see()
        {
           
            listBox1.Items.Clear();
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select * from BILDIRIM ", con);
            komut.Connection = con;
            komut.CommandType = CommandType.Text;

            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                listBox1.Items.Add(read["TC"]+"--"+read["ILETI"]+"--"+read["ZAMAN"]);
               
            }
        }
        public void hastaara()
        {
            try
            {
                String y = "";
                int x = 0;
                con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
                komut = new SqlCommand("Select ILACADI FROM KULLANICI WHERE TC='" + textBox6.Text + "'", con);
                komut.Connection = con;
                komut.CommandType = CommandType.Text;

                con.Open();
                read = komut.ExecuteReader();

                while (read.Read())
                {
                    x++;
                    y = y + x + ".İLAÇ:" + read["ILACADI"] + "\n";

                } con.Close();
                MessageBox.Show(y);
                label12.Text = x.ToString();
            }
            catch { MessageBox.Show("HATA"); }
        
        }
        public void hastaadvs()
        {
            label11.Text = "";
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
                komut = new SqlCommand("Select ADSOYAD FROM OESKAYIT WHERE TC=" + textBox6.Text + "", con);
                komut.Connection = con;
                komut.CommandType = CommandType.Text;

                con.Open();
                read = komut.ExecuteReader();
                while (read.Read())
                {
                    label11.Text = read["ADSOYAD"].ToString();
                } con.Close();
            }
            catch { MessageBox.Show("HATA"); }
        }
        public void GBILDIRIM()
        {
          
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "INSERT INTO GERIBILDIRIM(TC,GERIBILDIRIM)VALUES(" + textBox5.Text + ",'" + textBox4.Text + "')";
            komut.ExecuteNonQuery();
            MessageBox.Show("İŞLEM BAŞARILI");
            con.Close();
 }
        public void ILACSIL()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "DELETE FROM ILAC WHERE ILACID="+textBox3.Text+"";
            komut.ExecuteNonQuery();
            MessageBox.Show("BAŞARIYLA SİLİNDİ");
            con.Close();
        }
        private void YETKILI_Load(object sender, EventArgs e)
        {
            
            see();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ekle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GBILDIRIM();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ILACSIL();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            oes o = new oes();
            this.Hide();
            o.Show();
        }

        private void sIFREDEGISTIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YETKILIPCHANGE p = new YETKILIPCHANGE();
            p.label2.Text = label8.Text;
           
            p.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hastaadvs();
            hastaara();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LÜTFEN ŞİFRENİZİ KİMSEYLE PAYLAŞMAYIN" + "\n" + "Bu formda;" + "\n" + "Hastaların aldığı ilaçları ve sayısını" + "\n" + "Kişisel öneri ve şikayetlerini" + "\n" + "Yeni bir ilaç ekleme çıkarmayı" + "\n" + "gerçekleştirebilirsiniz.İyi günler"); 
        }

        private void yEŞİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Green;
        }

        private void mAVİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Blue;
        }

        private void kIRMIZIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Red;
        }

        private void sİYAHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Black;
        }
    }
}
