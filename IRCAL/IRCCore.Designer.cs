﻿namespace myIRC
{
    partial class IRCCore
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectionWorker1 = new System.ComponentModel.BackgroundWorker();
            // 
            // ConnectionWorker1
            // 
            this.ConnectionWorker1.WorkerReportsProgress = true;
            this.ConnectionWorker1.WorkerSupportsCancellation = true;

        }

        #endregion

        private System.ComponentModel.BackgroundWorker ConnectionWorker1;
    }
}