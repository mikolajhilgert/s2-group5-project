
namespace Employee_Management_Alpha_1._0
{
    partial class ShiftAssignment
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAssigned = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttnUnAssign = new System.Windows.Forms.Button();
            this.bttnAssign = new System.Windows.Forms.Button();
            this.gdvAvailable = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(293, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Available employees:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(52, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Assigned employees:";
            // 
            // dgvAssigned
            // 
            this.dgvAssigned.AllowUserToAddRows = false;
            this.dgvAssigned.AllowUserToDeleteRows = false;
            this.dgvAssigned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssigned.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name});
            this.dgvAssigned.Location = new System.Drawing.Point(28, 80);
            this.dgvAssigned.Name = "dgvAssigned";
            this.dgvAssigned.ReadOnly = true;
            this.dgvAssigned.RowHeadersVisible = false;
            this.dgvAssigned.Size = new System.Drawing.Size(153, 313);
            this.dgvAssigned.TabIndex = 5;
            // 
            // name
            // 
            this.name.HeaderText = "";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // bttnUnAssign
            // 
            this.bttnUnAssign.Location = new System.Drawing.Point(204, 231);
            this.bttnUnAssign.Name = "bttnUnAssign";
            this.bttnUnAssign.Size = new System.Drawing.Size(44, 44);
            this.bttnUnAssign.TabIndex = 7;
            this.bttnUnAssign.Text = ">";
            this.bttnUnAssign.UseVisualStyleBackColor = true;
            this.bttnUnAssign.Click += new System.EventHandler(this.bttnUnAssign_Click);
            // 
            // bttnAssign
            // 
            this.bttnAssign.Location = new System.Drawing.Point(204, 181);
            this.bttnAssign.Name = "bttnAssign";
            this.bttnAssign.Size = new System.Drawing.Size(44, 44);
            this.bttnAssign.TabIndex = 8;
            this.bttnAssign.Text = "<";
            this.bttnAssign.UseVisualStyleBackColor = true;
            this.bttnAssign.Click += new System.EventHandler(this.bttnAssign_Click);
            // 
            // gdvAvailable
            // 
            this.gdvAvailable.AllowUserToAddRows = false;
            this.gdvAvailable.AllowUserToDeleteRows = false;
            this.gdvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvAvailable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.gdvAvailable.Location = new System.Drawing.Point(270, 80);
            this.gdvAvailable.Name = "gdvAvailable";
            this.gdvAvailable.ReadOnly = true;
            this.gdvAvailable.RowHeadersVisible = false;
            this.gdvAvailable.Size = new System.Drawing.Size(210, 313);
            this.gdvAvailable.TabIndex = 9;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(45, 16);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "label3";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 242;
            // 
            // ShiftAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(508, 426);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gdvAvailable);
            this.Controls.Add(this.bttnAssign);
            this.Controls.Add(this.bttnUnAssign);
            this.Controls.Add(this.dgvAssigned);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShiftAssignment";
            this.Text = "ShiftAssignment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShiftAssignment_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAssigned;
        private System.Windows.Forms.Button bttnUnAssign;
        private System.Windows.Forms.Button bttnAssign;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridView gdvAvailable;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}