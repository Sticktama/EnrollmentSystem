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
    }
}
