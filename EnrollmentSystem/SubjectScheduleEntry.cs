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
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79866_CC_APPSDEV22_1200_0130_PM_TTH\79866-23241730\Desktop\FINALS\EnrollmentSystem\Mendez.accdb";
        private void SubjectScheduleEntry_Load(object sender, EventArgs e)
        {

        }

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
                       
                        //  
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
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql = "SELECT * FROM SUBJECTSCHEDFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "SubjectSchedFile");

            DataRow thisRow = thisDataSet.Tables["SubjectSchedFile"].NewRow();
            thisRow["SSFEDPCODE"] = SubjectEDPCodeTextBox.Text;
            thisRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text;
            thisRow["SSFSTARTTIME"] = Convert.ToDateTime(TimeStartTextBox);
            thisRow["SSFENDTIME"] = Convert.ToDateTime(TimeEndTextBox);
            thisRow["SSFDAYS"] = DaysTextBox.Text;
            thisRow["SSFROOM"] = RoomTextBox.Text;
            thisRow["SSFXM"] = AmPmTextBox.Text;
            thisRow["SSFSECTION"] = SectionTextBox.Text;
            thisRow["SSFMAXSIZE"] = SchoolYearTextBox.Text;

            thisDataSet.Tables["SubjectSchedFile"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataSet, "SubjectSchedFile");

            //mag insert pa code here

            MessageBox.Show("Entries Recorded");
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {

        }
    }
}
