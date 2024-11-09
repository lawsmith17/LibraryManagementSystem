﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace LibraryManagementSystem
{

    //book Issue add data class
    class DataIssueBooks
    {

        // creating an SQL connection
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lawrence\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");


        public int ID { get; set; }

        public string IssueID { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string BookTitle { get; set; }

        public string Author { get; set; }

        

        public string Dateissue { get; set; }

public string Status { get; set; }

        public string DateReturn { get; set; }

        public  List<DataIssueBooks> IssueBooksData()
        {

            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            if (connect.State != ConnectionState.Open)
            {

               

                try
                {
                    connect.Open();
                    string selectData = "SELECT * from issues where date_delete is null";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {

                        SqlDataReader reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            DataIssueBooks dib = new DataIssueBooks();
                            dib.ID = (int)reader["id"];
                            dib.IssueID = reader["issue_id"].ToString();
                            dib.Name = reader["full_name"].ToString();
                            dib.Contact = reader["contact"].ToString();
                            dib.Email = reader["email"].ToString();
                            dib.BookTitle = reader["book_title"].ToString();
                            dib.Author = reader["author"].ToString();
                            dib.Email = reader["email"].ToString();
                           
                            dib.Dateissue = reader["issue_date"].ToString();
                            dib.DateReturn = reader["return_date"].ToString();
                            dib.Status = reader["status"].ToString();

                            listData.Add(dib);


                        }

                        reader.Close();
                       
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }


        public List<DataIssueBooks> ReturnIssueBooksData()
        {

            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            if (connect.State != ConnectionState.Open)
            {



                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM issues WHERE status = 'Not Returned' AND date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DataIssueBooks dib = new DataIssueBooks();
                            dib.ID = (int)reader["id"];
                            dib.IssueID = reader["issue_id"].ToString();
                            dib.Name = reader["full_name"].ToString();
                            dib.Contact = reader["contact"].ToString();
                            dib.Email = reader["email"].ToString();
                            dib.BookTitle = reader["book_title"].ToString();
                            dib.Author = reader["author"].ToString();
                            dib.Email = reader["email"].ToString();

                            dib.Dateissue = reader["issue_date"].ToString();
                            dib.DateReturn = reader["return_date"].ToString();
                            dib.Status = reader["status"].ToString();

                            listData.Add(dib);


                        }

                        reader.Close();

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }

    }
}
