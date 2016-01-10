namespace myIRC
{
    partial class frmRaw
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
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.RefreshAtStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb
            // 
            this.rtb.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtb.Location = new System.Drawing.Point(0, 0);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(1080, 458);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(195, 511);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 23);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = "Next Page";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // RefreshAtStart
            // 
            this.RefreshAtStart.Location = new System.Drawing.Point(35, 511);
            this.RefreshAtStart.Name = "RefreshAtStart";
            this.RefreshAtStart.Size = new System.Drawing.Size(112, 23);
            this.RefreshAtStart.TabIndex = 2;
            this.RefreshAtStart.Text = "Reset to start";
            this.RefreshAtStart.UseVisualStyleBackColor = true;
            this.RefreshAtStart.Click += new System.EventHandler(this.RefreshAtStart_Click);
            // 
            // frmRaw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 546);
            this.Controls.Add(this.RefreshAtStart);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.rtb);
            this.Name = "frmRaw";
            this.Text = "frmRaw";
            this.Load += new System.EventHandler(this.frmRaw_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button RefreshAtStart;
    }
}