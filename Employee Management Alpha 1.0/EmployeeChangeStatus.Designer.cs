namespace Employee_Management_Alpha_1._0
{
    partial class EmployeeChangeStatus
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
            this.lbViewEmployees = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbxSelectStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbViewEmployees
            // 
            this.lbViewEmployees.FormattingEnabled = true;
            this.lbViewEmployees.Location = new System.Drawing.Point(312, 36);
            this.lbViewEmployees.Margin = new System.Windows.Forms.Padding(2);
            this.lbViewEmployees.Name = "lbViewEmployees";
            this.lbViewEmployees.Size = new System.Drawing.Size(286, 342);
            this.lbViewEmployees.TabIndex = 4;
            this.lbViewEmployees.SelectedIndexChanged += new System.EventHandler(this.lbViewEmployees_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(68, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Insert ID of employee to modify:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(70, 54);
            this.tbID.Margin = new System.Windows.Forms.Padding(2);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(135, 20);
            this.tbID.TabIndex = 37;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnUpdate.ForeColor = System.Drawing.Color.Silver;
            this.btnUpdate.Location = new System.Drawing.Point(70, 333);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(134, 44);
            this.btnUpdate.TabIndex = 36;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbxSelectStatus
            // 
            this.cbxSelectStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSelectStatus.FormattingEnabled = true;
            this.cbxSelectStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cbxSelectStatus.Location = new System.Drawing.Point(70, 105);
            this.cbxSelectStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSelectStatus.Name = "cbxSelectStatus";
            this.cbxSelectStatus.Size = new System.Drawing.Size(135, 21);
            this.cbxSelectStatus.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(68, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Select status:";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Employee_Management_Alpha_1._0.Properties.Resources.icons8_back_24;
            this.btnClose.Location = new System.Drawing.Point(9, 10);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EmployeeChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(616, 396);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSelectStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbViewEmployees);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EmployeeChangeStatus";
            this.Text = "EmployeeStatusChange";
            this.Load += new System.EventHandler(this.EmployeeChangeStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lbViewEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbxSelectStatus;
        private System.Windows.Forms.Label label2;
    }
}