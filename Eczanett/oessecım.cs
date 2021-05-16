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
    public partial class oessecım : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;
      
        public static DataSet data;
        public static SqlDataReader read;


        public oessecım()
        {
            InitializeComponent();
        }

        public void veriler()
        
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select * from OESKAYIT where TC=" + label13.Text + "", con);
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                label2.Text = read["ADSOYAD"].ToString();
                label9.Text = read["YAS"].ToString();
                label10.Text = read["CINSIYET"].ToString();
                label11.Text = read["SAGLIKGUVENCE"].ToString();
          
            } con.Close();
        
        }
        public void goster()
        {
            comboBox1.Items.Clear();
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select ILACADI from ILAC ", con);
            komut.Connection = con;
            komut.CommandType = CommandType.Text;

            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["ILACADI"]);
            } con.Close();
        }

        public void ilacpuan()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select ILACPUAN from ILAC where ILACADI='" + comboBox1.Text + "'", con);
            komut.Connection = con;
            komut.CommandType = CommandType.Text;

            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                label8.Text = read["ILACPUAN"].ToString();
               

            } con.Close();
        }
        public void zaman()
        {
            label5.Text = DateTime.Now.ToString();

        }

        public void ekle()
        {
              komut = new SqlCommand();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "INSERT INTO KULLANICI(TARIH,YAS,CINSIYET,SAGLIKGUVENCE,ILACADI,DRONEAKTIF,HPUAN,TC)VALUES('"+label5.Text+"',"+label9.Text+",'"+label10.Text+"','"+label11.Text+"','"+comboBox1.Text+"','',"+label8.Text+","+label13.Text+")";
                
            komut.ExecuteNonQuery();
            MessageBox.Show("İŞLEM BAŞARILI");
            con.Close();
        }
        public void richtegoster()
        {
            listBox1.Items.Clear();
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select * from KULLANICI where TC='" +label13.Text+ "'", con);
            komut.Connection = con;
            komut.CommandType = CommandType.Text;

            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                listBox1.Items.Add(read["TARIH"]+" "+label13.Text+" "+label2.Text+" "+read["YAS"]+" "+read["CINSIYET"]+" "+read["ILACADI"]+" "+read["HPUAN"]).ToString();
            } 
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            ekle();
            richtegoster();
        }

        private void oessecım_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eCZANETDataSet5.ILAC' table. You can move, or remove it, as needed.
            this.iLACTableAdapter.Fill(this.eCZANETDataSet5.ILAC);
            richtegoster();
            
            veriler();
            goster();
            timer1.Start();

        }

        private void comboBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ilacpuan();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            zaman();
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void öneriŞikayetKutusuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIKAYET s = new SIKAYET();
            s.label2.Text = label13.Text;
            s.Show();
        }

        private void parolaDeğiştirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PAROLADEGIS s = new PAROLADEGIS();
            s.label5.Text = label13.Text;
            s.Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            ilacpuan();
        }

        private void kırmızıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Red;

        }

        private void maviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Blue;
        }

        private void turuncuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Orange;
        }

        private void yeşilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Green;
        }

        private void beyazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.White;
        }

        private void şikayetGeribildirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Şikayet Geri Bildirim Süresi Ortalama 1 ile 2 Hafta Arasında Değişir.."); 
        }

        private void öneriGeribildirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Öneriler İçin Geri Bildirim Genellikle Yapılmaz.."); 
        }

        private void droneUygunluguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ev Adresinizin Uygunluğu İçin En Kısa Zamanda Haber Verilir(3 ile 5 gün arası)");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oes o = new oes();
            this.Hide();
            o.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mektup m = new mektup();
            m.label1.Text = label13.Text;
            m.Show();
        }
    }
}
