namespace Employee_Management_Alpha_1._0
{
    partial class DepartmentAssignment
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
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnUnassign = new System.Windows.Forms.Button();
            this.lbAssigned = new System.Windows.Forms.ListBox();
            this.lbAvailable = new System.Windows.Forms.ListBox();
            this.lblAssigned = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(286, 194);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(44, 44);
            this.btnAssign.TabIndex = 10;
            this.btnAssign.Text = "<";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnUnassign
            // 
            this.btnUnassign.Location = new System.Drawing.Point(286, 244);
            this.btnUnassign.Name = "btnUnassign";
            this.btnUnassign.Size = new System.Drawing.Size(44, 44);
            this.btnUnassign.TabIndex = 9;
            this.btnUnassign.Text = ">";
            this.btnUnassign.UseVisualStyleBackColor = true;
            this.btnUnassign.Click += new System.EventHandler(this.btnUnassign_Click);
            // 
            // lbAssigned
            // 
            this.lbAssigned.FormattingEnabled = true;
            this.lbAssigned.Location = new System.Drawing.Point(30, 107);
            this.lbAssigned.Name = "lbAssigned";
            this.lbAssigned.Size = new System.Drawing.Size(195, 277);
            this.lbAssigned.TabIndex = 11;
            // 
            // lbAvailable
            // 
            this.lbAvailable.FormattingEnabled = true;
            this.lbAvailable.Location = new System.Drawing.Point(391, 107);
            this.lbAvailable.Name = "lbAvailable";
            this.lbAvailable.Size = new System.Drawing.Size(195, 277);
            this.lbAvailable.TabIndex = 12;
            // 
            // lblAssigned
            // 
            this.lblAssigned.AutoSize = true;
            this.lblAssigned.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAssigned.Location = new System.Drawing.Point(80, 81);
            this.lblAssigned.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAssigned.Name = "lblAssigned";
            this.lblAssigned.Size = new System.Drawing.Size(106, 13);
            this.lblAssigned.TabIndex = 37;
            this.lblAssigned.Text = "Assigned employees:";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAvailable.Location = new System.Drawing.Point(435, 81);
            this.lblAvailable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(103, 13);
            this.lblAvailable.TabIndex = 38;
            this.lblAvailable.Text = "Available employees";
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(198, 35);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(220, 21);
            this.cmbDepartments.TabIndex = 39;
            this.cmbDepartments.SelectedIndexChanged += new System.EventHandler(this.cmbDepartments_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(252, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Select Department";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_back_24;
            this.btnClose.Location = new System.Drawing.Point(11, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 27);
            this.btnClose.TabIndex = 70;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DepartmentAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(616, 396);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDepartments);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.lblAssigned);
            this.Controls.Add(this.lbAvailable);
            this.Controls.Add(this.lbAssigned);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnUnassign);
            this.Name = "DepartmentAssignment";
            this.Text = "DepartmentAssignment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnUnassign;
        private System.Windows.Forms.ListBox lbAssigned;
        private System.Windows.Forms.ListBox lbAvailable;
        private System.Windows.Forms.Label lblAssigned;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}