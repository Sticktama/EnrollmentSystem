namespace EnrollmentSystem
{
    partial class JumpForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.JumpTextBox = new System.Windows.Forms.TextBox();
            this.JumpButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(33, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 26);
            this.label10.TabIndex = 22;
            this.label10.Text = "Jump to Page";
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Teal;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(95, 6);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(77, 28);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // JumpTextBox
            // 
            this.JumpTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JumpTextBox.Location = new System.Drawing.Point(83, 43);
            this.JumpTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.JumpTextBox.Name = "JumpTextBox";
            this.JumpTextBox.Size = new System.Drawing.Size(19, 26);
            this.JumpTextBox.TabIndex = 19;
            this.JumpTextBox.TextChanged += new System.EventHandler(this.JumpTextBox_TextChanged);
            this.JumpTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JumpTextBox_KeyPress);
            // 
            // JumpButton
            // 
            this.JumpButton.BackColor = System.Drawing.Color.Teal;
            this.JumpButton.FlatAppearance.BorderSize = 0;
            this.JumpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JumpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JumpButton.ForeColor = System.Drawing.Color.White;
            this.JumpButton.Location = new System.Drawing.Point(11, 6);
            this.JumpButton.Margin = new System.Windows.Forms.Padding(4);
            this.JumpButton.Name = "JumpButton";
            this.JumpButton.Size = new System.Drawing.Size(77, 28);
            this.JumpButton.TabIndex = 20;
            this.JumpButton.Text = "Jump";
            this.JumpButton.UseVisualStyleBackColor = false;
            this.JumpButton.Click += new System.EventHandler(this.JumpButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.JumpButton);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 39);
            this.panel1.TabIndex = 23;
            // 
            // JumpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(182, 115);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.JumpTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JumpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.Load += new System.EventHandler(this.JumpForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox JumpTextBox;
        private System.Windows.Forms.Button JumpButton;
        private System.Windows.Forms.Panel panel1;
    }
}