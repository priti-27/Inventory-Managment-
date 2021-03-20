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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            ClassBind2();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string StrSql = string.Empty;
        public void CLR()
        {
            textBox1.Text = "";
            textBox6.Text = "";
            date.Text = "";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
            textBox15.Text = "0";
            textBox16.Text = "0";
            textBox19.Text = "";
            textBox1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "0";
            textBox27.Text = "0";
            textBox26.Text = "0";
            textBox25.Text = "0";
            textBox8.Text = "0";
            textBox24.Text = "";


        }


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
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != String.Empty)
            {
                double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(textBox3.Text);
                double v3 = v1 * v2;
                textBox5.Text = v3.ToString();
            }
            else
            {
                double v1 = double.Parse(textBox3.Text);
                double v2 = v1 * 0;
                textBox5.Text = v2.ToString();
            }

           

        }
        public void ClassBind2()
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                DataRow dr;
                StrSql = "select * from  grm";
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                    cmd = new SqlCommand(StrSql, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { 0, "grm" };
                    dt.Rows.InsertAt(dr, 0);

                    comboBox4.ValueMember = "Id";


                    comboBox4.DisplayMember = "grm";
                    comboBox4.DataSource = dt;
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                double v1 = double.Parse(textBox5.Text);
                double v2 = double.Parse(textBox7.Text);
                double v3 = v1 + v2;
                textBox7.Text = v3.ToString();

                try
                {

                    StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    con = new SqlConnection(StrSql);
                    con.Close();
                    con.Open();
                    StrSql = "insert into MyOrder(CustomerName,Date,Contact,ProductName,Can,Qty,Amount,Total,HSN, Color,Shape,Weight,OrderNo,OD) values  (@CustomerName,@Date,@Contact,@ProductName,@Can,@Qty,@Amount,@Total,@HSN,@Color,@Shape,@Weight,@OrderNo,@OD)";
                   // StrSql = "insert into order values";
                    SqlCommand cmd = new SqlCommand(StrSql, con);
                    cmd.Parameters.AddWithValue("@CustomerName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(date.Text));
                    cmd.Parameters.AddWithValue("@Contact", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ProductName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Can", untltr.Text);
                    cmd.Parameters.AddWithValue("@Qty", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Amount", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Total", textBox5.Text);
                    cmd.Parameters.AddWithValue("@HSN", textBox20.Text);
                    cmd.Parameters.AddWithValue("@Color", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@Shape", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Weight", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@OrderNo", textBox21.Text);
                    cmd.Parameters.AddWithValue("@OD", dateTimePicker1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("can added into the Memo"); 

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();

                }

                try
                {

                    StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    con = new SqlConnection(StrSql);
                    con.Close();
                    con.Open();
                   // StrSql = "insert into MyOrder(CustomerName,Date,Contact,ProductName,Can,Qty,Amount,Total) values  (@CustomerName,@Date,@Contact,@ProductName,@Can,@Qty,@Amount,@Total)";
                    StrSql = "update machineinfo Set AvaliableStock=@AvaliableStock where Ltr='" + untltr.Text + "' AND  Shape ='" + comboBox2.Text + "' AND Color='" + comboBox3.Text + "' AND Weight='" + comboBox4.Text + "'";
                    // StrSql = "insert into order values";
                    SqlCommand cmd = new SqlCommand(StrSql, con);
                    cmd.Parameters.AddWithValue("@AvaliableStock", textBox18.Text);
                    

                    cmd.ExecuteNonQuery();
                   // MessageBox.Show("can added into the Memo");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    textBox20.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "0";
                    textBox4.Text = "0";
                    untltr.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";





                }

              
                
            }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != String.Empty)
            {

                double v1 = double.Parse(textBox25.Text);
                double v2 = double.Parse(textBox8.Text);
                double v3 = v1 * v2 / 100;
                textBox12.Text = v3.ToString();

            }
            if (textBox8.Text == String.Empty)
            {
             
                double v2 = double.Parse(textBox12.Text);
                double v3 = v2 * 0;
                textBox12.Text = v3.ToString();
               
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != String.Empty)
            {

                double v1 = double.Parse(textBox25.Text);
                double v2 = double.Parse(textBox9.Text);
                double v3 = v1 * v2 / 100;
                textBox13.Text = v3.ToString();

            }
            if (textBox9.Text == String.Empty)
            {
                double v2 = double.Parse(textBox13.Text);
                double v3 = v2 * 0;
                textBox13.Text = v3.ToString();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != String.Empty)
            {

                double v1 = double.Parse(textBox25.Text);
                double v2 = double.Parse(textBox10.Text);
                double v3 = v1 * v2 / 100;
              
                textBox14.Text = v3.ToString();

            }
            if (textBox10.Text == String.Empty)
            {
                double v2 = double.Parse(textBox14.Text);
                double v3 = v2 * 0;
                textBox14.Text = v3.ToString();
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

            if (textBox15.Text == String.Empty)
            {
                textBox15.Text = "0";
                double v7 = double.Parse(textBox16.Text);
                double v6 = v7 * 0;
                textBox16.Text = v6.ToString();

            }
            double v3 = double.Parse(textBox15.Text);
            double v4 = double.Parse(textBox11.Text);
            double v5 = v4 - v3;
            textBox16.Text = v5.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                StrSql = "insert into MyOrder(Date,CustomerName,Contact,Nettotal,sgstr,cgstr,igstr,sgsta,cgsta,igsta,GrandTotal,Advance,Balance,GSTIN,HSN,OrderNo,OD,Word,Dis,DisR,NewT) values  ( @Date,@CustomerName,@Contact,@Nettotal,@sgstr,@cgstr,@igstr,@sgsta,@cgsta,@igsta,@GrandTotal,@Advance,@Balance,@GSTIN,@HSN,@OrderNo,@OD,@Word,@Dis,@DisR,@NewT)";
                // StrSql = "insert into order values";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@CustomerName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Date", date.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox6.Text);
                cmd.Parameters.AddWithValue("@ProductName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Nettotal", textBox7.Text);
                cmd.Parameters.AddWithValue("@sgstr", textBox8.Text);
                cmd.Parameters.AddWithValue("@cgstr", textBox9.Text);
                cmd.Parameters.AddWithValue("@igstr", textBox10.Text);
                cmd.Parameters.AddWithValue("@sgsta", textBox12.Text);
                cmd.Parameters.AddWithValue("@cgsta", textBox13.Text);
                cmd.Parameters.AddWithValue("@igsta", textBox14.Text);
                //cmd.Parameters.AddWithValue("@igsta", textBox14.Text);
                cmd.Parameters.AddWithValue("@GrandTotal", textBox11.Text);
                cmd.Parameters.AddWithValue("@Advance", textBox15.Text);
                cmd.Parameters.AddWithValue("@Balance", textBox16.Text);
                cmd.Parameters.AddWithValue("@GSTIN", textBox19.Text);
                cmd.Parameters.AddWithValue("@HSN", textBox20.Text);
                cmd.Parameters.AddWithValue("@OrderNo", textBox21.Text);
                cmd.Parameters.AddWithValue("@OD", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Word", textBox24.Text);
                cmd.Parameters.AddWithValue("@Dis", textBox27.Text);
                cmd.Parameters.AddWithValue("@DisR", textBox26.Text);
                cmd.Parameters.AddWithValue("@NewT", textBox25.Text);
                //cmd.Parameters.AddWithValue("@Word", textBox24.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Memo Created");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from MyOrder where OrderNo='" + textBox21.Text + "' ", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();


            }
            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                StrSql = "update MyOrder Set Word=@Word, GSTIN=@GSTIN where OrderNo='" + textBox21.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@Word", textBox24.Text);
                cmd.Parameters.AddWithValue("@GSTIN", textBox19.Text);
                cmd.ExecuteNonQuery();
                CLR();
                untltr.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
            finally {
                con.Close();
                Invoice i = new Invoice();
                i.ShowDialog();
            
            }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From MyOrder where Id=(SELECT max(Id) FROM MyOrder)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        textBox23.Text = dr["OrderNo"].ToString();
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
         
            try
            {

                int A = int.Parse(textBox23.Text);
                int B = int.Parse(textBox22.Text);
                int C = A + B;
                textBox21.Text = C.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void untltr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            //    con = new SqlConnection(StrSql);
            //    con.Open();
            //    // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
            //    StrSql = "select * From machineInfo where  Ltr='" + untltr.Text + "'";
            //    SqlCommand cmd = new SqlCommand(StrSql, con);
            //    dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {

            //            textBox17.Text = dr["AvaliableStock"].ToString();
            //            // textBox3.Text = dr["ActualStock"].ToString();



            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //    con.Close();
               

            //}
            //if (textBox17.Text == String.Empty)
            //{
            //    MessageBox.Show("Stock Not Avalible");
            //    textBox3.Enabled = false;
            //    textBox4.Enabled = false;
            
            //}
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int v = int.Parse(textBox17.Text);

            if (v <= 0)
            {
                MessageBox.Show("Stock NoT Avalible");
                int v1 = v * 0;
                textBox17.Text = v1.ToString(); 
            }

            if (textBox3.Text != String.Empty)
            {

                double v1 = double.Parse(textBox17.Text);
                double v2 = double.Parse(textBox3.Text);
                double v3 = v1 - v2;
                textBox18.Text = v3.ToString();

            }
            if (textBox17.Text == String.Empty)
            {
                double v2 = double.Parse(textBox18.Text);
                double v3 = v2 * 0;
                textBox14.Text = v3.ToString();
            }

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
           
           
                try
                {
                    StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                    con = new SqlConnection(StrSql);
                    con.Open();
                    // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                    StrSql = "select * From MyOrder where id=(SELECT max(id) FROM MyOrder)";
                    SqlCommand cmd = new SqlCommand(StrSql, con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            textBox23.Text = dr["OrderNo"].ToString();
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
                try
                {
                    int A = int.Parse(textBox23.Text);
                    int B = int.Parse(textBox22.Text);
                    int C = A + B;
                    textBox21.Text = C.ToString();
                }
                catch (Exception ex){
                    MessageBox.Show(ex.Message);
                        
                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }

            if (textBox17.Text != String.Empty)
            {
                textBox4.Enabled = true;
            }
            if (textBox17.Text == String.Empty)
            {
                textBox4.Enabled = false;
            }

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox24.Text = ConvertNumbertoWords(int.Parse(textBox11.Text));
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (textBox27.Text != String.Empty)
            {

                double v1 = double.Parse(textBox7.Text);
                double v2 = double.Parse(textBox27.Text);
                double v3 = v1 * v2 / 100;
                textBox26.Text = v3.ToString();
                double v4 = double.Parse(textBox26.Text);
                double v5 = v1 - v4;
                textBox25.Text = v5.ToString();



            }
            if (textBox27.Text == String.Empty)
            {

                //  double v1 = double.Parse(grandtotal.Text);
                double v2 = double.Parse(textBox26.Text);
                double v3 = v2 * 0;
                textBox26.Text = v3.ToString();
                double v4 = double.Parse(textBox25.Text);
                double v5 = 0 * v4;
                textBox25.Text = v5.ToString();



            }
        }

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

                        textBox17.Text = dr["AvaliableStock"].ToString();
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

        private void textBox27_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text != String.Empty)
            {
                double v1 = double.Parse(textBox25.Text);
                double v2 = double.Parse(textBox12.Text);
                double v3 = double.Parse(textBox13.Text);
                double v4 = double.Parse(textBox14.Text);
                double v5 = v1 + v2 + v3 + v4;
                // double Math.Round(v5, MidpointRounding mode);
                textBox11.Text = Math.Round(v5, MidpointRounding.AwayFromZero).ToString();


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        }
    }

