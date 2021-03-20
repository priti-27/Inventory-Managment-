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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
            ClassBind();

        }

           String ImgPath1 = "";
        byte[] Data = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        string StrSql = string.Empty;
        public void ClassBind()
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                DataRow dr;
                StrSql = "select * from  employee_profile";
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                    cmd = new SqlCommand(StrSql, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { 0, "name" };
                    dt.Rows.InsertAt(dr, 0);

                    cmb1.ValueMember = "id";


                    cmb1.DisplayMember = "name";
                    cmb1.DataSource = dt;
                }
            }
            catch
            {

            }
            finally { }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // if (textBox1.Text != String.Empty)
            //{
               

           // }
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From employee_profile where name='" + cmb1.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {


                        txtpos.Text = dr["position"].ToString();
                        textBox1.Text = dr["cursal"].ToString();

                        byte[] images = ((byte[])dr[9]);
                        if (images == null)
                        {
                            pb1.Image = null;

                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(images);
                            pb1.Image = Image.FromStream(ms);
                        }



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
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From OT where EmployeeName='" + cmb1.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {


                       // txtpos.Text = dr["position"].ToString();
                        textBox7.Text = dr["OT"].ToString();

                    


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

        private void Salary_Load(object sender, EventArgs e)
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
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert  into Salary(Employee_Name,Position,Date,Salary,Advance,Payment) values (@Employee_Name,@Position,@Date,@Salary,@Advance,@Payment) ";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@Employee_Name", cmb1.Text);
                cmd.Parameters.AddWithValue("@Position", txtpos.Text);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dtp1.Text));
                cmd.Parameters.AddWithValue("@Salary",textBox1.Text);
                cmd.Parameters.AddWithValue("@Advance", textBox2.Text);
                cmd.Parameters.AddWithValue("@Payment", textBox3.Text);
              //  cmd.Parameters.AddWithValue("@intime", Convert.ToDateTime(dtp2.Text));
                // cmd.Parameters.AddWithValue("@uploadpic", pb1.te);
                //if (ImgPath1.Trim().Length == 0 && Data == null)
                //{
                //    cmd.Parameters.AddWithValue("@uploadpic", DBNull.Value);
                //    cmd.Parameters["@uploadpic"].SqlDbType = SqlDbType.Image;
                //}
                //else if (ImgPath1.Trim().Length > 0)
                //{
                //    Data = File.ReadAllBytes(ImgPath1);
                //    cmd.Parameters.AddWithValue("@uploadpic", Data);

                //}

                cmd.ExecuteNonQuery();
                MessageBox.Show("record inserted successfully");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from Salary ", con);
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
                textBox1.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }

            try
            {
                textBox7.Text = "0";
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert  into OT(EmployeeName,OT) values (@EmployeeName,@OT) ";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@EmployeeName", cmb1.Text);
                //cmd.Parameters.AddWithValue("@Hours", textBox4.Text);
               // cmd.Parameters.AddWithValue("@Amt", textBox5.Text);
               // cmd.Parameters.AddWithValue("@Total", textBox6.Text);
                cmd.Parameters.AddWithValue("@OT", textBox7.Text);
                //cmd.Parameters.AddWithValue("@Payment", textBox3.Text);
                //  cmd.Parameters.AddWithValue("@intime", Convert.ToDateTime(dtp2.Text));
                // cmd.Parameters.AddWithValue("@uploadpic", pb1.te);
                //if (ImgPath1.Trim().Length == 0 && Data == null)
                //{
                //    cmd.Parameters.AddWithValue("@uploadpic", DBNull.Value);
                //    cmd.Parameters["@uploadpic"].SqlDbType = SqlDbType.Image;
                //}
                //else if (ImgPath1.Trim().Length > 0)
                //{
                //    Data = File.ReadAllBytes(ImgPath1);
                //    cmd.Parameters.AddWithValue("@uploadpic", Data);

                //}

                cmd.ExecuteNonQuery();
               // MessageBox.Show("OverTime Added successfully");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                textBox4.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty)
            {
                double v1 = double.Parse(textBox8.Text);
                double v2 = double.Parse(textBox2.Text);

                double v3 = v1 - v2;
                textBox3.Text = v3.ToString();

            
            }
            if (textBox2.Text==String.Empty)
            {
                double v3 = double.Parse(textBox3.Text);
                double v4 = v3 * 0;
                textBox3.Text = v4.ToString();
                //double v2 = double.Parse(textBox2.Text);

                

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != String.Empty)
            {
                double v1 = double.Parse(textBox5.Text);
                double v2 = double.Parse(textBox4.Text);
                double v3 = v1 * v2;
                textBox6.Text = v3.ToString();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double v6 = double.Parse(textBox6.Text);
            double v4 = double.Parse(textBox7.Text);
            double v5 = v6 + v4;
            textBox7.Text = v5.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert  into OT(EmployeeName,Hours,Amt,Total,OT) values (@EmployeeName,@Hours,@Amt,@Total,@OT) ";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@EmployeeName", cmb1.Text);
                cmd.Parameters.AddWithValue("@Hours", textBox4.Text);
                cmd.Parameters.AddWithValue("@Amt", textBox5.Text);
                cmd.Parameters.AddWithValue("@Total", textBox6.Text);
                cmd.Parameters.AddWithValue("@OT", textBox7.Text);
                //cmd.Parameters.AddWithValue("@Payment", textBox3.Text);
                //  cmd.Parameters.AddWithValue("@intime", Convert.ToDateTime(dtp2.Text));
                // cmd.Parameters.AddWithValue("@uploadpic", pb1.te);
                //if (ImgPath1.Trim().Length == 0 && Data == null)
                //{
                //    cmd.Parameters.AddWithValue("@uploadpic", DBNull.Value);
                //    cmd.Parameters["@uploadpic"].SqlDbType = SqlDbType.Image;
                //}
                //else if (ImgPath1.Trim().Length > 0)
                //{
                //    Data = File.ReadAllBytes(ImgPath1);
                //    cmd.Parameters.AddWithValue("@uploadpic", Data);

                //}

                cmd.ExecuteNonQuery();
                MessageBox.Show("OverTime Added successfully");
              


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                textBox4.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double v2 = double.Parse(textBox1.Text);
            double v3 = double.Parse(textBox7.Text);
            double v4 = v2 + v3;
            textBox8.Text = v4.ToString();
        }
    }
}
