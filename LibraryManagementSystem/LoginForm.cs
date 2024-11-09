using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class LoginForm : Form
    {

        //Creating an SQLConnetion
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lawrence\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                //show an eror message when no data is placed in the textboxs
                MessageBox.Show("Please fill all blank fields ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        // opening SQL Connetion
                        connect.Open();

                        String selectData = "select * from users where username = @username and password = @password";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());

                            // checking if data matchs
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if(table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Login Successful", "Information  Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                MainFrom mFrom = new MainFrom();
                                mFrom.Show();
                                this.Hide();
                            }
                            else
                            {
                                //show incorrect Username or password message box
                                MessageBox.Show("Incorrect Username or password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        }
                    catch (Exception ex)
                    {
                        //show the connection to database has failed messageBox
                        MessageBox.Show("Error connecting to DataBase: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
               


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {

            //  when user clicks button we move to the register from

            RegisterForm rForm = new RegisterForm();
            rForm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';

        }
    }
}
