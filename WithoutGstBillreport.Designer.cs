namespace Golddi_Industries
{
    partial class WithoutGstBillreport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tempbillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gudduDataSet5 = new Golddi_Industries.gudduDataSet5();
            this.tempbillTableAdapter = new Golddi_Industries.gudduDataSet5TableAdapters.tempbillTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tempbillBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gudduDataSet5)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tempbillBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Golddi_Industries.Report14.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(24, 105);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(732, 428);
            this.reportViewer1.TabIndex = 0;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(114, 38);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(100, 20);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tempbillBindingSource
            // 
            this.tempbillBindingSource.DataMember = "tempbill";
            this.tempbillBindingSource.DataSource = this.gudduDataSet5;
            // 
            // gudduDataSet5
            // 
            this.gudduDataSet5.DataSetName = "gudduDataSet5";
            this.gudduDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tempbillTableAdapter
            // 
            this.tempbillTableAdapter.ClearBeforeFill = true;
            // 
            // WithoutGstBillreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 545);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "WithoutGstBillreport";
            this.Text = "WithoutGstBillreport";
            this.Load += new System.EventHandler(this.WithoutGstBillreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tempbillBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gudduDataSet5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.BindingSource tempbillBindingSource;
        private gudduDataSet5 gudduDataSet5;
        private gudduDataSet5TableAdapters.tempbillTableAdapter tempbillTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}