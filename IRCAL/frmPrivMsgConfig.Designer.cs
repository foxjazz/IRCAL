﻿namespace myIRC
{
    partial class frmPrivMsgConfig
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
            this.lbNicks = new System.Windows.Forms.ListBox();
            this.tbNick = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNicks
            // 
            this.lbNicks.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNicks.FormattingEnabled = true;
            this.lbNicks.Location = new System.Drawing.Point(0, 0);
            this.lbNicks.Name = "lbNicks";
            this.lbNicks.Size = new System.Drawing.Size(120, 303);
            this.lbNicks.TabIndex = 0;
            this.lbNicks.SelectedIndexChanged += new System.EventHandler(this.lbNicks_SelectedIndexChanged);
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(126, 5);
            this.tbNick.Name = "tbNick";
            this.tbNick.Size = new System.Drawing.Size(123, 20);
            this.tbNick.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(126, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(226, 31);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // frmPrivMsgConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 311);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbNick);
            this.Controls.Add(this.lbNicks);
            this.Name = "frmPrivMsgConfig";
            this.Text = "frmPrivMsgConfig";
            this.Load += new System.EventHandler(this.frmPrivMsgConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbNicks;
        private System.Windows.Forms.TextBox tbNick;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}