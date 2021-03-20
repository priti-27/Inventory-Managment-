namespace Golddi_Industries
{
    partial class forget_password
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnsp = new System.Windows.Forms.Button();
            this.txtyp = new System.Windows.Forms.TextBox();
            this.txtun = new System.Windows.Forms.TextBox();
            this.btnc = new System.Windows.Forms.Button();
            this.txtdob = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forget Password Form";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "D.O.B.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Your Password:";
            // 
            // btnsp
            // 
            this.btnsp.Location = new System.Drawing.Point(219, 135);
            this.btnsp.Name = "btnsp";
            this.btnsp.Size = new System.Drawing.Size(109, 31);
            this.btnsp.TabIndex = 4;
            this.btnsp.Text = "Show Password";
            this.btnsp.UseVisualStyleBackColor = true;
            this.btnsp.Click += new System.EventHandler(this.btnsp_Click);
            // 
            // txtyp
            // 
            this.txtyp.Enabled = false;
            this.txtyp.Location = new System.Drawing.Point(184, 182);
            this.txtyp.Name = "txtyp";
            this.txtyp.Size = new System.Drawing.Size(189, 20);
            this.txtyp.TabIndex = 5;
            // 
            // txtun
            // 
            this.txtun.Location = new System.Drawing.Point(184, 59);
            this.txtun.Name = "txtun";
            this.txtun.Size = new System.Drawing.Size(189, 20);
            this.txtun.TabIndex = 8;
            this.txtun.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // btnc
            // 
            this.btnc.Location = new System.Drawing.Point(219, 219);
            this.btnc.Name = "btnc";
            this.btnc.Size = new System.Drawing.Size(109, 31);
            this.btnc.TabIndex = 9;
            this.btnc.Text = "Close";
            this.btnc.UseVisualStyleBackColor = true;
            // 
            // txtdob
            // 
            this.txtdob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdob.Location = new System.Drawing.Point(184, 100);
            this.txtdob.Name = "txtdob";
            this.txtdob.Size = new System.Drawing.Size(189, 20);
            this.txtdob.TabIndex = 10;
            // 
            // forget_password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 262);
            this.Controls.Add(this.txtdob);
            this.Controls.Add(this.btnc);
            this.Controls.Add(this.txtun);
            this.Controls.Add(this.txtyp);
            this.Controls.Add(this.btnsp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "forget_password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forget_password";
            this.Load += new System.EventHandler(this.forget_password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnsp;
        private System.Windows.Forms.TextBox txtyp;
        private System.Windows.Forms.TextBox txtun;
        private System.Windows.Forms.Button btnc;
        private System.Windows.Forms.DateTimePicker txtdob;
    }
}