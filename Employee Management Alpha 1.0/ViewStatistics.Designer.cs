﻿
namespace Employee_Management_Alpha_1._0
{
    partial class ViewStatistics
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
            this.empList = new System.Windows.Forms.ListBox();
            this.labelTotalShift = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // empList
            // 
            this.empList.FormattingEnabled = true;
            this.empList.Location = new System.Drawing.Point(12, 58);
            this.empList.Name = "empList";
            this.empList.Size = new System.Drawing.Size(214, 303);
            this.empList.TabIndex = 0;
            this.empList.SelectedIndexChanged += new System.EventHandler(this.empList_SelectedIndexChanged);
            // 
            // labelTotalShift
            // 
            this.labelTotalShift.AutoSize = true;
            this.labelTotalShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalShift.ForeColor = System.Drawing.Color.White;
            this.labelTotalShift.Location = new System.Drawing.Point(232, 77);
            this.labelTotalShift.Name = "labelTotalShift";
            this.labelTotalShift.Size = new System.Drawing.Size(355, 18);
            this.labelTotalShift.TabIndex = 1;
            this.labelTotalShift.Text = "This employee has been scheduled a total of 0 shifts.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select an employee below to view their statistics:";
            // 
            // ViewStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(616, 396);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTotalShift);
            this.Controls.Add(this.empList);
            this.Name = "ViewStatistics";
            this.Text = "Scheduling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox empList;
        private System.Windows.Forms.Label labelTotalShift;
        private System.Windows.Forms.Label label1;
    }
}