using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{

    public partial class SubjectEntry : Form
    {
        bool empty = false;
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public SubjectEntry()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(MenuForm.connectionString);
            string sql = "SELECT * FROM SUBJECTFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();

            //fixes the no primary key error by setting it up
            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            thisAdapter.Fill(thisDataSet, "SubjectFile");

            empty = false;
            //check if entry is empty
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
                thisRow["SFSUBJUNITS"] = Convert.ToUInt16(UnitsComboBox.Text);
                thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 3);
                thisRow["SFSUBJREGOFRNG"] = Convert.ToUInt16(OfferingComboBox.Text.Substring(0, 1));
                thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text.Substring(0, 4);
                thisRow["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

                thisDataSet.Tables["SubjectFile"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "SubjectFile");

                //*****************   TODO: Save DATA TO SUBJPREQFILE **********************************
                OleDbConnection requisiteConnection = new OleDbConnection(MenuForm.connectionString);
                string requisite = "SELECT * FROM SUBJECTPREQFILE";
                OleDbDataAdapter requisiteAdapter = new OleDbDataAdapter(requisite, requisiteConnection);
                OleDbCommandBuilder requisiteBuilder = new OleDbCommandBuilder(requisiteAdapter);

                thisDataSet = new DataSet();

                requisiteAdapter.Fill(thisDataSet, "SubjectPreqFile");
                //setup primary key
                DataColumn[] keys = new DataColumn[2];// DataColumn array is named keys
                                                      //assign the first element of the keys array, keys[0] to the ProductID column in Product table. 
                keys[0] = thisDataSet.Tables["SubjectPreqFile"].Columns["SUBJCODE"];
                keys[1] = thisDataSet.Tables["SubjectPreqFile"].Columns["SUBJPRECODE"];


                // assign the array keys to the PrimaryKey property of the OrderDetails DataTable object.
                thisDataSet.Tables["SubjectPreqFile"].PrimaryKey = keys;
                

                // values to be searched
                string[] valuesToSearch = new string[2];
                valuesToSearch[0] = SubjectCodeTextBox.Text;
                valuesToSearch[1] = RequisiteTextBox.Text;

                DataRow findRequisiteRow = thisDataSet.Tables["SubjectPreqFile"].Rows.Find(valuesToSearch);
                if (findRequisiteRow == null)
                {
                    MessageBox.Show(SubjectDataGridView.Rows.Count + "");
                    
                    DataRow thisRequisiteRow = thisDataSet.Tables["SubjectPreqFile"].NewRow();
                    string copre = SubjectDataGridView.Rows[0].Cells["CoPreRequisiteColumn"].Value.ToString();
                    thisRequisiteRow["SUBJCODE"] = TrimUpper(SubjectCodeTextBox.Text);
                    thisRequisiteRow["SUBJPRECODE"] = TrimUpper(copre).Remove(copre.Length-5);
                    thisRequisiteRow["SUBJCATEGORY"] = TrimUpper(copre).Substring(copre.Length - 3, 2);

                    thisDataSet.Tables["SubjectPreqFile"].Rows.Add(thisRequisiteRow);


                    requisiteAdapter.Update(thisDataSet, "SubjectPreqFile");
                    MessageBox.Show("Entries Recorded");
                }
                else
                {
                    MessageBox.Show("Duplicate Entry!");
                }

                
            }   
        }
    

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(MenuForm.connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                empty = false;
                foreach (Control ctrl in SubjectInfoGroupBox.Controls)
                {
                    if (ctrl.Text.Equals("") || ctrl is ComboBox && ctrl.Text.Equals("-Choose-"))
                    {
                        empty = true;
                        break;
                    }
                }

                bool found = false, duplicate = false;
                string subjectCode = "";
                string description = "";
                string units = "";
                string copre = "";
                string data = "";
                string category = PreRequisiteRadioButton.Checked ? "PR" : "CR";
                //int i = SubjectDataGridView.Rows.Count;
                while (thisDataReader.Read())
                {
                    // MessageBox.Show(thisDataReader["SFSUBJCODE"].ToString());
                    string input = TrimUpper(RequisiteTextBox.Text);
                    /*
                    * para error trapping unta nis for loop system na mu insert every data grid row
                    * pero i deemed it infeasible kay since bawal duplicate ang primary key 
                    * there's a possible bypass, pero hugaw na sya sa access database
                    * so gi 1 requisite entry per subject nalang nko
                    * 
                    data = i > 0 ? TrimUpper(SubjectDataGridView.Rows[i - 1].Cells
                                            ["CoPreRequisiteColumn"].Value.ToString()) : "";

                    string tableData = i > 0 ? data.Remove(data.Length - 5) : "";
                    if (input == tableData)
                    {
                        duplicate = true;
                        break;
                    }
                    */
                    if (TrimUpper(thisDataReader["SFSUBJCODE"].ToString()) == input)
                    { 
                        subjectCode = TrimUpper(SubjectCodeTextBox.Text);
                        description = TrimUpper(DescriptionTextBox.Text);
                        units = UnitsComboBox.Text;

                        copre = RequisiteTextBox.Text + $" ({category})";
                        found = true;
                        
                    }
                    //i--;
                }

                int index;
                if (empty)
                {
                    MessageBox.Show("Please fill all the fields in Subject Information first!");
                }
                /*
                  
                else if (duplicate)
                    MessageBox.Show("Subject already added as " + data.Substring(data.Length - 3, 2) + "!");
                */
                else if (!found)
                    MessageBox.Show("Subject Code Not Found");
                else
                {
                    index = SubjectDataGridView.Rows.Add();
                    SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = description;
                    SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;
                    SubjectDataGridView.Rows[index].Cells["CoPreRequisiteColumn"].Value = copre;
                    SubjectInfoGroupBox.Enabled = false;
                    RequisiteTextBox.Enabled = false;
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
            SubjectInfoGroupBox.Enabled = true;
            RequisiteTextBox.Enabled = true;

        }

        private void SubjectEntry_Load(object sender, EventArgs e)
        {
            MenuForm.currentPos = 0;
            MenuForm.currentForm = this;
            foreach (Control ctrl in SubjectInfoGroupBox.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox combo = (ComboBox)ctrl;
                    combo.SelectedIndex = 0;
                }
            }

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

        private void JumpButton_Click(object sender, EventArgs e)
        {
            JumpForm jumpForm = new JumpForm();
            jumpForm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            Hide();
            menuForm.login = true;
            menuForm.ShowDialog();
            Close();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            Hide();
            menuForm.login = true;
            menuForm.ShowDialog();
            Close();
        }
        private void SubjectDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            SubjectDataGridView.ClearSelection();
        }
    }
}
