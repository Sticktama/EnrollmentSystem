﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EnrollmentSystem
{
    public partial class StudentEnrollmentEntry : Form
    {
        public StudentEnrollmentEntry()
        {
            InitializeComponent();
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


        private void JumpPanelButton_Click(object sender, EventArgs e)
        {
            JumpForm jumpForm = new JumpForm();
            jumpForm.ShowDialog();
        }

        private void IDNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(MenuForm.connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM STUDENTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false;

                string name = "";
                string course = "";
                string year = "";

                while (thisDataReader.Read())
                {
                    if (thisDataReader["STFSTUDID"].ToString().Trim().ToUpper() == IDNumberTextBox.Text.Trim().ToUpper())
                    {
                        found = true;

                        name = thisDataReader["STFSTUDLNAME"].ToString() + ", " +
                               thisDataReader["STFSTUDFNAME"].ToString() + " " +
                               thisDataReader["STFSTUDMNAME"].ToString().Substring(0, 1) + ".";
                        course = thisDataReader["STFSTUDCOURSE"].ToString();
                        year = thisDataReader["STFSTUDYEAR"].ToString();
                        break;

                    }

                }


                if (found == false)
                    MessageBox.Show("ID Number Not Found");
                else
                {
                    NameLabel.Text = name;
                    CourseLabel.Text = course;
                    YearLabel.Text = year;
                }
            }
        }

        private void StudentEnrollmentEntry_Load(object sender, EventArgs e)
        {
            MenuForm.currentPos = 3;
            MenuForm.currentForm = this;

        }
        int totalUnits = 0;

        private void EDPCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string input = TrimUpper(EDPCodeTextBox.Text);
                OleDbConnection thisConnection = new OleDbConnection(MenuForm.connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTSCHEDFILE, SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false; bool duplicate = false;
                string edpCode = "";
                string subjectCode = "";
                string startTime = "";
                string endTime = "";
                string days = "";
                string room = "";
                string units = "";
                bool timeOverlap = false;
                int i = EnrollDataGridView.Rows.Count;

                while (thisDataReader.Read())
                {
                    // MessageBox.Show(thisDataReader["SFSUBJCODE"].ToString());
                    string edpData = i > 0 ? TrimUpper(EnrollDataGridView.Rows[i - 1].Cells
                                            ["EDPCodeColumn"].Value.ToString()) : "";
                    
                    if (input == edpData)
                    {
                        duplicate = true;
                        break;
                    }

                    if (TrimUpper(thisDataReader["SSFEDPCODE"].ToString()) == input)
                    {
                        edpCode = TrimUpper(thisDataReader["SSFEDPCODE"].ToString());
                        subjectCode = TrimUpper(thisDataReader["SFSUBJDESC"].ToString());
                        startTime = TrimUpper(thisDataReader["SSFSTARTTIME"].ToString());
                        endTime = TrimUpper(thisDataReader["SSFENDTIME"].ToString());
                        days = TrimUpper(thisDataReader["SSFDAYS"].ToString());
                        room = TrimUpper(thisDataReader["SSFROOM"].ToString());
                        units = TrimUpper(thisDataReader["SFSUBJUNITS"].ToString());

                        found = true;
                        //  
                    }
                    DateTime startTimeData = i > 0 ? Convert.ToDateTime(EnrollDataGridView.Rows[i - 1].Cells
                                            ["StartTimeColumn"].Value.ToString()) : DateTime.MinValue;
                    DateTime endTimeData = i > 0 ? Convert.ToDateTime(EnrollDataGridView.Rows[i - 1].Cells
                                            ["EndTimeColumn"].Value.ToString()) : DateTime.MinValue;

                    if (i > 0 && (startTimeData < Convert.ToDateTime(thisDataReader["SSFENDTIME"]) ||
                        endTimeData > Convert.ToDateTime(thisDataReader["SSFSTARTTIME"])))
                        timeOverlap = true;
                    
                    i--;
                }

                int index;
                if (!found)
                    MessageBox.Show("Subject Code Not Found");
                else if (duplicate)
                    MessageBox.Show("Subject Code Already Exists!");
                else if (timeOverlap)
                    MessageBox.Show("Schedule Conflict!");
                else if (totalUnits > 21)
                    MessageBox.Show("Total Units cannot exceed beyond 21");
                else
                {
                    index = EnrollDataGridView.Rows.Add();
                    EnrollDataGridView.Rows[index].Cells["EDPCodeColumn"].Value = edpCode;
                    EnrollDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    EnrollDataGridView.Rows[index].Cells["StartTimeColumn"].Value = startTime;
                    EnrollDataGridView.Rows[index].Cells["EndTimeColumn"].Value = endTime;
                    EnrollDataGridView.Rows[index].Cells["DaysColumn"].Value = days;
                    EnrollDataGridView.Rows[index].Cells["RoomColumn"].Value = room;
                    EnrollDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;

                }
                totalUnits += Int32.Parse(units);
            }
        }

        private string TrimUpper(string input)
        {
            return input.Trim().ToUpper();
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox||ctrl is Label)
                {
                    ctrl.Text = "";
                }
                if (ctrl is DateTimePicker)
                {
                    DateTimePicker date = (DateTimePicker)ctrl;
                    date.Value = DateTime.Now;
                }

            }
            EnrollDataGridView.Rows.Clear();
            TotalUnitsLabel.Text = "";
            EncoderTextBox.Text = "";
        }

        private void EnrollDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            EnrollDataGridView.ClearSelection();
        }
    }
}
