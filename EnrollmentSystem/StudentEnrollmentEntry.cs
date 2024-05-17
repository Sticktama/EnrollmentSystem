using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
                string input = EDPCodeTextBox.Text;
                OleDbConnection thisConnection = new OleDbConnection(MenuForm.connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTSCHEDFILE, SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false; bool duplicate = false, sameDay = false;
                string edpCode = "";
                string subjectCode = "";
                string startTime = "";
                string endTime = "";
                string days = "";
                string room = "";
                int units = 0;
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

                    if (thisDataReader["SSFEDPCODE"].ToString() == input)
                    {
                        edpCode = TrimUpper(thisDataReader["SSFEDPCODE"].ToString());
                        subjectCode = TrimUpper(thisDataReader["SSFSUBJCODE"].ToString());
                        startTime = TrimUpper(thisDataReader["SSFSTARTTIME"].ToString());
                        endTime = TrimUpper(thisDataReader["SSFENDTIME"].ToString());
                        days = TrimUpper(thisDataReader["SSFDAYS"].ToString());
                        room = TrimUpper(thisDataReader["SSFROOM"].ToString());

                        if(thisDataReader["SFSUBJCODE"].ToString() == thisDataReader["SSFSUBJCODE"].ToString())
                            units = Convert.ToInt16(thisDataReader["SFSUBJUNITS"]);

                        found = true;
                        //  
                    }
                    DateTime startTimeData = i > 0 ? Convert.ToDateTime(EnrollDataGridView.Rows[i - 1].Cells
                                            ["StartTimeColumn"].Value.ToString()) : System.DateTime.MinValue;
                    DateTime endTimeData = i > 0 ? Convert.ToDateTime(EnrollDataGridView.Rows[i - 1].Cells
                                            ["EndTimeColumn"].Value.ToString()) : System.DateTime.MinValue;
                    string daysData = i > 0 ? TrimUpper(EnrollDataGridView.Rows[i - 1].Cells
                                            ["DaysColumn"].Value.ToString()) : "";
                    //gi brute force method nko to extract time value
                    //MessageBox.Show(startTime.ToString().Substring(10, 5) + " " + startTime.ToString().Substring(19, 2));
                    for (int x = 0; x < daysData.Length; x++)
                    {
                        for(int y = 0; y < days.Length; y++)
                        {
                            
                            if (daysData.Contains("TH") && days.Contains("TH") ||
                                !(daysData.Contains("TH") && days.Contains("TH")) &&
                                daysData[x].ToString().Contains(days[y].ToString()))
                            {
                                sameDay = true;
                                break;
                            }
                        }
                    }

                    


                    if (i > 0 && startTimeData < Convert.ToDateTime(thisDataReader["SSFENDTIME"]) &&
                        endTimeData > Convert.ToDateTime(thisDataReader["SSFSTARTTIME"]))
                        timeOverlap = true;

                    
                    i--;
                }

                int index;
                if (duplicate)
                    MessageBox.Show("Subject Code Already Exists!");
                else if (!found)
                    MessageBox.Show("Subject Code Not Found");
                else if (timeOverlap)
                    MessageBox.Show("Schedule Conflict!");
                else if (totalUnits > 21)
                    MessageBox.Show("Total Units cannot exceed beyond 21");
                else
                {
                    index = EnrollDataGridView.Rows.Add();
                    EnrollDataGridView.Rows[index].Cells["EDPCodeColumn"].Value = edpCode;
                    EnrollDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    EnrollDataGridView.Rows[index].Cells["StartTimeColumn"].Value = startTime.ToString().Substring(10, startTime.Length - 10);
                    EnrollDataGridView.Rows[index].Cells["EndTimeColumn"].Value = endTime.ToString().Substring(10, endTime.Length - 10);
                    EnrollDataGridView.Rows[index].Cells["DaysColumn"].Value = days;
                    EnrollDataGridView.Rows[index].Cells["RoomColumn"].Value = room;
                    EnrollDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;

                }
                totalUnits += units;
                TotalUnitsLabel.Text = totalUnits.ToString();
            }
        }

        private string TrimUpper(string input)
        {
            return input.Trim().ToUpper();
        }

        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(MenuForm.connectionString);
            string sql = "SELECT * FROM ENROLLMENTHEADERFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();

            //fixes the no primary key error by setting it up
            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            thisAdapter.Fill(thisDataSet, "EnrollmentHeaderFile");

            bool empty = false;
            //check if entry is empty
            foreach (Control ctrl in EnrolleeInfoGroupBox.Controls)
            {
                if (ctrl.Text.Equals("") && (ctrl is TextBox || ctrl is ComboBox))
                {
                    empty = true;
                    break;
                }
            }
            if(EnrollDataGridView.Rows.Count > 0 && EncoderTextBox.Text == "")
            {
                empty = true;
            }


            DataRow findRow = thisDataSet.Tables["EnrollmentHeaderFile"].Rows.Find(EDPCodeTextBox.Text);

            if (findRow != null)
                MessageBox.Show("Duplicate Entry!");
            else if (empty)
                MessageBox.Show("Please fill all the fields!");
            else
            {
                DataRow thisRow = thisDataSet.Tables["EnrollmentHeaderFile"].NewRow();
                thisRow["ENRHFSTUDID"] = IDNumberTextBox.Text;
                thisRow["ENRHFSTUDDATEENROLL"] = DateEnrolledPicker.Text;
                thisRow["ENRHFSTUDSCHLYR"] = YearLabel.Text;
                thisRow["ENRHFSTUDENCODER"] = EncoderTextBox.Text;
                thisRow["ENRHFSTUDTOTALUNITS"] = TotalUnitsLabel.Text;

                thisDataSet.Tables["EnrollmentHeaderFile"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "EnrollmentHeaderFile");

                //*****************   TODO: Save DATA TO ENROLLMENTDETAILFILE **********************************
                OleDbConnection enrollmentConnection = new OleDbConnection(MenuForm.connectionString);
                string enrollment = "SELECT * FROM ENROLLMENTDETAILFILE";
                OleDbDataAdapter enrollmentAdapter = new OleDbDataAdapter(enrollment, enrollmentConnection);
                OleDbCommandBuilder enrollmentBuilder = new OleDbCommandBuilder(enrollmentAdapter);

                thisDataSet = new DataSet();

                enrollmentAdapter.Fill(thisDataSet, "EnrollmentDetailFile");
                //setup primary key
                DataColumn[] keys = new DataColumn[2];// DataColumn array is named keys
                                                      //assign the first element of the keys array, keys[0] to the ProductID column in Product table. 
                keys[0] = thisDataSet.Tables["EnrollmentDetailFile"].Columns["ENRDFSTUDID"];
                keys[1] = thisDataSet.Tables["EnrollmentDetailFile"].Columns["ENRDFSTUDEDPCODE"];


                // assign the array keys to the PrimaryKey property of the OrderDetails DataTable object.
                thisDataSet.Tables["EnrollmentDetailFile"].PrimaryKey = keys;


                // values to be searched
                string[] valuesToSearch = new string[2];
                valuesToSearch[0] = IDNumberTextBox.Text;
                valuesToSearch[1] = EDPCodeTextBox.Text;

                DataRow findRequisiteRow = thisDataSet.Tables["EnrollmentDetailFile"].Rows.Find(valuesToSearch);
                if (findRequisiteRow == null)
                {
                    if (EnrollDataGridView.Rows.Count > 0)
                    {
                        for (int i = 0; i < EnrollDataGridView.Rows.Count; i++)
                        {
                            DataRow thisRequisiteRow = thisDataSet.Tables["EnrollmentDetailFile"].NewRow();
                            string data = EnrollDataGridView.Rows[i].Cells["SubjectCodeColumn"].Value.ToString();
                            thisRequisiteRow["ENRDFSTUDEDPCODE"] = TrimUpper(EDPCodeTextBox.Text);
                            thisRequisiteRow["ENRDFSTUDID"] = IDNumberTextBox.Text;
                            thisRequisiteRow["ENRDFSTUDSUBJCDE"] = data;

                            thisDataSet.Tables["EnrollmentDetailFile"].Rows.Add(thisRequisiteRow);

                            enrollmentAdapter.Update(thisDataSet, "EnrollmentDetailFile");
                        }
                        MessageBox.Show("Entries Recorded");
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate Entry!");
                }
            }
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
                    date.Value = System.DateTime.Now;
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

        private void TotalUnitsLabel_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
