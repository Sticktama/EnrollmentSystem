namespace EnrollmentSystem
{
    partial class MenuForm
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
            this.StudentEnrollmentButton = new System.Windows.Forms.Button();
            this.StudentEntryButton = new System.Windows.Forms.Button();
            this.SubjectScheduleEntryButton = new System.Windows.Forms.Button();
            this.SubjectEntryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StudentEnrollmentButton
            // 
            this.StudentEnrollmentButton.Location = new System.Drawing.Point(45, 309);
            this.StudentEnrollmentButton.Name = "StudentEnrollmentButton";
            this.StudentEnrollmentButton.Size = new System.Drawing.Size(346, 76);
            this.StudentEnrollmentButton.TabIndex = 0;
            this.StudentEnrollmentButton.Text = "Student Enrollment";
            this.StudentEnrollmentButton.UseVisualStyleBackColor = true;
            this.StudentEnrollmentButton.Click += new System.EventHandler(this.StudentEnrollmentButton_Click);
            // 
            // StudentEntryButton
            // 
            this.StudentEntryButton.Location = new System.Drawing.Point(45, 31);
            this.StudentEntryButton.Name = "StudentEntryButton";
            this.StudentEntryButton.Size = new System.Drawing.Size(346, 76);
            this.StudentEntryButton.TabIndex = 1;
            this.StudentEntryButton.Text = "Student Entry";
            this.StudentEntryButton.UseVisualStyleBackColor = true;
            this.StudentEntryButton.Click += new System.EventHandler(this.StudentEntryButton_Click);
            // 
            // SubjectScheduleEntryButton
            // 
            this.SubjectScheduleEntryButton.Location = new System.Drawing.Point(45, 217);
            this.SubjectScheduleEntryButton.Name = "SubjectScheduleEntryButton";
            this.SubjectScheduleEntryButton.Size = new System.Drawing.Size(346, 76);
            this.SubjectScheduleEntryButton.TabIndex = 2;
            this.SubjectScheduleEntryButton.Text = "Student Schedule Entry";
            this.SubjectScheduleEntryButton.UseVisualStyleBackColor = true;
            this.SubjectScheduleEntryButton.Click += new System.EventHandler(this.SubjectScheduleEntryButton_Click);
            // 
            // SubjectEntryButton
            // 
            this.SubjectEntryButton.Location = new System.Drawing.Point(45, 124);
            this.SubjectEntryButton.Name = "SubjectEntryButton";
            this.SubjectEntryButton.Size = new System.Drawing.Size(346, 76);
            this.SubjectEntryButton.TabIndex = 3;
            this.SubjectEntryButton.Text = "Subject Entry";
            this.SubjectEntryButton.UseVisualStyleBackColor = true;
            this.SubjectEntryButton.Click += new System.EventHandler(this.SubjectEntryButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 428);
            this.Controls.Add(this.SubjectEntryButton);
            this.Controls.Add(this.SubjectScheduleEntryButton);
            this.Controls.Add(this.StudentEntryButton);
            this.Controls.Add(this.StudentEnrollmentButton);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StudentEnrollmentButton;
        private System.Windows.Forms.Button StudentEntryButton;
        private System.Windows.Forms.Button SubjectScheduleEntryButton;
        private System.Windows.Forms.Button SubjectEntryButton;
    }
}