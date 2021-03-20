using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Golddi_Industries
{
    public partial class Weight : Form
    {
        public Weight()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            StrSql = "insert into grm (grm) values (@grm)";
            SqlCommand cmd = new SqlCommand(StrSql, con);
            cmd.Parameters.AddWithValue("@grm", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Weight Added Successfully");
            textBox1.Text = "";
        }
    }
}
