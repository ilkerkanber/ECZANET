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
    public partial class PAROLADEGIS : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;

        public static DataSet data;
        public static SqlDataReader read;
        public PAROLADEGIS()
        {
            InitializeComponent();
        }
        public void kayıt()
        {
                con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
                komut = new SqlCommand();
                con.Open();
                komut.Connection = con;
                komut.CommandText = "UPDATE OESKAYIT SET SIFRE='" + textBox4.Text + "' WHERE TC=" + label5.Text + "";
                komut.ExecuteNonQuery();
                MessageBox.Show("İŞLEM BAŞARILI");
                con.Close();
             }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text == textBox4.Text))
            {
                kayıt();
            }
            else { MessageBox.Show("ŞİFRE UYUŞMUYOR"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PAROLADEGIS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eCZANETDataSet6.OESKAYIT' table. You can move, or remove it, as needed.
            this.oESKAYITTableAdapter.Fill(this.eCZANETDataSet6.OESKAYIT);

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }
    }
}
