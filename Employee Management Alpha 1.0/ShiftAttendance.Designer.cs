
namespace Employee_Management_Alpha_1._0
{
    partial class ShiftAttendance
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
            this.label2 = new System.Windows.Forms.Label();
            this.assignedList = new System.Windows.Forms.ListBox();
            this.checkedList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLoadSchedule = new System.Windows.Forms.Button();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.cbCWeek = new System.Windows.Forms.ComboBox();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnToday = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(80, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Assigned shifts:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(323, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Checked-in shifts:";
            // 
            // assignedList
            // 
            this.assignedList.FormattingEnabled = true;
            this.assignedList.Location = new System.Drawing.Point(83, 138);
            this.assignedList.Name = "assignedList";
            this.assignedList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.assignedList.Size = new System.Drawing.Size(208, 303);
            this.assignedList.TabIndex = 17;
            // 
            // checkedList
            // 
            this.checkedList.FormattingEnabled = true;
            this.checkedList.Location = new System.Drawing.Point(326, 138);
            this.checkedList.Name = "checkedList";
            this.checkedList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.checkedList.Size = new System.Drawing.Size(208, 303);
            this.checkedList.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(90, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Calendar week:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(139, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Year:";
            // 
            // buttonLoadSchedule
            // 
            this.buttonLoadSchedule.Location = new System.Drawing.Point(302, 39);
            this.buttonLoadSchedule.Name = "buttonLoadSchedule";
            this.buttonLoadSchedule.Size = new System.Drawing.Size(84, 48);
            this.buttonLoadSchedule.TabIndex = 25;
            this.buttonLoadSchedule.Text = "Load";
            this.buttonLoadSchedule.UseVisualStyleBackColor = true;
            this.buttonLoadSchedule.Click += new System.EventHandler(this.buttonLoadSchedule_Click);
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cbYear.Location = new System.Drawing.Point(175, 39);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(121, 21);
            this.cbYear.TabIndex = 24;
            // 
            // cbCWeek
            // 
            this.cbCWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCWeek.FormattingEnabled = true;
            this.cbCWeek.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52"});
            this.cbCWeek.Location = new System.Drawing.Point(175, 66);
            this.cbCWeek.Name = "cbCWeek";
            this.cbCWeek.Size = new System.Drawing.Size(121, 21);
            this.cbCWeek.TabIndex = 23;
            // 
            // cbDay
            // 
            this.cbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbDay.Location = new System.Drawing.Point(175, 93);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(121, 21);
            this.cbDay.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(101, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Day of week:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(107, 16);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Shift Attendence:";
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(302, 93);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(84, 21);
            this.btnToday.TabIndex = 31;
            this.btnToday.Text = "View Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // ShiftAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(797, 574);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonLoadSchedule);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.cbCWeek);
            this.Controls.Add(this.checkedList);
            this.Controls.Add(this.assignedList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShiftAttendance";
            this.Text = "ShiftAttendance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox assignedList;
        private System.Windows.Forms.ListBox checkedList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLoadSchedule;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbCWeek;
        private System.Windows.Forms.ComboBox cbDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnToday;
    }
}