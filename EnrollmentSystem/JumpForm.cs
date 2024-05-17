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
    public partial class JumpForm : Form
    {
        MenuForm menuForm = new MenuForm();
        public JumpForm()
        {
            InitializeComponent();
        }

        private void JumpButton_Click(object sender, EventArgs e)
        {
            
            int jumpPage = Convert.ToInt32(JumpTextBox.Text);
            if (!jumpPage.Equals(MenuForm.currentPos+1))
            {
                Hide();
                MenuForm.currentForm.Hide();
                MenuForm.currentForm.Close();
                //i access the form array and create instance
                MenuForm.currentForm = (Form)Activator.CreateInstance(menuForm.screenTypes[jumpPage-1]);
                MenuForm.currentPos = jumpPage-1;
                MenuForm.currentForm.ShowDialog();
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JumpForm_Load(object sender, EventArgs e)
        {
            JumpTextBox.Text = (MenuForm.currentPos + 1).ToString();
        }

        private void JumpTextBox_TextChanged(object sender, EventArgs e)
        {
            int page = int.TryParse(JumpTextBox.Text.ToString(), out int n) ? Convert.ToInt32(JumpTextBox.Text) : -1;
            if(page > 4)
            {
                JumpTextBox.Text = "4";
            }
            else if (page < 0)
            {
                JumpTextBox.Text = "1";
            }
        }

        private void JumpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                JumpButton_Click(sender, e);
            }
        }
    }
}
