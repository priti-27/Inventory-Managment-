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
    public partial class employee_attendace : Form
    {
        public employee_attendace()
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
        // this class show the all name of employee which was added to employee profile
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
            finally{}
        }
        // this gread view is use to relate the data grid view with database and when click on any row fatch the data to respected textbox.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           cmb1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           txtpos.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtp1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtp2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //pb1.ImageLocation = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            btnsave.Enabled = false;
        }

        // Insert attendance information to employee attendance table.
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert  into employee_attendance(empname,position,date,intime) values (@empname,@position,@date,@intime)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@empname", cmb1.Text);
                cmd.Parameters.AddWithValue("@position", txtpos.Text);
                cmd.Parameters.AddWithValue("@date",Convert.ToDateTime(dtp1.Text));
                cmd.Parameters.AddWithValue("@intime",Convert.ToDateTime (dtp2.Text));
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
                da = new SqlDataAdapter("select Id, empname,position,date,intime from employee_attendance ORDER BY Id DESC ", con);
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
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
        }
        // featch employee data from employee name
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
        }

        private void employee_attendace_Load(object sender, EventArgs e)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }
        // Update employee outgoing time
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "Update  employee_attendance SET OutTime=@OutTime Where Id='"+textBox1.Text+"'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
              
                cmd.Parameters.AddWithValue("@OutTime", Convert.ToDateTime(dateTimePicker2.Text));
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
                da = new SqlDataAdapter("select Id, empname,position,date,intime,OutTime from employee_attendance ORDER BY ID DESC", con);
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
                btnsave.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from employee_attendance Where date='" + dateTimePicker1.Text + "'", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
