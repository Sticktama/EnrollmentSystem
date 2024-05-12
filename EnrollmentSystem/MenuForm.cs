using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            StudentEntry studentEntry = new StudentEntry();
            
            studentEntry.Show();
            
        }

        private void SubjectEntryButton_Click(object sender, EventArgs e)
        {
            SubjectEntry subjectEntry = new SubjectEntry();
            subjectEntry.Show();
        }

        private void SubjectScheduleEntryButton_Click(object sender, EventArgs e)
        {
            SubjectScheduleEntry subjectSchedEntry = new SubjectScheduleEntry();
            subjectSchedEntry.Show();
        }

        private void StudentEnrollmentButton_Click(object sender, EventArgs e)
        {
            StudentEnrollmentEntry studentEnrollmentEntry = new StudentEnrollmentEntry();
            studentEnrollmentEntry.Show();
        }
    }
}
