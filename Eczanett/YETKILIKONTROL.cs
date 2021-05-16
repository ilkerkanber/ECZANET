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
    public partial class YETKILIKONTROL : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;
        public static DataSet data;
        public static SqlDataReader read;
        public YETKILIKONTROL()
        {
            InitializeComponent();
        }

        private void YETKILIKONTROL_Load(object sender, EventArgs e)
        {

        }

        public void join()
        {
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
                komut = new SqlCommand();

                komut.Connection = con;
                komut.CommandText = "SELECT * FROM YETKILI WHERE YETKILISN=@YETKILISN ";
                komut.Parameters.AddWithValue("@YETKILISN", textBox1.Text);
             
                con.Open();
                read = komut.ExecuteReader();
                if (read.HasRows)
                {
                    MessageBox.Show("GİRİŞ BAŞARILI"); 
                    YETKILI y = new YETKILI();
                   
                    y.label8.Text = textBox1.Text;
                        
                    this.Hide();
                    y.Show();
                }
                else { MessageBox.Show("HATALI GİRİŞ"); }
            }

            catch { }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            join();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
