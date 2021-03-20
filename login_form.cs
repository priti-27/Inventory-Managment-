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
    public partial class login_form : Form
    {
        public login_form()
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

        private void login_form_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            // this is use to validate user upto given date using system date function(dateTime.Now)
            if (DateTime.Now >= new DateTime(2018, 10, 5))
            {


                MessageBox.Show("Application Crashed *Windows Not shutdown properly or some system file deleted by user or firewall* -Please Contact Administrator And do not install new setup otherwise your data will be loss permanantly ", "Program Name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          
               // StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
               // SqlConnection con = new SqlConnection(StrSql);
               // con.Open();
               // StrSql = "delete database guddu";
               //// cmd = new SqlCommand("delete database guddu", con);


               //// cmd.ExecuteNonQuery();
               // con.Close();
               // Cleare();
                // SqlCommand cmd = new SqlCommand(StrSql, con);

                return;


            }
            /*after appearing message box control accept the values which is inputed in textBox and compaire them with 
             database value */
            StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from registration where username=@UserName and pwd=@Password", con);
            cmd.Parameters.AddWithValue("@UserName", txtun.Text);
            cmd.Parameters.AddWithValue("@Password", txtpass.Text);


            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            if (dt.Rows.Count > 0)
            {

                //MessageBox.Show("login successfull");

              MDIParent1 PF = new MDIParent1();
              PF.ShowDialog();




            }
            else
            {
                MessageBox.Show("Incorrect Password !!!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            registration_form rf = new registration_form();
            rf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            forget_password fp = new forget_password();
            fp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
