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
    public partial class ProductionReport : Form
    {
        public ProductionReport()
        {
            InitializeComponent();
            ClassBind();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;
        public void ClassBind()
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                DataRow dr;
                StrSql = "select * from  machine";
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                    cmd = new SqlCommand(StrSql, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { 0, "Machine" };
                    dt.Rows.InsertAt(dr, 0);

                    comboBox1.ValueMember = "Id";


                    comboBox1.DisplayMember = "Machine";
                    comboBox1.DataSource = dt;
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

        private void ProductionReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gudduDataSet2.machineInfo' table. You can move, or remove it, as needed.
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.machineInfoTableAdapter.Fill(this.gudduDataSet2.machineInfo, comboBox1.Text, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 2;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 50;
            pg.Margins.Right = 0;
            pg.Landscape = true;
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize();
            // size.RawKind = (int)PaperKind.A5;
            // pg.PaperSize = size;
            reportViewer1.SetPageSettings(pg);
            this.reportViewer1.RefreshReport();
        }
    }
}
