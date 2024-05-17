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
        public StudentEntry()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            Hide();
            menuForm.login = true;
            menuForm.ShowDialog();
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(MenuForm.connectionString);
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
                if (ctrl.Text.Equals("") && ctrl is TextBox || ctrl is ComboBox && ctrl.Text.Equals("-Choose-"))
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
                thisRow["STFSTUDCOURSE"] = CourseComboBox.Text;
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
            MenuForm.currentPos = 1;
            MenuForm.currentForm = this;
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

        private void HomeButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            Hide();
            menuForm.login = true;
            menuForm.ShowDialog();
            Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in StudentInfoGroupBox.Controls)
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
        }
    }
}
