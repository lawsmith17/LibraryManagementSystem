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
    public partial class DashBoard : UserControl
    {

        // creating an SQL connection
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lawrence\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");

        public DashBoard()
        {
            InitializeComponent();

            displayAB();
            displayIB();
            displayRB();
        }

        public void refreshData()
        {

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayAB();
            displayIB();
            displayRB();
        }

        public void displayAB()
        {
            if(connect.State == ConnectionState.Closed)
            {
                try
                {

                    connect.Open();
                    string selectData = "Select count(id) from books where status = 'Available' and date_delete is null";


                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int tempAB = 0;

                        if(reader.Read())
                        {
                            tempAB = Convert.ToInt32(reader[0]);

                            dashboard_AB.Text = tempAB.ToString();

                        }

                        

                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }finally
                {
                    connect.Close();
                }
            }
        }


        public void displayIB()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {

                    connect.Open();
                    string selectData = "Select count(id) from issues where date_delete is null";


                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int tempIB = 0;

                        if (reader.Read())
                        {
                            tempIB = Convert.ToInt32(reader[0]);

                            dashboard_IB.Text = tempIB.ToString();

                        }




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



        public void displayRB()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {

                    connect.Open();
                    string selectData = "Select count(id) from issues where status = 'Return' and date_delete is null";


                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int tempRB = 0;

                        if (reader.Read())
                        {
                            tempRB = Convert.ToInt32(reader[0]);

                            dashboard_RB.Text = tempRB.ToString();

                        }




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
