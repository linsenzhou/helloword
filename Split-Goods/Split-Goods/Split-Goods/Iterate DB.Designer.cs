namespace Split_Goods
{
    partial class Iterate_DB
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
            this.btnIterate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIterate
            // 
            this.btnIterate.Location = new System.Drawing.Point(98, 66);
            this.btnIterate.Name = "btnIterate";
            this.btnIterate.Size = new System.Drawing.Size(75, 23);
            this.btnIterate.TabIndex = 0;
            this.btnIterate.Text = "Start";
            this.btnIterate.UseVisualStyleBackColor = true;
            this.btnIterate.Click += new System.EventHandler(this.btnIterate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(98, 121);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Iterate_DB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnIterate);
            this.Name = "Iterate_DB";
            this.Text = "Iterate_DB";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIterate;
        private System.Windows.Forms.Button btnExit;
    }
}