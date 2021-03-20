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
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;


        private string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 10000000) > 0)
            {
                words += ConvertNumbertoWords(number / 10000000) + " CRORE ";
                number %= 10000000;
            }
            if ((number / 100000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAC ";
                number %= 100000;

            }
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " -" + unitsMap[number % 10];
                }
            }
            return words;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select CustomerName,Date,Contact,ProductName,Can,Color,Shape,Weight,Qty,Amount,Total from MyOrder where OrderNo='" + textBox1.Text + "' ", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }


            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From MyOrder where OrderNo ='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr["CustomerName"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }


            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From MyOrder where CustomerName ='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox7.Text = dr["Nettotal"].ToString();
                        textBox8.Text = dr["sgstr"].ToString();
                        textBox9.Text = dr["cgstr"].ToString();
                        textBox10.Text = dr["igstr"].ToString();
                        textBox11.Text = dr["GrandTotal"].ToString();
                        textBox12.Text = dr["sgsta"].ToString();
                        textBox13.Text = dr["cgsta"].ToString();
                        textBox14.Text = dr["igsta"].ToString();
                        textBox15.Text = dr["Advance"].ToString();
                        textBox16.Text = dr["Balance"].ToString();
                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }

            //try {if (textBox1.Text==String.Empty)
            
            //{
            //    //textBox16.Text="0";
            //    //textBox3.Text="0";
            //    //textBox4.Text="0";
            
            //}
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewCustomer nw = new NewCustomer();
            nw.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                // StrSql = "insert into MyOrder(CustomerName,Date,Contact,ProductName,Can,Qty,Amount,Total) values  (@CustomerName,@Date,@Contact,@ProductName,@Can,@Qty,@Amount,@Total)";
                StrSql = "update MyOrder Set Paid=@Paid,Bal=@Bal Where OrderNo='" + textBox1.Text + "'AND GrandTotal != 0";
                // StrSql = "insert into order values";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@Paid", textBox3.Text);
                cmd.Parameters.AddWithValue("@Bal", textBox4.Text);
               // cmd.Parameters.AddWithValue("@SaleDate", dateTimePicker1.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Paid");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                Invoice iv = new Invoice();
                iv.ShowDialog();

            }
            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                // StrSql = "insert into MyOrder(CustomerName,Date,Contact,ProductName,Can,Qty,Amount,Total) values  (@CustomerName,@Date,@Contact,@ProductName,@Can,@Qty,@Amount,@Total)";
                StrSql = "update MyOrder Set SaleDate=@SaleDate Where OrderNo='" + textBox1.Text + "'";
                // StrSql = "insert into order values";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                //cmd.Parameters.AddWithValue("@Paid", textBox3.Text);
                //cmd.Parameters.AddWithValue("@Bal", textBox4.Text);
                 cmd.Parameters.AddWithValue("@SaleDate", dateTimePicker1.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Paid");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
               // Invoice iv = new Invoice();
               // iv.ShowDialog();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != String.Empty)
            {
                float v1 = float.Parse(textBox16.Text);
                float v2 = float.Parse(textBox3.Text);
                float v3 = v1 - v2;
                textBox4.Text = v3.ToString();

            }
            if (textBox3.Text == String.Empty)
            {

                float v2 = float.Parse(textBox4.Text);
                float v3 = v2 * 0;
                textBox4.Text = v3.ToString();

            }
           
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Sale_Load(object sender, EventArgs e)
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == String.Empty)
            {
                textBox11.Text = "0";
                //textBox5.Text = ConvertNumbertoWords(int.Parse(textBox11.Text));
            }
            else {
                textBox5.Text = ConvertNumbertoWords(int.Parse(textBox11.Text));
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
