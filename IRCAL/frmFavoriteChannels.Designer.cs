namespace myIRC
{
    partial class frmFavoriteChannels
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
            this.cbIRCServers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbList = new System.Windows.Forms.RichTextBox();
            this.btnAddListFavs = new System.Windows.Forms.Button();
            this.btnRemLstFavs = new System.Windows.Forms.Button();
            this.lblFavorites = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbFavs = new System.Windows.Forms.ListBox();
            this.rtbFavs = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudNotifyMinute = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPhonetic = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNotifyMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIRCServers
            // 
            this.cbIRCServers.FormattingEnabled = true;
            this.cbIRCServers.Location = new System.Drawing.Point(47, 69);
            this.cbIRCServers.Name = "cbIRCServers";
            this.cbIRCServers.Size = new System.Drawing.Size(299, 21);
            this.cbIRCServers.TabIndex = 0;
            this.cbIRCServers.SelectionChangeCommitted += new System.EventHandler(this.cbIRCServers_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pick IRC Server";
            // 
            // rtbList
            // 
            this.rtbList.Location = new System.Drawing.Point(47, 109);
            this.rtbList.Name = "rtbList";
            this.rtbList.Size = new System.Drawing.Size(299, 138);
            this.rtbList.TabIndex = 2;
            this.rtbList.Text = "";
            // 
            // btnAddListFavs
            // 
            this.btnAddListFavs.Location = new System.Drawing.Point(366, 121);
            this.btnAddListFavs.Name = "btnAddListFavs";
            this.btnAddListFavs.Size = new System.Drawing.Size(114, 23);
            this.btnAddListFavs.TabIndex = 4;
            this.btnAddListFavs.Text = "Add listed favorites";
            this.btnAddListFavs.UseVisualStyleBackColor = true;
            this.btnAddListFavs.Click += new System.EventHandler(this.btnAddListFavs_Click);
            // 
            // btnRemLstFavs
            // 
            this.btnRemLstFavs.Location = new System.Drawing.Point(366, 150);
            this.btnRemLstFavs.Name = "btnRemLstFavs";
            this.btnRemLstFavs.Size = new System.Drawing.Size(114, 23);
            this.btnRemLstFavs.TabIndex = 5;
            this.btnRemLstFavs.Text = "Remove listed favorites";
            this.btnRemLstFavs.UseVisualStyleBackColor = true;
            this.btnRemLstFavs.Click += new System.EventHandler(this.btnRemLstFavs_Click);
            // 
            // lblFavorites
            // 
            this.lblFavorites.AutoSize = true;
            this.lblFavorites.Location = new System.Drawing.Point(47, 265);
            this.lblFavorites.Name = "lblFavorites";
            this.lblFavorites.Size = new System.Drawing.Size(136, 13);
            this.lblFavorites.TabIndex = 7;
            this.lblFavorites.Text = "Pick to change notification.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Enter your favorites here. ";
            // 
            // lbFavs
            // 
            this.lbFavs.FormattingEnabled = true;
            this.lbFavs.Location = new System.Drawing.Point(47, 290);
            this.lbFavs.Name = "lbFavs";
            this.lbFavs.Size = new System.Drawing.Size(195, 199);
            this.lbFavs.TabIndex = 9;
            this.lbFavs.SelectedIndexChanged += new System.EventHandler(this.lbFavs_SelectedIndexChanged);
            // 
            // rtbFavs
            // 
            this.rtbFavs.Location = new System.Drawing.Point(385, 290);
            this.rtbFavs.Name = "rtbFavs";
            this.rtbFavs.Size = new System.Drawing.Size(216, 199);
            this.rtbFavs.TabIndex = 10;
            this.rtbFavs.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Favorites Summary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Notification in Minutes";
            // 
            // nudNotifyMinute
            // 
            this.nudNotifyMinute.Location = new System.Drawing.Point(262, 323);
            this.nudNotifyMinute.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNotifyMinute.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNotifyMinute.Name = "nudNotifyMinute";
            this.nudNotifyMinute.Size = new System.Drawing.Size(84, 20);
            this.nudNotifyMinute.TabIndex = 13;
            this.nudNotifyMinute.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNotifyMinute.ValueChanged += new System.EventHandler(this.nudNotifyMinute_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Phonetic";
            // 
            // lblPhonetic
            // 
            this.lblPhonetic.Location = new System.Drawing.Point(262, 399);
            this.lblPhonetic.Name = "lblPhonetic";
            this.lblPhonetic.Size = new System.Drawing.Size(100, 20);
            this.lblPhonetic.TabIndex = 16;
            this.lblPhonetic.Validated += new System.EventHandler(this.lblPhonetic_Validated);
            // 
            // frmFavoriteChannels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 554);
            this.Controls.Add(this.lblPhonetic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudNotifyMinute);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbFavs);
            this.Controls.Add(this.lbFavs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFavorites);
            this.Controls.Add(this.btnRemLstFavs);
            this.Controls.Add(this.btnAddListFavs);
            this.Controls.Add(this.rtbList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbIRCServers);
            this.Name = "frmFavoriteChannels";
            this.Text = "frmFavoriteChannels";
            this.Load += new System.EventHandler(this.frmFavoriteChannels_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFavoriteChannels_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudNotifyMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIRCServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbList;
        private System.Windows.Forms.Button btnAddListFavs;
        private System.Windows.Forms.Button btnRemLstFavs;
        private System.Windows.Forms.Label lblFavorites;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbFavs;
        private System.Windows.Forms.RichTextBox rtbFavs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudNotifyMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lblPhonetic;
    }
}