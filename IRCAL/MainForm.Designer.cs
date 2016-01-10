namespace myIRC
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbEntry = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbTopic = new System.Windows.Forms.RichTextBox();
            this.rtbTalk = new System.Windows.Forms.RichTextBox();
            this.btnPrivMsg = new System.Windows.Forms.Button();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.cbEntry = new System.Windows.Forms.ComboBox();
            this.btnJoinFavs = new System.Windows.Forms.Button();
            this.lblModes = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNick = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddChanToFavorites = new System.Windows.Forms.Button();
            this.btnJoinChans = new System.Windows.Forms.Button();
            this.rtbGeneral = new System.Windows.Forms.RichTextBox();
            this.tvChans = new System.Windows.Forms.TreeView();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.lbChanUsers = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelFavoritsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privateMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nicksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ircCore1 = new myIRC.IRCCore(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbBox
            // 
            this.rtbBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBox.EnableAutoDragDrop = true;
            this.rtbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBox.HideSelection = false;
            this.rtbBox.Location = new System.Drawing.Point(3, 16);
            this.rtbBox.Name = "rtbBox";
            this.rtbBox.ReadOnly = true;
            this.rtbBox.Size = new System.Drawing.Size(951, 337);
            this.rtbBox.TabIndex = 1;
            this.rtbBox.Text = "";
            this.rtbBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbBox_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // tbEntry
            // 
            this.tbEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEntry.Location = new System.Drawing.Point(309, 13);
            this.tbEntry.Name = "tbEntry";
            this.tbEntry.Size = new System.Drawing.Size(161, 22);
            this.tbEntry.TabIndex = 3;
            this.tbEntry.Text = "IRC.freenode.net";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbTopic);
            this.groupBox1.Controls.Add(this.rtbTalk);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 533);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1128, 155);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send Box";
            // 
            // rtbTopic
            // 
            this.rtbTopic.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTopic.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rtbTopic.Location = new System.Drawing.Point(3, 45);
            this.rtbTopic.Name = "rtbTopic";
            this.rtbTopic.ReadOnly = true;
            this.rtbTopic.Size = new System.Drawing.Size(1122, 77);
            this.rtbTopic.TabIndex = 1;
            this.rtbTopic.Text = "";
            this.rtbTopic.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbTopic_LinkClicked);
            // 
            // rtbTalk
            // 
            this.rtbTalk.AcceptsTab = true;
            this.rtbTalk.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbTalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTalk.Location = new System.Drawing.Point(3, 16);
            this.rtbTalk.Name = "rtbTalk";
            this.rtbTalk.Size = new System.Drawing.Size(1122, 29);
            this.rtbTalk.TabIndex = 0;
            this.rtbTalk.TabStop = false;
            this.rtbTalk.Text = "";
            this.rtbTalk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbTalk_KeyDown);
            // 
            // btnPrivMsg
            // 
            this.btnPrivMsg.Location = new System.Drawing.Point(202, 69);
            this.btnPrivMsg.Name = "btnPrivMsg";
            this.btnPrivMsg.Size = new System.Drawing.Size(101, 23);
            this.btnPrivMsg.TabIndex = 5;
            this.btnPrivMsg.Text = "View Priv Msg";
            this.btnPrivMsg.UseVisualStyleBackColor = true;
            this.btnPrivMsg.Click += new System.EventHandler(this.btnViewPrivMessages_Click);
            this.btnPrivMsg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPrivMsg_MouseDown);
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.cbEntry);
            this.groupBoxControl.Controls.Add(this.btnJoinFavs);
            this.groupBoxControl.Controls.Add(this.lblModes);
            this.groupBoxControl.Controls.Add(this.lblChannel);
            this.groupBoxControl.Controls.Add(this.label3);
            this.groupBoxControl.Controls.Add(this.label2);
            this.groupBoxControl.Controls.Add(this.tbNick);
            this.groupBoxControl.Controls.Add(this.tbUser);
            this.groupBoxControl.Controls.Add(this.button2);
            this.groupBoxControl.Controls.Add(this.btnLeave);
            this.groupBoxControl.Controls.Add(this.label1);
            this.groupBoxControl.Controls.Add(this.btnAddChanToFavorites);
            this.groupBoxControl.Controls.Add(this.btnJoinChans);
            this.groupBoxControl.Controls.Add(this.rtbGeneral);
            this.groupBoxControl.Controls.Add(this.btnPrivMsg);
            this.groupBoxControl.Controls.Add(this.button1);
            this.groupBoxControl.Controls.Add(this.tbEntry);
            this.groupBoxControl.Controls.Add(this.tvChans);
            this.groupBoxControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxControl.Location = new System.Drawing.Point(0, 24);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(1128, 153);
            this.groupBoxControl.TabIndex = 6;
            this.groupBoxControl.TabStop = false;
            // 
            // cbEntry
            // 
            this.cbEntry.FormattingEnabled = true;
            this.cbEntry.Items.AddRange(new object[] {
            "irc.freenode.net",
            "irc.starchat.net"});
            this.cbEntry.Location = new System.Drawing.Point(309, 15);
            this.cbEntry.Name = "cbEntry";
            this.cbEntry.Size = new System.Drawing.Size(161, 21);
            this.cbEntry.TabIndex = 22;
            // 
            // btnJoinFavs
            // 
            this.btnJoinFavs.Location = new System.Drawing.Point(543, 69);
            this.btnJoinFavs.Name = "btnJoinFavs";
            this.btnJoinFavs.Size = new System.Drawing.Size(100, 23);
            this.btnJoinFavs.TabIndex = 21;
            this.btnJoinFavs.Text = "Join Favorites";
            this.btnJoinFavs.UseVisualStyleBackColor = true;
            this.btnJoinFavs.Click += new System.EventHandler(this.btnJoinFavs_Click);
            // 
            // lblModes
            // 
            this.lblModes.AutoSize = true;
            this.lblModes.Location = new System.Drawing.Point(131, 42);
            this.lblModes.Name = "lblModes";
            this.lblModes.Size = new System.Drawing.Size(62, 13);
            this.lblModes.TabIndex = 20;
            this.lblModes.Text = "No channel";
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(131, 24);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(62, 13);
            this.lblChannel.TabIndex = 19;
            this.lblChannel.Text = "No channel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nick";
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(543, 16);
            this.tbNick.Name = "tbNick";
            this.tbNick.Size = new System.Drawing.Size(100, 20);
            this.tbNick.TabIndex = 15;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(543, 42);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(100, 20);
            this.tbUser.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(649, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Set Registration";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Location = new System.Drawing.Point(1008, 3);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(91, 41);
            this.btnLeave.TabIndex = 12;
            this.btnLeave.Text = "Leave Checked Channels";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Visible = false;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pick Server:";
            // 
            // btnAddChanToFavorites
            // 
            this.btnAddChanToFavorites.Location = new System.Drawing.Point(902, 45);
            this.btnAddChanToFavorites.Name = "btnAddChanToFavorites";
            this.btnAddChanToFavorites.Size = new System.Drawing.Size(100, 23);
            this.btnAddChanToFavorites.TabIndex = 10;
            this.btnAddChanToFavorites.Text = "Add Channel";
            this.btnAddChanToFavorites.UseVisualStyleBackColor = true;
            this.btnAddChanToFavorites.Visible = false;
            this.btnAddChanToFavorites.Click += new System.EventHandler(this.btnAddChanToFavorites_Click);
            // 
            // btnJoinChans
            // 
            this.btnJoinChans.Location = new System.Drawing.Point(1008, 47);
            this.btnJoinChans.Name = "btnJoinChans";
            this.btnJoinChans.Size = new System.Drawing.Size(96, 37);
            this.btnJoinChans.TabIndex = 9;
            this.btnJoinChans.Text = "Join Checked Channels";
            this.btnJoinChans.UseVisualStyleBackColor = true;
            this.btnJoinChans.Visible = false;
            this.btnJoinChans.Click += new System.EventHandler(this.btnJoinChans_Click);
            // 
            // rtbGeneral
            // 
            this.rtbGeneral.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbGeneral.Location = new System.Drawing.Point(124, 98);
            this.rtbGeneral.Name = "rtbGeneral";
            this.rtbGeneral.ReadOnly = true;
            this.rtbGeneral.Size = new System.Drawing.Size(1001, 52);
            this.rtbGeneral.TabIndex = 6;
            this.rtbGeneral.Text = "";
            // 
            // tvChans
            // 
            this.tvChans.BackColor = System.Drawing.Color.MistyRose;
            this.tvChans.CheckBoxes = true;
            this.tvChans.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvChans.Location = new System.Drawing.Point(3, 16);
            this.tvChans.Name = "tvChans";
            this.tvChans.Size = new System.Drawing.Size(121, 134);
            this.tvChans.TabIndex = 18;
            this.tvChans.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvChans_AfterSelect);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.rtbBox);
            this.groupBoxMain.Controls.Add(this.lbChanUsers);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxMain.Location = new System.Drawing.Point(0, 177);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(1128, 356);
            this.groupBoxMain.TabIndex = 7;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Channel Messages";
            // 
            // lbChanUsers
            // 
            this.lbChanUsers.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbChanUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChanUsers.FormattingEnabled = true;
            this.lbChanUsers.ItemHeight = 16;
            this.lbChanUsers.Location = new System.Drawing.Point(954, 16);
            this.lbChanUsers.Name = "lbChanUsers";
            this.lbChanUsers.Size = new System.Drawing.Size(171, 324);
            this.lbChanUsers.TabIndex = 3;
            this.lbChanUsers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbChanUsers_DrawItem);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.notificationsToolStripMenuItem,
            this.rawLogToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1128, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverListToolStripMenuItem,
            this.channelFavoritsToolStripMenuItem,
            this.privateMessagesToolStripMenuItem,
            this.generalConfigurationToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // serverListToolStripMenuItem
            // 
            this.serverListToolStripMenuItem.Name = "serverListToolStripMenuItem";
            this.serverListToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.serverListToolStripMenuItem.Text = "Server List";
            this.serverListToolStripMenuItem.Click += new System.EventHandler(this.serverListToolStripMenuItem_Click);
            // 
            // channelFavoritsToolStripMenuItem
            // 
            this.channelFavoritsToolStripMenuItem.Name = "channelFavoritsToolStripMenuItem";
            this.channelFavoritsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.channelFavoritsToolStripMenuItem.Text = "Channel Favorites";
            this.channelFavoritsToolStripMenuItem.Click += new System.EventHandler(this.channelFavoritsToolStripMenuItem_Click);
            // 
            // privateMessagesToolStripMenuItem
            // 
            this.privateMessagesToolStripMenuItem.Name = "privateMessagesToolStripMenuItem";
            this.privateMessagesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.privateMessagesToolStripMenuItem.Text = "Private Messages";
            this.privateMessagesToolStripMenuItem.Click += new System.EventHandler(this.privateMessagesToolStripMenuItem_Click);
            // 
            // generalConfigurationToolStripMenuItem
            // 
            this.generalConfigurationToolStripMenuItem.Name = "generalConfigurationToolStripMenuItem";
            this.generalConfigurationToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.generalConfigurationToolStripMenuItem.Text = "General Configuration";
            this.generalConfigurationToolStripMenuItem.Click += new System.EventHandler(this.generalConfigurationToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nicksToolStripMenuItem});
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            // 
            // nicksToolStripMenuItem
            // 
            this.nicksToolStripMenuItem.Name = "nicksToolStripMenuItem";
            this.nicksToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.nicksToolStripMenuItem.Text = "Nicks";
            this.nicksToolStripMenuItem.Click += new System.EventHandler(this.nicksToolStripMenuItem_Click);
            // 
            // rawLogToolStripMenuItem
            // 
            this.rawLogToolStripMenuItem.Name = "rawLogToolStripMenuItem";
            this.rawLogToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.rawLogToolStripMenuItem.Text = "RawLog";
            this.rawLogToolStripMenuItem.Click += new System.EventHandler(this.rawLogToolStripMenuItem_Click);
            // 
            // ircCore1
            // 
            this.ircCore1.ConnectionStatus = myIRC.IRCCore.ConnectionState.Disconnected;
            this.ircCore1.RawLog = null;
            this.ircCore1.ServerName = null;
            this.ircCore1.WorkerReportsProgress = true;
            this.ircCore1.WorkerSupportsCancellation = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 696);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "IRCAL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.groupBoxMain.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbEntry;
        private IRCCore ircCore1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbTalk;
        private System.Windows.Forms.Button btnPrivMsg;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.RichTextBox rtbGeneral;
        private System.Windows.Forms.Button btnJoinChans;
        private System.Windows.Forms.Button btnAddChanToFavorites;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelFavoritsToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNick;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView tvChans;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nicksToolStripMenuItem;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.ToolStripMenuItem rawLogToolStripMenuItem;
        private System.Windows.Forms.Label lblModes;
        private System.Windows.Forms.Button btnJoinFavs;
        private System.Windows.Forms.RichTextBox rtbTopic;
        private System.Windows.Forms.ComboBox cbEntry;
        private System.Windows.Forms.ToolStripMenuItem privateMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalConfigurationToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbChanUsers;
    }
}

