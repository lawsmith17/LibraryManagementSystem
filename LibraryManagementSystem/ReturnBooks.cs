﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class ReturnBooks : UserControl
    {

        // creating an SQL connection
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lawrence\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");

        public ReturnBooks()
        {
            InitializeComponent();

            displayIssuedBooksData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void refreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayIssuedBooksData();
        }

        private void returnBooks_returnBtn_Click(object sender, EventArgs e)
        {

            if (returnBooks_issueID.Text == ""
                || returnBooks_name.Text == ""
                || returnBooks_contact.Text == ""
                || returnBooks_email.Text == ""
                || returnBooks_bookTitle.Text == ""
                || returnBooks_author.Text == ""
                || bookIssue_issueDate.Value == null)
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else

            {
                if (connect.State == ConnectionState.Closed)
                {

                    DialogResult check = MessageBox.Show("Are you sure that Issue ID: "
                        + returnBooks_issueID.Text.Trim()
                        + "is return already?", "Confirmation Message", MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question);
                    
                    if(check == DialogResult.Yes)
                    {
                        try
                        {

                            DateTime today = DateTime.Today;

                            connect.Open();

                            String updateData = "update issues set status = @status,date_update = @dateUpdate where issue_id = @issueID";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@status", "Return");
                                cmd.Parameters.AddWithValue("@dateUpdate", today);
                                cmd.Parameters.AddWithValue("@issueID", returnBooks_issueID.Text);

                                cmd.ExecuteNonQuery();

                                displayIssuedBooksData();

                                MessageBox.Show("Returned successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        public void clearFields()
        {
            returnBooks_issueID.Text = "";
            returnBooks_name.Text = "";
            returnBooks_contact.Text = "";
            returnBooks_email.Text = "";
            returnBooks_bookTitle.Text = "";
            returnBooks_author.Text = "";
        }

        //display book data on the gride view
        public void displayIssuedBooksData()
        {
            DataIssueBooks dib = new DataIssueBooks();
            List<DataIssueBooks> listData = dib.ReturnIssueBooksData();

            dataGridView1.DataSource = listData;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                returnBooks_issueID.Text = row.Cells[1].Value.ToString();
                returnBooks_name.Text = row.Cells[2].Value.ToString();
                returnBooks_contact.Text = row.Cells[3].Value.ToString();
                returnBooks_email.Text = row.Cells[4].Value.ToString();
                returnBooks_bookTitle.Text = row.Cells[5].Value.ToString();
                returnBooks_author.Text = row.Cells[6].Value.ToString();
                bookIssue_issueDate.Text = row.Cells[7].Value.ToString();
            }
        }

        // return all controls to default
        private void returnBooks_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
