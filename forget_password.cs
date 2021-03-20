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
    public partial class forget_password : Form
    {
        public forget_password()
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsp_Click(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            try
            {
                
                // strsql = "select name,category,company, avalible_stock, supplyer_name, date, address, gst, sgst, sgst_rs, amount, total, net, gst_rs from product where category like'" + cmbcat1.text + "%' and name like'" + cmbname.text + "%' and company like'" + cmbcmp.text + "%'  ";
                StrSql = "select * from registration where username = '"+txtun.Text+"' AND dob = '"+txtdob.Text+"'";
               
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        txtyp.Text = dr["pwd"].ToString();
                        //cmbcat.text = dr["category"]Tostring();
                     



                    }
                }
                else
                {
                    MessageBox.Show("invalid username or date of birth");
                }
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

        private void forget_password_Load(object sender, EventArgs e)
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
