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
    public partial class StudentEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\EnrollmentSystem\Mendez.accdb";
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79866_CC_APPSDEV22_1200_0130_PM_TTH\79866-23241730\Desktop\FINALS\EnrollmentSystem\Mendez.accdb";
        public StudentEntry()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql = "SELECT * FROM STUDENTFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();

            //fixes the no primary key error by setting it up
            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            thisAdapter.Fill(thisDataSet, "StudentFile");

            //check if entry is empty
            bool empty = false;
            foreach (Control ctrl in Controls)
            {
                if (ctrl.Text.Equals("") || ctrl is ComboBox && ctrl.Text.Equals("-Choose-"))
                {
                    empty = true;
                    break;
                }
            }

            DataRow findRow = thisDataSet.Tables["StudentFile"].Rows.Find(IDNumberTextBox.Text);

            if (findRow != null)
                MessageBox.Show("Duplicate Entry!");
            else if (empty)
                MessageBox.Show("Please fill all the fields!");
            else
            {
                DataRow thisRow = thisDataSet.Tables["StudentFile"].NewRow();
                thisRow["STFSTUDID"] = IDNumberTextBox.Text;
                thisRow["STFSTUDFNAME"] = FirstnameTextBox.Text;
                thisRow["STFSTUDMNAME"] = MiddlenameTextBox.Text;
                thisRow["STFSTUDLNAME"] = LastnameTextBox.Text;
                thisRow["STFSTUDCOURSE"] = CourseTextBox.Text;
                thisRow["STFSTUDYEAR"] = YearTextBox.Text;
                thisRow["STFSTUDREMARKS"] = RemarksTextBox.Text;
                thisRow["STFSTUDSTATUS"] = StatusTextBox.Text;

                thisDataSet.Tables["StudentFile"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "StudentFile");

                MessageBox.Show("Entries Recorded");
            }
        }

        private void StudentEntry_Load(object sender, EventArgs e)
        {
            RemarksTextBox.SelectedIndex = 0;
        }
    }
}
