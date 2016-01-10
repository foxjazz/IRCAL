namespace myIRC
{
    partial class frmPrivMessages
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
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.lbPrivates = new System.Windows.Forms.ListBox();
            this.rtbTalk = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbMsg
            // 
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbMsg.Location = new System.Drawing.Point(120, 0);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(963, 624);
            this.rtbMsg.TabIndex = 0;
            this.rtbMsg.Text = "";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(64, 218);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(8, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // lbPrivates
            // 
            this.lbPrivates.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbPrivates.FormattingEnabled = true;
            this.lbPrivates.Location = new System.Drawing.Point(0, 0);
            this.lbPrivates.Name = "lbPrivates";
            this.lbPrivates.Size = new System.Drawing.Size(120, 615);
            this.lbPrivates.TabIndex = 2;
            this.lbPrivates.SelectedIndexChanged += new System.EventHandler(this.lbPrivates_SelectedIndexChanged);
            // 
            // rtbTalk
            // 
            this.rtbTalk.AcceptsTab = true;
            this.rtbTalk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbTalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTalk.Location = new System.Drawing.Point(120, 595);
            this.rtbTalk.Name = "rtbTalk";
            this.rtbTalk.Size = new System.Drawing.Size(963, 29);
            this.rtbTalk.TabIndex = 3;
            this.rtbTalk.TabStop = false;
            this.rtbTalk.Text = "";
            this.rtbTalk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbTalk_KeyDown);
            // 
            // frmPrivMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 624);
            this.Controls.Add(this.rtbTalk);
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.lbPrivates);
            this.Controls.Add(this.maskedTextBox1);
            this.Name = "frmPrivMessages";
            this.Text = "frmPrivMessages";
            this.Load += new System.EventHandler(this.frmPrivMessages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ListBox lbPrivates;
        private System.Windows.Forms.RichTextBox rtbTalk;
    }
}