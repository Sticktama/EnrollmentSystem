using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{

    public partial class SubjectEntry : Form
    {

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public SubjectEntry()
        {
            InitializeComponent();
        }
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\EnrollmentSystem\Mendez.accdb";
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79866_CC_APPSDEV22_1200_0130_PM_TTH\79866-23241730\Desktop\FINALS\EnrollmentSystem\Mendez.accdb";

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql = "SELECT * FROM SUBJECTFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();

            //fixes the no primary key error by setting it up
            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            thisAdapter.Fill(thisDataSet, "SubjectFile");

            //check if entry is empty
            bool empty = false;
            foreach (Control ctrl in SubjectInfoGroupBox.Controls)
            {
                if (ctrl.Text.Equals("") || ctrl is ComboBox && ctrl.Text.Equals("-Choose-"))
                {
                    empty = true;
                    break;
                }
            }

            DataRow findRow = thisDataSet.Tables["SubjectFile"].Rows.Find(SubjectCodeTextBox.Text);

            if (findRow != null)
                MessageBox.Show("Duplicate Entry!");
            else if (empty)
                MessageBox.Show("Please fill all the fields!");
            else
            {
                DataRow thisRow = thisDataSet.Tables["SubjectFile"].NewRow();
                thisRow["SFSUBJCODE"] = SubjectCodeTextBox.Text;
                thisRow["SFSUBJDESC"] = DescriptionTextBox.Text;
                thisRow["SFSUBJUNITS"] = Convert.ToUInt16(UnitsTextBox.Text);
                thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 3);
                thisRow["SFSUBJREGOFRNG"] = Convert.ToUInt16(OfferingComboBox.Text.Substring(0, 1));
                thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text.Substring(0, 4);
                thisRow["SFSUBJCURRYEAR"] = CurriculumYearTextBox.Text;

                thisDataSet.Tables["SubjectFile"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "SubjectFile");

                MessageBox.Show("Entries Recorded");
            }   
        }
    

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTFILE, SUBJECTPREQFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false, duplicate = false;
                string subjectCode = "";
                string description = "";
                string units = "";
                string copre = "";
                string category = PreRequisiteRadioButton.Checked ? "PR" : "CR";
                int i = SubjectDataGridView.Rows.Count;
                while (thisDataReader.Read())
                {
                    // MessageBox.Show(thisDataReader["SFSUBJCODE"].ToString());
                    string input = TrimUpper(RequisiteTextBox.Text);

                    string tableData = i > 0 ? TrimUpper(SubjectDataGridView.Rows[i - 1].Cells
                                            ["SubjectCodeColumn"].Value.ToString()) : "";
                    if (input == tableData)
                    {
                        duplicate = true;
                        break;
                    }
                    if (TrimUpper(thisDataReader["SFSUBJCODE"].ToString()) == input)
                    { 
                        subjectCode = thisDataReader["SFSUBJCODE"].ToString();
                        description = thisDataReader["SFSUBJDESC"].ToString();
                        units = thisDataReader["SFSUBJUNITS"].ToString();

                        if (subjectCode == thisDataReader["SUBJCODE"].ToString() && 
                            category == thisDataReader["SUBJCATEGORY"].ToString())
                        {
                            copre = thisDataReader["SUBJPRECODE"].ToString() + $" ({category})";
                            found = true;
                        }
                        //  
                    }
                    i--;
                }

                int index;
                if (duplicate)
                    MessageBox.Show("Subject Code Already Added!");
                else if (!found)
                    MessageBox.Show("Subject Code Not Found");
                else
                {
                    index = SubjectDataGridView.Rows.Add();
                    SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = description;
                    SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;
                    SubjectDataGridView.Rows[index].Cells["CoPreRequisiteColumn"].Value = copre;
                }

                //
            }
        }
        private string TrimUpper(string input)
        {
            return input.Trim().ToUpper();
        }

        private void myDataGridView_SelectionChanged(Object sender, EventArgs e)
        {
            SubjectDataGridView.ClearSelection();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in SubjectInfoGroupBox.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
                if (ctrl is ComboBox)
                {
                    ComboBox combo = (ComboBox)ctrl;
                    combo.SelectedIndex = 0;
                }
            }
            RequisiteTextBox.Text = "";
            PreRequisiteRadioButton.Checked = true;
            SubjectDataGridView.Rows.Clear();
            
        }

        private void SubjectEntry_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in SubjectInfoGroupBox.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox combo = (ComboBox)ctrl;
                    combo.SelectedIndex = 0;
                }
            }
        }
    }
}
