namespace myIRC
{
    partial class Form1
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
            this.rtbSenders = new System.Windows.Forms.RichTextBox();
            this.rtbBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbTalk = new System.Windows.Forms.RichTextBox();
            this.ircCore1 = new myIRC.IRCCore(this.components);
            this.btnRegister = new System.Windows.Forms.Button();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.rtbGeneral = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbSenders
            // 
            this.rtbSenders.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtbSenders.Location = new System.Drawing.Point(3, 16);
            this.rtbSenders.Name = "rtbSenders";
            this.rtbSenders.ReadOnly = true;
            this.rtbSenders.Size = new System.Drawing.Size(94, 337);
            this.rtbSenders.TabIndex = 0;
            this.rtbSenders.Text = "";
            // 
            // rtbBox
            // 
            this.rtbBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBox.Location = new System.Drawing.Point(97, 16);
            this.rtbBox.Name = "rtbBox";
            this.rtbBox.ReadOnly = true;
            this.rtbBox.Size = new System.Drawing.Size(1028, 337);
            this.rtbBox.TabIndex = 1;
            this.rtbBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(201, 19);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(161, 20);
            this.tbServer.TabIndex = 3;
            this.tbServer.Text = "IRC.freenode.net";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbTalk);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 580);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1128, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send Box";
            // 
            // rtbTalk
            // 
            this.rtbTalk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTalk.Location = new System.Drawing.Point(3, 16);
            this.rtbTalk.Name = "rtbTalk";
            this.rtbTalk.Size = new System.Drawing.Size(1122, 81);
            this.rtbTalk.TabIndex = 0;
            this.rtbTalk.Text = "";
            this.rtbTalk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbTalk_KeyUp);
            // 
            // ircCore1
            // 
            this.ircCore1.ConnectionStatus = myIRC.IRCCore.ConnectionState.Disconnected;
            this.ircCore1.WorkerReportsProgress = true;
            this.ircCore1.WorkerSupportsCancellation = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(449, 19);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.rtbGeneral);
            this.groupBoxControl.Controls.Add(this.btnRegister);
            this.groupBoxControl.Controls.Add(this.button1);
            this.groupBoxControl.Controls.Add(this.tbServer);
            this.groupBoxControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxControl.Location = new System.Drawing.Point(0, 0);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(1128, 224);
            this.groupBoxControl.TabIndex = 6;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "groupBox2";
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.rtbBox);
            this.groupBoxMain.Controls.Add(this.rtbSenders);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxMain.Location = new System.Drawing.Point(0, 224);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(1128, 356);
            this.groupBoxMain.TabIndex = 7;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "groupBox3";
            // 
            // rtbGeneral
            // 
            this.rtbGeneral.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbGeneral.Location = new System.Drawing.Point(3, 48);
            this.rtbGeneral.Name = "rtbGeneral";
            this.rtbGeneral.ReadOnly = true;
            this.rtbGeneral.Size = new System.Drawing.Size(1122, 173);
            this.rtbGeneral.TabIndex = 6;
            this.rtbGeneral.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 742);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.groupBoxControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.groupBoxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSenders;
        private System.Windows.Forms.RichTextBox rtbBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbServer;
        private IRCCore ircCore1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbTalk;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.RichTextBox rtbGeneral;
    }
}

