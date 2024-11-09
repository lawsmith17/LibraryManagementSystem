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
    public partial class RegisterForm : Form
    {

        //Creating an SQLConnetion
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lawrence\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void signin_btn_Click(object sender, EventArgs e)
        {
            // when the signin button is pressed return User to the login Form

            LoginForm IForm = new LoginForm();
            IForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // this method if for when the user clicks the register button
        private void register_btn_Click(object sender, EventArgs e)
        {

            if(register_email.Text == "" || register_username.Text == "" || register_password.Text=="")
            {
                //show an eror message when no data is placed in the textboxs
                MessageBox.Show("Please fill all blank fields ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
if(connect.State != ConnectionState.Open)
                {
                    try
                    {
                        // opening SQL Connetion
                        connect.Open();


                        //checking if they are duplicate usernames
                        String checkUsername = "SELECT COUNT(*) FROM users WHERE username = @username";

                        using (SqlCommand checkCMD = new SqlCommand(checkUsername, connect))
                        {
                            checkCMD.Parameters.AddWithValue("@username", register_username.Text.Trim());
                            int count = (int)checkCMD.ExecuteScalar();


                            if(count >= 1)
                            {
                                // Show Error Message
                                MessageBox.Show(register_username.Text.Trim() + "is already taken ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                //To get the date today
                                DateTime day = DateTime.Today;
                                String insertData = "insert into users (email,username,password,date_register)" + "VALUES(@email,@username,@password,@date)";

                                //saving data to database
                                using (SqlCommand insertCMD = new SqlCommand(insertData, connect))
                                {
                                    insertCMD.Parameters.AddWithValue("@email", register_email.Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@username", register_username.Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@password", register_password.Text.Trim());
                                    insertCMD.Parameters.AddWithValue("@date", day.ToString());


                                    insertCMD.ExecuteNonQuery();

                                    MessageBox.Show("Register Successfuly!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    LoginForm lForm = new LoginForm();
                                    lForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                        
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Error connecting to DataBase: "+ ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
           
        }

        private void register_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            // checking if the show password radio button is checked or not
            register_password.PasswordChar = register_showpassword.Checked ? '\0' : '*';
        }
    }
}
