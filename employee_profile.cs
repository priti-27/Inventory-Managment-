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
    public partial class employee_profile : Form
    {
        public employee_profile()
        {
            InitializeComponent();
        }
        String ImgPath = "";// to initilize pimage path
        String ImgPath1 = "";
        byte[] Data = null;// to convert and save in database using array
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        string StrSql = string.Empty;

        public void CLEAR()
        {
            txtname.Text = "";
            txtaddr.Text = "";
           // txtdob.Text = "";
            txtcon.Text = "";
            txtpos.Text = "";
            txtsal.Text = "";
        }
        // Other process is just same as given  like insert update delete 
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ImgPath1 = openFileDialog1.FileName;
                pictureBox2.ImageLocation = ImgPath1;
            }
            label7.ForeColor = System.Drawing.Color.Green;
            label7.Text = "image upload successfully";

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = idata.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = idata.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtaddr.Text = idata.Rows[e.RowIndex].Cells[2].Value.ToString();
           dtp1.Text = idata.Rows[e.RowIndex].Cells[3].Value.ToString();
            //  pictureBox1.ImageLocation = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
           cmbid.Text = idata.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtcon.Text = idata.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtpos.Text = idata.Rows[e.RowIndex].Cells[6].Value.ToString();
           txtsal.Text = idata.Rows[e.RowIndex].Cells[7].Value.ToString();
           btnsave.Enabled = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert  into employee_profile(Name,address,dob,idproof,contact,position,cursal,picupload,idupload) values (@name,@addr,@dob,@idproof,@contact,@position,@cursal,@picupload,@idupload)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@addr", txtaddr.Text);
                cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime( dtp1.Text));
                cmd.Parameters.AddWithValue("@idproof", cmbid.Text);
                cmd.Parameters.AddWithValue("@contact", txtcon.Text);
                cmd.Parameters.AddWithValue("@position", txtpos.Text);
                cmd.Parameters.AddWithValue("@cursal", txtsal.Text);
                //cmd.Parameters.AddWithValue("@picupload", btnphoto.Text);
                //cmd.Parameters.AddWithValue("@idupload", btnid.Text);

                if (ImgPath1.Trim().Length == 0 && Data == null)
                {
                    cmd.Parameters.AddWithValue("@picupload", DBNull.Value);
                    cmd.Parameters["@picupload"].SqlDbType = SqlDbType.Image;
                }
                else if (ImgPath1.Trim().Length > 0)
                {
                    Data = File.ReadAllBytes(ImgPath1);
                    cmd.Parameters.AddWithValue("@picupload", Data);

                }
                if (ImgPath.Trim().Length == 0 && Data == null)
                {
                    cmd.Parameters.AddWithValue("@idupload", DBNull.Value);
                    cmd.Parameters["@idupload"].SqlDbType = SqlDbType.Image;
                }
                else if (ImgPath.Trim().Length > 0)
                {
                    Data = File.ReadAllBytes(ImgPath);
                    cmd.Parameters.AddWithValue("@idupload", Data);

                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("record inserted successfully");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select *  from employee_profile ", con);
                da.Fill(dt);
                idata.DataSource = dt;
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

        private void btnphoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ImgPath = openFileDialog1.FileName;
                pbcusimg.ImageLocation = ImgPath;
            }
            label10.ForeColor = System.Drawing.Color.Green;
            label10.Text = "image upload successfully";
        }

        private void employee_profile_Load(object sender, EventArgs e)
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

        private void txtsal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void txtcon_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql =" Update employee_profile SET Name=@name,address=@addr,dob=@dob,idproof=@idproof,contact=@contact,position=@position,cursal=@cursal Where id='"+textBox1.Text+"'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@addr", txtaddr.Text);
                cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime( dtp1.Text));
                cmd.Parameters.AddWithValue("@idproof", cmbid.Text);
                cmd.Parameters.AddWithValue("@contact", txtcon.Text);
                cmd.Parameters.AddWithValue("@position", txtpos.Text);
                cmd.Parameters.AddWithValue("@cursal", txtsal.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("record Updated Successfully");
                CLEAR();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select *  from employee_profile ", con);
                da.Fill(dt);
                idata.DataSource = dt;
                CLEAR();
                btnsave.Enabled = true;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
             DialogResult dialog = MessageBox.Show("Do you really want to delete the records?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {



                try
                {
                    //if (ID != 0)
                    //{
                    StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                    SqlConnection con = new SqlConnection(StrSql);
                    con.Open();
                    cmd = new SqlCommand("delete FROM employee_profile  Where id='" + textBox1.Text + "' ", con);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully");
                    CLEAR();
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter("select * from employee_profile ", con);
                    da.Fill(dt);
                    idata.DataSource = dt;



                    //  ClearData();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        }
    }

