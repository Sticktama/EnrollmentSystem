namespace EnrollmentSystem
{
    partial class SubjectScheduleEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectScheduleEntry));
            this.label1 = new System.Windows.Forms.Label();
            this.SubjectEDPCodeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SubjectCodeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DaysTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SectionTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RoomTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SchoolYearTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.DescriptionTextBox = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.PreviousButton = new System.Windows.Forms.Button();
            this.JumpPanelButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.PictureBox();
            this.ScheduleInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeButton)).BeginInit();
            this.ScheduleInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1046, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject Schedule Entry";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubjectEDPCodeTextBox
            // 
            this.SubjectEDPCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectEDPCodeTextBox.Location = new System.Drawing.Point(141, 41);
            this.SubjectEDPCodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SubjectEDPCodeTextBox.Name = "SubjectEDPCodeTextBox";
            this.SubjectEDPCodeTextBox.Size = new System.Drawing.Size(133, 24);
            this.SubjectEDPCodeTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "EDP Code:";
            // 
            // SubjectCodeTextBox
            // 
            this.SubjectCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectCodeTextBox.Location = new System.Drawing.Point(140, 74);
            this.SubjectCodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SubjectCodeTextBox.Name = "SubjectCodeTextBox";
            this.SubjectCodeTextBox.Size = new System.Drawing.Size(134, 24);
            this.SubjectCodeTextBox.TabIndex = 12;
            this.SubjectCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SubjectCode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Subject Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(282, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(28, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Time Start:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(35, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "Time End:";
            // 
            // DaysTextBox
            // 
            this.DaysTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysTextBox.Location = new System.Drawing.Point(348, 141);
            this.DaysTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.DaysTextBox.Name = "DaysTextBox";
            this.DaysTextBox.Size = new System.Drawing.Size(58, 24);
            this.DaysTextBox.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(288, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 22);
            this.label7.TabIndex = 19;
            this.label7.Text = "Days:";
            // 
            // SectionTextBox
            // 
            this.SectionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionTextBox.Location = new System.Drawing.Point(507, 141);
            this.SectionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SectionTextBox.Name = "SectionTextBox";
            this.SectionTextBox.Size = new System.Drawing.Size(58, 24);
            this.SectionTextBox.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(430, 144);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 22);
            this.label8.TabIndex = 21;
            this.label8.Text = "Section:";
            // 
            // RoomTextBox
            // 
            this.RoomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomTextBox.Location = new System.Drawing.Point(141, 214);
            this.RoomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.RoomTextBox.Name = "RoomTextBox";
            this.RoomTextBox.Size = new System.Drawing.Size(135, 24);
            this.RoomTextBox.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(64, 215);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 22);
            this.label9.TabIndex = 23;
            this.label9.Text = "Room:";
            // 
            // SchoolYearTextBox
            // 
            this.SchoolYearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolYearTextBox.Location = new System.Drawing.Point(429, 213);
            this.SchoolYearTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SchoolYearTextBox.Name = "SchoolYearTextBox";
            this.SchoolYearTextBox.Size = new System.Drawing.Size(136, 24);
            this.SchoolYearTextBox.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(318, 215);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 22);
            this.label10.TabIndex = 25;
            this.label10.Text = "School Year:";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.Black;
            this.SaveButton.Location = new System.Drawing.Point(357, 263);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(99, 30);
            this.SaveButton.TabIndex = 29;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.Color.Black;
            this.ClearButton.Location = new System.Drawing.Point(466, 263);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(99, 30);
            this.ClearButton.TabIndex = 30;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTextBox.ForeColor = System.Drawing.Color.Black;
            this.DescriptionTextBox.Location = new System.Drawing.Point(286, 73);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(279, 24);
            this.DescriptionTextBox.TabIndex = 31;
            // 
            // PreviousButton
            // 
            this.PreviousButton.BackColor = System.Drawing.Color.Teal;
            this.PreviousButton.FlatAppearance.BorderSize = 0;
            this.PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousButton.ForeColor = System.Drawing.Color.White;
            this.PreviousButton.Location = new System.Drawing.Point(446, 454);
            this.PreviousButton.Margin = new System.Windows.Forms.Padding(4);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(32, 33);
            this.PreviousButton.TabIndex = 58;
            this.PreviousButton.Text = "<";
            this.PreviousButton.UseVisualStyleBackColor = false;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // JumpPanelButton
            // 
            this.JumpPanelButton.BackColor = System.Drawing.Color.Teal;
            this.JumpPanelButton.FlatAppearance.BorderSize = 0;
            this.JumpPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JumpPanelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JumpPanelButton.ForeColor = System.Drawing.Color.White;
            this.JumpPanelButton.Location = new System.Drawing.Point(478, 454);
            this.JumpPanelButton.Margin = new System.Windows.Forms.Padding(4);
            this.JumpPanelButton.Name = "JumpPanelButton";
            this.JumpPanelButton.Size = new System.Drawing.Size(87, 33);
            this.JumpPanelButton.TabIndex = 57;
            this.JumpPanelButton.Text = "&3 of 4";
            this.JumpPanelButton.UseVisualStyleBackColor = false;
            this.JumpPanelButton.Click += new System.EventHandler(this.JumpPanelButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.Teal;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.ForeColor = System.Drawing.Color.White;
            this.NextButton.Location = new System.Drawing.Point(565, 454);
            this.NextButton.Margin = new System.Windows.Forms.Padding(4);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(32, 33);
            this.NextButton.TabIndex = 56;
            this.NextButton.Text = ">";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.Image = ((System.Drawing.Image)(resources.GetObject("HomeButton.Image")));
            this.HomeButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("HomeButton.InitialImage")));
            this.HomeButton.Location = new System.Drawing.Point(621, 106);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(399, 266);
            this.HomeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HomeButton.TabIndex = 60;
            this.HomeButton.TabStop = false;
            // 
            // ScheduleInfoGroupBox
            // 
            this.ScheduleInfoGroupBox.BackColor = System.Drawing.Color.Teal;
            this.ScheduleInfoGroupBox.Controls.Add(this.EndTimePicker);
            this.ScheduleInfoGroupBox.Controls.Add(this.StartTimePicker);
            this.ScheduleInfoGroupBox.Controls.Add(this.label2);
            this.ScheduleInfoGroupBox.Controls.Add(this.SubjectEDPCodeTextBox);
            this.ScheduleInfoGroupBox.Controls.Add(this.label3);
            this.ScheduleInfoGroupBox.Controls.Add(this.SubjectCodeTextBox);
            this.ScheduleInfoGroupBox.Controls.Add(this.label4);
            this.ScheduleInfoGroupBox.Controls.Add(this.ClearButton);
            this.ScheduleInfoGroupBox.Controls.Add(this.label5);
            this.ScheduleInfoGroupBox.Controls.Add(this.SaveButton);
            this.ScheduleInfoGroupBox.Controls.Add(this.label6);
            this.ScheduleInfoGroupBox.Controls.Add(this.DescriptionTextBox);
            this.ScheduleInfoGroupBox.Controls.Add(this.label7);
            this.ScheduleInfoGroupBox.Controls.Add(this.DaysTextBox);
            this.ScheduleInfoGroupBox.Controls.Add(this.label8);
            this.ScheduleInfoGroupBox.Controls.Add(this.SectionTextBox);
            this.ScheduleInfoGroupBox.Controls.Add(this.SchoolYearTextBox);
            this.ScheduleInfoGroupBox.Controls.Add(this.label9);
            this.ScheduleInfoGroupBox.Controls.Add(this.label10);
            this.ScheduleInfoGroupBox.Controls.Add(this.RoomTextBox);
            this.ScheduleInfoGroupBox.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScheduleInfoGroupBox.ForeColor = System.Drawing.Color.White;
            this.ScheduleInfoGroupBox.Location = new System.Drawing.Point(24, 97);
            this.ScheduleInfoGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.ScheduleInfoGroupBox.Name = "ScheduleInfoGroupBox";
            this.ScheduleInfoGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.ScheduleInfoGroupBox.Size = new System.Drawing.Size(590, 316);
            this.ScheduleInfoGroupBox.TabIndex = 62;
            this.ScheduleInfoGroupBox.TabStop = false;
            this.ScheduleInfoGroupBox.Text = "Schedule Information";
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTimePicker.Location = new System.Drawing.Point(140, 158);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowUpDown = true;
            this.EndTimePicker.Size = new System.Drawing.Size(134, 27);
            this.EndTimePicker.TabIndex = 35;
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTimePicker.Location = new System.Drawing.Point(140, 124);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.ShowUpDown = true;
            this.StartTimePicker.Size = new System.Drawing.Size(134, 27);
            this.StartTimePicker.TabIndex = 34;
            // 
            // SubjectScheduleEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1046, 511);
            this.Controls.Add(this.ScheduleInfoGroupBox);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.JumpPanelButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SubjectScheduleEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubjectScheduleEntry";
            this.Load += new System.EventHandler(this.SubjectScheduleEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeButton)).EndInit();
            this.ScheduleInfoGroupBox.ResumeLayout(false);
            this.ScheduleInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SubjectEDPCodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SubjectCodeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DaysTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SectionTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox RoomTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SchoolYearTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label DescriptionTextBox;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button JumpPanelButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.PictureBox HomeButton;
        private System.Windows.Forms.GroupBox ScheduleInfoGroupBox;
        private System.Windows.Forms.DateTimePicker StartTimePicker;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
    }
}