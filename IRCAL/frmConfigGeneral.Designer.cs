namespace myIRC
{
    partial class frmConfigGeneral
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
            this.Nick = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbNick = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pbNames = new System.Windows.Forms.PictureBox();
            this.pbSent = new System.Windows.Forms.PictureBox();
            this.pbAlert = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Location = new System.Drawing.Point(55, 53);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(29, 13);
            this.Nick.TabIndex = 0;
            this.Nick.Text = "Nick";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Color of Names";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Color of Sent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Color of Alert";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(307, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(110, 46);
            this.tbNick.Name = "tbNick";
            this.tbNick.Size = new System.Drawing.Size(272, 20);
            this.tbNick.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(110, 72);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(272, 20);
            this.tbName.TabIndex = 8;
            // 
            // pbNames
            // 
            this.pbNames.Location = new System.Drawing.Point(150, 98);
            this.pbNames.Name = "pbNames";
            this.pbNames.Size = new System.Drawing.Size(51, 25);
            this.pbNames.TabIndex = 9;
            this.pbNames.TabStop = false;
            this.pbNames.Click += new System.EventHandler(this.pbNames_Click);
            // 
            // pbSent
            // 
            this.pbSent.Location = new System.Drawing.Point(150, 129);
            this.pbSent.Name = "pbSent";
            this.pbSent.Size = new System.Drawing.Size(51, 25);
            this.pbSent.TabIndex = 10;
            this.pbSent.TabStop = false;
            this.pbSent.Click += new System.EventHandler(this.pbSent_Click);
            // 
            // pbAlert
            // 
            this.pbAlert.Location = new System.Drawing.Point(150, 160);
            this.pbAlert.Name = "pbAlert";
            this.pbAlert.Size = new System.Drawing.Size(51, 25);
            this.pbAlert.TabIndex = 11;
            this.pbAlert.TabStop = false;
            // 
            // frmConfigGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 543);
            this.Controls.Add(this.pbAlert);
            this.Controls.Add(this.pbSent);
            this.Controls.Add(this.pbNames);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbNick);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nick);
            this.Name = "frmConfigGeneral";
            this.Text = "frmConfigGeneral";
            this.Load += new System.EventHandler(this.frmConfigGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Nick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbNick;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.PictureBox pbNames;
        private System.Windows.Forms.PictureBox pbSent;
        private System.Windows.Forms.PictureBox pbAlert;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}