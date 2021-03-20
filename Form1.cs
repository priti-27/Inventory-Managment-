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
using System.IO;
namespace Golddi_Industries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;
        string ImgPath = "";
        byte[] Data = null;
        // This code is use to allow system to exit when esc button is press
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Cleare()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            pictureBox1.InitialImage = null;
            textBox4.Text = "";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            // used to insert data into machine table
             try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert into machine (Machine,MachineNo,Type,Image,Description ) values (@MachineName,@MachineNo,@Type,@Image,@Description)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@MachineName", textBox1.Text);
                 cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@MachineNo", textBox2.Text);
                cmd.Parameters.AddWithValue("@Description", textBox4.Text);
               // cmd.Parameters.AddWithValue("@Inltr", untltr.Text);
                if (ImgPath.Trim().Length == 0 && Data == null)
                {
                    cmd.Parameters.AddWithValue("@Image", DBNull.Value);
                    cmd.Parameters["@Image"].SqlDbType = SqlDbType.Image;

                }
                else if (ImgPath.Trim().Length > 0)
                {
                    Data = File.ReadAllBytes(ImgPath);
                    cmd.Parameters.AddWithValue("@Image", Data);

                }


                cmd.ExecuteNonQuery();
                MessageBox.Show("can added into the Stock");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from machine ", con);
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
                Cleare();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ImgPath = openFileDialog1.FileName;
                pictureBox1.ImageLocation = ImgPath;
            }
            // label11.ForeColor = System.Drawing.Color.Green;
            // label11.Text = "Image Uploaded";
            button2.Enabled = true;

        }
        // display data to gridview 
        private void Form1_Load(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from machine ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        // Select data from grid view for updation 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {// update machine table

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "insert into machine (Machine,MachineNo,Type,Image,Description) values (@MachineName,@MachineNo,@Type,@Image,@Description)";
                StrSql = "update machine set Machine=@MachineName,Type=@Type,MachineNo=@MachineNo,Description=@Description where Id='" + textBox3.Text + "' ";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@MachineName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@MachineNo", textBox2.Text);
                cmd.Parameters.AddWithValue("@Description", textBox4.Text);
                //if (ImgPath.Trim().Length == 0 && Data == null)
                //{
                //    cmd.Parameters.AddWithValue("@Image", DBNull.Value);
                //    cmd.Parameters["@Image"].SqlDbType = SqlDbType.Image;

                //}
                //else if (ImgPath.Trim().Length > 0)
                //{
                //    Data = File.ReadAllBytes(ImgPath);
                //    cmd.Parameters.AddWithValue("@Image", Data);

                //}


                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from machine ", con);
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
                Cleare();

            }
        }
        // delete data
        private void button4_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("delete FROM machine  Where Id='" + textBox3.Text + "' ", con);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    Cleare();
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter("select * from machine ", con);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;



                    //  ClearData();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Add ltr into machine
        private void button6_Click(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            StrSql = "insert into Ltr (Name,Ltr) values (@Name,@Ltr)";
            SqlCommand cmd = new SqlCommand(StrSql, con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Ltr", untltr.Text);
           // cmd.Parameters.AddWithValue("@MachineNo", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ltr Add To Machine");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}