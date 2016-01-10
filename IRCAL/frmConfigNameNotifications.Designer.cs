namespace myIRC
{
    partial class frmConfigNameNotifications
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
            this.lblFile = new System.Windows.Forms.Label();
            this.btnRemoveNick = new System.Windows.Forms.Button();
            this.cbNameNotificationList = new System.Windows.Forms.ComboBox();
            this.rtbListedNotifications = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPhonetic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSpeakIt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nudThreshHold = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNick = new System.Windows.Forms.Button();
            this.tbNick = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshHold)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name notifications play wave files";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(156, 27);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(0, 13);
            this.lblFile.TabIndex = 1;
            // 
            // btnRemoveNick
            // 
            this.btnRemoveNick.Location = new System.Drawing.Point(403, 181);
            this.btnRemoveNick.Name = "btnRemoveNick";
            this.btnRemoveNick.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveNick.TabIndex = 6;
            this.btnRemoveNick.Text = "Remove";
            this.btnRemoveNick.UseVisualStyleBackColor = true;
            this.btnRemoveNick.Click += new System.EventHandler(this.btnRemoveNick_Click);
            // 
            // cbNameNotificationList
            // 
            this.cbNameNotificationList.FormattingEnabled = true;
            this.cbNameNotificationList.Location = new System.Drawing.Point(276, 183);
            this.cbNameNotificationList.Name = "cbNameNotificationList";
            this.cbNameNotificationList.Size = new System.Drawing.Size(121, 21);
            this.cbNameNotificationList.TabIndex = 7;
            // 
            // rtbListedNotifications
            // 
            this.rtbListedNotifications.Location = new System.Drawing.Point(276, 210);
            this.rtbListedNotifications.Name = "rtbListedNotifications";
            this.rtbListedNotifications.ReadOnly = true;
            this.rtbListedNotifications.Size = new System.Drawing.Size(502, 198);
            this.rtbListedNotifications.TabIndex = 9;
            this.rtbListedNotifications.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(75, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Pick File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPhonetic);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSpeakIt);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.nudThreshHold);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAddNick);
            this.groupBox1.Controls.Add(this.tbNick);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.lblFile);
            this.groupBox1.Location = new System.Drawing.Point(266, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 139);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Nick Notification";
            // 
            // tbPhonetic
            // 
            this.tbPhonetic.Location = new System.Drawing.Point(79, 83);
            this.tbPhonetic.Name = "tbPhonetic";
            this.tbPhonetic.Size = new System.Drawing.Size(100, 20);
            this.tbPhonetic.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Phonetic";
            // 
            // btnSpeakIt
            // 
            this.btnSpeakIt.Location = new System.Drawing.Point(185, 50);
            this.btnSpeakIt.Name = "btnSpeakIt";
            this.btnSpeakIt.Size = new System.Drawing.Size(69, 23);
            this.btnSpeakIt.TabIndex = 25;
            this.btnSpeakIt.Text = "Speak it";
            this.btnSpeakIt.UseVisualStyleBackColor = true;
            this.btnSpeakIt.Click += new System.EventHandler(this.SpeakIt_click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Play Wav";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // nudThreshHold
            // 
            this.nudThreshHold.Location = new System.Drawing.Point(131, 113);
            this.nudThreshHold.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudThreshHold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreshHold.Name = "nudThreshHold";
            this.nudThreshHold.Size = new System.Drawing.Size(53, 20);
            this.nudThreshHold.TabIndex = 23;
            this.nudThreshHold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Threshold Minutes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nick";
            // 
            // btnAddNick
            // 
            this.btnAddNick.Location = new System.Drawing.Point(190, 113);
            this.btnAddNick.Name = "btnAddNick";
            this.btnAddNick.Size = new System.Drawing.Size(75, 23);
            this.btnAddNick.TabIndex = 20;
            this.btnAddNick.Text = "Add";
            this.btnAddNick.UseVisualStyleBackColor = true;
            this.btnAddNick.Click += new System.EventHandler(this.AddNick_Click);
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(79, 53);
            this.tbNick.Name = "tbNick";
            this.tbNick.Size = new System.Drawing.Size(100, 20);
            this.tbNick.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-49, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nick";
            // 
            // frmConfigNameNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 505);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbListedNotifications);
            this.Controls.Add(this.cbNameNotificationList);
            this.Controls.Add(this.btnRemoveNick);
            this.Controls.Add(this.label1);
            this.Name = "frmConfigNameNotifications";
            this.Text = "Nick and Text Nofifications";
            this.Load += new System.EventHandler(this.frmConfigNameNotifications_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshHold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnRemoveNick;
        private System.Windows.Forms.ComboBox cbNameNotificationList;
        private System.Windows.Forms.RichTextBox rtbListedNotifications;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudThreshHold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNick;
        private System.Windows.Forms.TextBox tbNick;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSpeakIt;
        private System.Windows.Forms.TextBox tbPhonetic;
        private System.Windows.Forms.Label label4;
    }
}