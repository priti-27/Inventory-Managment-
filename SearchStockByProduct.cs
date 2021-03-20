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
    public partial class SearchStockByProduct : Form
    {
        public SearchStockByProduct()
        {
            InitializeComponent();
        }
         SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
                 try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
               // StrSql = "select * From machineInfo where  Ltr='" + untltr.Text + "'";
                StrSql = "select * From machineInfo where  Ltr='" + untltr.Text + "' AND  Shape ='" + comboBox2.Text + "' AND Color='" + comboBox3.Text + "' AND Weight='" + comboBox4.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        textBox1.Text = dr["AvaliableStock"].ToString();
                        // textBox3.Text = dr["ActualStock"].ToString();



                    }
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

        private void SearchStockByProduct_Load(object sender, EventArgs e)
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

