using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
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
            thisAdapter.Fill(thisDataSet, "SubjectFile");

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

            //mag insert pa code here

            MessageBox.Show("Entries Recorded");
        }

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTFILE, SUBJECTPREQFILE, SUBJECTCOREQFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false, duplicate = false;
                string subjectCode = "";
                string description = "";
                string units = "";
                string copre = "";
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
                            
                            found = true;
                            subjectCode = thisDataReader["SFSUBJCODE"].ToString();
                            description = thisDataReader["SFSUBJDESC"].ToString();
                            units = thisDataReader["SFSUBJUNITS"].ToString();

                            if(subjectCode == thisDataReader["SUBJECTPREQFILE.SUBJCODE"].ToString() && PreRequisiteRadioButton.Checked)
                                copre = thisDataReader["SUBJPRECODE"].ToString();
                            else if (subjectCode == thisDataReader["SUBJECTCOREQFILE.SUBJCODE"].ToString() && CoRequisiteRadioButton.Checked)
                                copre = thisDataReader["SUBJCOCODE"].ToString();

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
            Control[] clear = { SubjectCodeTextBox, DescriptionTextBox, UnitsTextBox,
                                OfferingComboBox, CategoryComboBox, CourseCodeComboBox,
                                CurriculumYearTextBox};
            for (int x = 0; x < clear.Length; x++)
            {
                clear[x].Text = "";
            }
        }
    }
}
