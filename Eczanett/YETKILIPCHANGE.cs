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
    public partial class YETKILIPCHANGE : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;

        public static DataSet data;
        public static SqlDataReader read;
        public YETKILIPCHANGE()
        {
            InitializeComponent();
        }
        public void kayıt()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "UPDATE YETKILI SET YETKILISN='" + textBox1.Text + "' WHERE YETKILISN=" + label2.Text + "";
            komut.ExecuteNonQuery();
            MessageBox.Show("BAŞARIYLA DEĞİŞTİRİLDİ");
            con.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            kayıt();
        }

        private void YETKILIPCHANGE_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
