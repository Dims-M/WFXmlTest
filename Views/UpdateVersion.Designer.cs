﻿namespace WFXmlTest.Views
{
    partial class UpdateVersion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAssemblyApp = new System.Windows.Forms.Label();
            this.lbInfaVersion = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbOldVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbOldVersion);
            this.panel1.Controls.Add(this.lbAssemblyApp);
            this.panel1.Controls.Add(this.lbInfaVersion);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 194);
            this.panel1.TabIndex = 4;
            // 
            // lbAssemblyApp
            // 
            this.lbAssemblyApp.AutoSize = true;
            this.lbAssemblyApp.Location = new System.Drawing.Point(147, 62);
            this.lbAssemblyApp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAssemblyApp.Name = "lbAssemblyApp";
            this.lbAssemblyApp.Size = new System.Drawing.Size(0, 13);
            this.lbAssemblyApp.TabIndex = 8;
            // 
            // lbInfaVersion
            // 
            this.lbInfaVersion.AutoSize = true;
            this.lbInfaVersion.Location = new System.Drawing.Point(147, 21);
            this.lbInfaVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbInfaVersion.Name = "lbInfaVersion";
            this.lbInfaVersion.Size = new System.Drawing.Size(0, 13);
            this.lbInfaVersion.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Location = new System.Drawing.Point(0, 131);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.MaximumSize = new System.Drawing.Size(406, 63);
            this.button3.MinimumSize = new System.Drawing.Size(406, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(406, 63);
            this.button3.TabIndex = 3;
            this.button3.Text = "Обновление программы!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сборка App:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Версия файла:";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(406, 104);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(9, 217);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 104);
            this.panel2.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbOldVersion
            // 
            this.lbOldVersion.AutoSize = true;
            this.lbOldVersion.Location = new System.Drawing.Point(20, 97);
            this.lbOldVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOldVersion.Name = "lbOldVersion";
            this.lbOldVersion.Size = new System.Drawing.Size(19, 13);
            this.lbOldVersion.TabIndex = 9;
            this.lbOldVersion.Text = "12";
            // 
            // UpdateVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 324);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UpdateVersion";
            this.Text = "UpdateVersion";
            this.Load += new System.EventHandler(this.UpdateVersion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbInfaVersion;
        private System.Windows.Forms.Label lbAssemblyApp;
        private System.Windows.Forms.Label lbOldVersion;
    }
}