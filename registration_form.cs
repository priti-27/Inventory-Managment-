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

namespace Golddi_Industries
{
    public partial class registration_form : Form
    {
        public registration_form()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        string StrSql = string.Empty;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void CLEAR()
        {
            txtname.Text = "";
            txtaddr.Text = "";
            txtun.Text = "";
            txtpass.Text = "";
            txtcpass.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert  into registration(Name,address,username,dob,pwd,cnf_pwd) values (@name,@addr,@uname,@dob,@pass,@cnpass)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@addr", txtaddr.Text);
                cmd.Parameters.AddWithValue("@uname", txtun.Text);
                cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(txtdob.Text));
                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                cmd.Parameters.AddWithValue("@cnpass", txtcpass.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("User Created");
                CLEAR();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            CLEAR();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registration_form_Load(object sender, EventArgs e)
        {

        }
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
    }
}
