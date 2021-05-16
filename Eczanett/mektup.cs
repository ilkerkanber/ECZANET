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
    public partial class mektup : Form
    {
        public static SqlConnection con;
        public static SqlDataAdapter adap;
        public static SqlCommand komut;

        public static DataSet data;
        public static SqlDataReader read;
        public mektup()
        {
            InitializeComponent();
        }
        public void see()
        {

            listBox1.Items.Clear();
            con = new SqlConnection("Data Source=.;Initial Catalog=ECZANET;Integrated Security=True");
            komut = new SqlCommand("Select * from GERIBILDIRIM where TC="+label1.Text+"", con);
            komut.Connection = con;
            komut.CommandType = CommandType.Text;

            con.Open();
            read = komut.ExecuteReader();
            while (read.Read())
            {
                listBox1.Items.Add(read["GERIBILDIRIM"]);

            }
        }
        private void mektup_Load(object sender, EventArgs e)
        {
            see();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
