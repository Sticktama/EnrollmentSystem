using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class SubjectScheduleEntry : Form
    {
        public SubjectScheduleEntry()
        {
            InitializeComponent();
        }
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\EnrollmentSystem\Mendez.accdb";

        private void SubjectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false;
                string description = "";

                while (thisDataReader.Read())
                {
                    // MessageBox.Show(thisDataReader["SFSUBJCODE"].ToString());
                    string input = TrimUpper(SubjectCodeTextBox.Text);

                    if (TrimUpper(thisDataReader["SFSUBJCODE"].ToString()) == input)
                    {
                        description = thisDataReader["SFSUBJDESC"].ToString();
                        found = true;
                        //same ra logic sa subject entry
                    }
                }

                int index;

                if (!found)
                    MessageBox.Show("Subject Code Not Found");
                else
                {
                    DescriptionTextBox.Text = description;
                }

                //
            }
        }
        private string TrimUpper(string input)
        {
            return input.Trim().ToUpper();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(MenuForm.connectionString);
            string sql = "SELECT * FROM SUBJECTSCHEDFILE WHERE SSFSTARTTIME >= #1899-12-30# AND SSFSTARTTIME < #1899-12-31#";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();

            //fixes the no primary key error by setting it up
            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            thisAdapter.Fill(thisDataSet, "SubjectSchedFile");

            bool timeError = Convert.ToDateTime(StartTimePicker.Text) >= Convert.ToDateTime(EndTimePicker.Text);
            //check if entry is empty
            bool empty = false;
            foreach (Control ctrl in ScheduleInfoGroupBox.Controls)
            {
                if ((ctrl is TextBox || ctrl is Label) && ctrl.Text.Equals(""))
                {
                    empty = true;
                    break;
                }
            }
            DataRow findRow = thisDataSet.Tables["SubjectSchedFile"].Rows.Find(SubjectEDPCodeTextBox.Text);

            if (findRow != null)
                MessageBox.Show("Duplicate Entry!");
            else if (empty)
                MessageBox.Show("Please fill all the fields!");
            else if (timeError)
                MessageBox.Show("Start Time cannot be greater than End Time!");
            else
            {
                DataRow thisRow = thisDataSet.Tables["SubjectSchedFile"].NewRow();
                thisRow["SSFEDPCODE"] = SubjectEDPCodeTextBox.Text;
                thisRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text;
                thisRow["SSFSTARTTIME"] = StartTimePicker.Text;
                thisRow["SSFENDTIME"] = EndTimePicker.Text;
                thisRow["SSFDAYS"] = DaysTextBox.Text;
                thisRow["SSFROOM"] = RoomTextBox.Text;
                thisRow["SSFSECTION"] = SectionTextBox.Text;
                thisRow["SSFSCHOOLYEAR"] = SchoolYearTextBox.Text;

                thisDataSet.Tables["SubjectSchedFile"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "SubjectSchedFile");

                MessageBox.Show("Entries Recorded");
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox || ctrl is Label)
                {
                    ctrl.Text = "";
                }
                if (ctrl is ComboBox)
                {
                    ComboBox combo = (ComboBox)ctrl;
                    combo.SelectedIndex = 0;
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            Hide();
            menuForm.login = true;
            menuForm.ShowDialog();
            Close();
        }

        private void SubjectScheduleEntry_Load(object sender, EventArgs e)
        {
            MenuForm.currentPos = 2;
            MenuForm.currentForm = this;
            foreach (Control ctrl in Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox combo = (ComboBox)ctrl;
                    combo.SelectedIndex = 0;
                }
            }
        }

        private void JumpPanelButton_Click(object sender, EventArgs e)
        {
            JumpForm jumpForm = new JumpForm();
            jumpForm.ShowDialog();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            Hide();
            //i access the form array and create instance
            MenuForm.currentForm = (Form)Activator.CreateInstance(menuForm.screenTypes[--MenuForm.currentPos]);
            MenuForm.currentForm.ShowDialog();
            Close();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            Hide();
            //i access the form array and create instance
            MenuForm.currentForm = (Form)Activator.CreateInstance(menuForm.screenTypes[++MenuForm.currentPos]);
            MenuForm.currentForm.ShowDialog();
            Close();
        }
    }
}
