namespace Split_Goods
{
    partial class Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            this.Serial_No = new System.Windows.Forms.Label();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.Current_SN = new System.Windows.Forms.Label();
            this.txtCurrentSN = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.Counter = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.btnCoil = new System.Windows.Forms.Button();
            this.txtCoilSN = new System.Windows.Forms.TextBox();
            this.Coil_SN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Serial_No
            // 
            this.Serial_No.AutoSize = true;
            this.Serial_No.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Serial_No.ForeColor = System.Drawing.Color.Red;
            this.Serial_No.Location = new System.Drawing.Point(89, 155);
            this.Serial_No.Name = "Serial_No";
            this.Serial_No.Size = new System.Drawing.Size(110, 46);
            this.Serial_No.TabIndex = 0;
            this.Serial_No.Text = "Serial No:\r\n产品序列号";
            this.Serial_No.Click += new System.EventHandler(this.Serial_No_Click);
            // 
            // txtSN
            // 
            this.txtSN.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSN.ForeColor = System.Drawing.Color.Red;
            this.txtSN.Location = new System.Drawing.Point(235, 158);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(247, 40);
            this.txtSN.TabIndex = 1;
            this.txtSN.TextChanged += new System.EventHandler(this.txtSN_TextChanged);
            this.txtSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSN_KeyDown);
            // 
            // Current_SN
            // 
            this.Current_SN.AutoSize = true;
            this.Current_SN.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Current_SN.ForeColor = System.Drawing.Color.Red;
            this.Current_SN.Location = new System.Drawing.Point(86, 54);
            this.Current_SN.Name = "Current_SN";
            this.Current_SN.Size = new System.Drawing.Size(90, 46);
            this.Current_SN.TabIndex = 2;
            this.Current_SN.Text = "Batch No:\r\n内盒批号";
            // 
            // txtCurrentSN
            // 
            this.txtCurrentSN.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentSN.ForeColor = System.Drawing.Color.Red;
            this.txtCurrentSN.Location = new System.Drawing.Point(235, 57);
            this.txtCurrentSN.Name = "txtCurrentSN";
            this.txtCurrentSN.Size = new System.Drawing.Size(247, 40);
            this.txtCurrentSN.TabIndex = 3;
            this.txtCurrentSN.TextChanged += new System.EventHandler(this.txtCurrentSN_TextChanged);
            // 
            // btnValidate
            // 
            this.btnValidate.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.ForeColor = System.Drawing.Color.Red;
            this.btnValidate.Location = new System.Drawing.Point(552, 159);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(100, 38);
            this.btnValidate.TabIndex = 4;
            this.btnValidate.Text = "Add";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(86, 256);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(432, 271);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtCounter
            // 
            this.txtCounter.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounter.ForeColor = System.Drawing.Color.Red;
            this.txtCounter.Location = new System.Drawing.Point(552, 281);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.ReadOnly = true;
            this.txtCounter.Size = new System.Drawing.Size(100, 40);
            this.txtCounter.TabIndex = 6;
            this.txtCounter.TextChanged += new System.EventHandler(this.txtCounter_TextChanged);
            // 
            // Counter
            // 
            this.Counter.AutoSize = true;
            this.Counter.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Counter.ForeColor = System.Drawing.Color.Red;
            this.Counter.Location = new System.Drawing.Point(552, 237);
            this.Counter.Name = "Counter";
            this.Counter.Size = new System.Drawing.Size(102, 33);
            this.Counter.TabIndex = 7;
            this.Counter.Text = "Counter";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm.Location = new System.Drawing.Point(552, 58);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 38);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Lock";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // Export
            // 
            this.Export.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export.ForeColor = System.Drawing.Color.Red;
            this.Export.Location = new System.Drawing.Point(86, 537);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(97, 38);
            this.Export.TabIndex = 9;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // btnCoil
            // 
            this.btnCoil.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoil.ForeColor = System.Drawing.Color.Red;
            this.btnCoil.Location = new System.Drawing.Point(551, 108);
            this.btnCoil.Name = "btnCoil";
            this.btnCoil.Size = new System.Drawing.Size(100, 38);
            this.btnCoil.TabIndex = 12;
            this.btnCoil.Text = "Lock";
            this.btnCoil.UseVisualStyleBackColor = true;
            this.btnCoil.Click += new System.EventHandler(this.btnCoil_Click);
            // 
            // txtCoilSN
            // 
            this.txtCoilSN.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoilSN.ForeColor = System.Drawing.Color.Red;
            this.txtCoilSN.Location = new System.Drawing.Point(234, 107);
            this.txtCoilSN.Name = "txtCoilSN";
            this.txtCoilSN.Size = new System.Drawing.Size(247, 40);
            this.txtCoilSN.TabIndex = 11;
            // 
            // Coil_SN
            // 
            this.Coil_SN.AutoSize = true;
            this.Coil_SN.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Coil_SN.ForeColor = System.Drawing.Color.Red;
            this.Coil_SN.Location = new System.Drawing.Point(88, 104);
            this.Coil_SN.Name = "Coil_SN";
            this.Coil_SN.Size = new System.Drawing.Size(110, 46);
            this.Coil_SN.TabIndex = 10;
            this.Coil_SN.Text = "Coil SN:\r\n绿线圈批次";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(93, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "产品序列号的首四位字符必须和内盒批次号的第三至六位字符相同，否则不能保存。\r\n例如：内盒批号为PT1234，产品序列号必须以1234开头，否则不能保存。\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(568, 503);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 88);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 603);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCoil);
            this.Controls.Add(this.txtCoilSN);
            this.Controls.Add(this.Coil_SN);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.Counter);
            this.Controls.Add(this.txtCounter);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.txtCurrentSN);
            this.Controls.Add(this.Current_SN);
            this.Controls.Add(this.txtSN);
            this.Controls.Add(this.Serial_No);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Serial_No;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.Label Current_SN;
        private System.Windows.Forms.TextBox txtCurrentSN;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCounter;
        private System.Windows.Forms.Label Counter;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button btnCoil;
        private System.Windows.Forms.TextBox txtCoilSN;
        private System.Windows.Forms.Label Coil_SN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}