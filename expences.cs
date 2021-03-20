using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Golddi_Industries
{
    public partial class expences : Form
    {
        public expences()
        {
            InitializeComponent();
        }
        // this just insertation process using sql command 
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        string StrSql = string.Empty;
        private void txtexp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert  into expences(exptype,amount,date) values (@exptype,@amount,@date)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@exptype", txtexp.Text);
                cmd.Parameters.AddWithValue("@amount", txtamt.Text);
                cmd.Parameters.AddWithValue("@date",Convert.ToDateTime( dtp1.Text));
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("record inserted successfully");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select *  from expences ", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                txtexp.Text = "";
                txtamt.Text = "";
            }
        }

        private void txtamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }
       
        private void expences_Load(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
