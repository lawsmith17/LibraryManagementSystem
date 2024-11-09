using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //code for when the user clicks the logout buttons
        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashBoard1.Visible = true;
            addBooks1.Visible= false;
            returnBooks1.Visible = false;
            issuedBooks1.Visible = false;

            DashBoard aForm = dashBoard1 as DashBoard;
            if (aForm != null)
            {
                aForm.refreshData();
            }
        }

        private void addbooks_btn_Click(object sender, EventArgs e)
        {
            dashBoard1.Visible = false;
            addBooks1.Visible = true;
            returnBooks1.Visible = false;
            issuedBooks1.Visible = false;

            AddBooks aForm = addBooks1 as AddBooks;
            if (aForm != null)
            {
                aForm.refreshData();
            }
        }

        private void issuebooks_btn_Click(object sender, EventArgs e)
        {
            dashBoard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = false;
            issuedBooks1.Visible = true;

            ReturnBooks rForm = returnBooks1 as ReturnBooks;
            if (rForm != null)
            {
                rForm.refreshData();
            }
        }

        private void returnBooks_btn_Click(object sender, EventArgs e)
        {
            dashBoard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = true;
            issuedBooks1.Visible = false;

            IssuedBooks iForm = issuedBooks1 as IssuedBooks;
            if (iForm != null)
            {
                iForm.refreshData();
            }
        }
    }
}
