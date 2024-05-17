using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class MenuForm : Form
    {
        //home strng
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\EnrollmentSystem\Mendez.accdb";

        //lab string
        //public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79866_CC_APPSDEV22_1200_0130_PM_TTH\79866-23241730\Desktop\FINALS\EnrollmentSystem\Mendez.accdb";

        //dynamically create the form instances para ez jump and next page
        public Type[] screenTypes = new Type[] {
            typeof(SubjectEntry),
            typeof(StudentEntry),
            typeof(SubjectScheduleEntry),
            typeof(StudentEnrollmentEntry)
        };
        static public Form currentForm;
        public static int currentPos;
        int incorrectTimes = 0;
        public bool login = false;
        public MenuForm()
        {
            InitializeComponent();
        }
       

        private void StudentEntryButton_Click(object sender, EventArgs e)
        {
            StudentEntry subjectEntry = new StudentEntry();
            Hide();
            subjectEntry.ShowDialog();
            Close();
        }

        private void SubjectEntryButton_Click(object sender, EventArgs e)
        {
            SubjectEntry subjectEntry = new SubjectEntry();
            Hide();
            subjectEntry.ShowDialog();
            Close();
        }

        private void SubjectScheduleEntryButton_Click(object sender, EventArgs e)
        {
            SubjectScheduleEntry subjectSchedEntry = new SubjectScheduleEntry();
            Hide();
            subjectSchedEntry.ShowDialog();
            Close();
        }

        private void StudentEnrollmentButton_Click(object sender, EventArgs e)
        {
            StudentEnrollmentEntry studentEnrollmentEntry = new StudentEnrollmentEntry();
            Hide();
            studentEnrollmentEntry.ShowDialog();
            Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text.Equals("admin123") && PasswordTextBox.Text.Equals("1234"))
            {
                LoginPanel.Visible = false;
                login = true;
            }
            else if(incorrectTimes > 2)
            {
                MessageBox.Show("You tried to login " + incorrectTimes + "with the wrong credentials!");
            }
            else
            {
                MessageBox.Show("Incorrect Credentials!");
                incorrectTimes++;
            }
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            if (login)
            {
                LoginPanel.Visible = false;
            }
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                LoginButton_Click(sender, e);
        }
    }
}
