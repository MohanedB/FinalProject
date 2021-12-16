using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace FinalProject
{
    static class DBManager
    {
        public static List<Contact> ListContacts()
        {
            List<Contact> contactlist = new List<Contact>();

            using (SqlConnection con = new SqlConnection("data source=.; database = Contact_Manager ; integrated security = SSPI"))
            {

                SqlCommand cm = new SqlCommand("Select * from Contacts", con);


                con.Open();

                using (SqlDataReader sdr = cm.ExecuteReader())

                {

                    if (!sdr.HasRows)
                    {
                        MessageBox.Show("No record found");
                        return null;
                    }
                    else
                    {

                        while (sdr.Read())
                        {

                            // Display Record
                            //maxId = (int)sdr["Id"];
                            Contact i = new Contact((int)sdr["Id"], (string)sdr["FirstName"], (string)sdr["LastName"], (string)sdr["Email"], (string)sdr["PhoneNumber"]);

                            contactlist.Add(i);

                        }

                        return contactlist;
                    }

                }
            }
        }
        public static void AddNewContact(object FirstNameInput, object LastNameInput, object EmailInput, object PhoneNumberInput, int indexNumber, AddWindow myWindow)
        {
            bool keepGoing = true;
            List<string> insertStrings = new List<String>();
            string tempString;

            tempString = ((TextBox)FirstNameInput).Text;
            if (tempString.Length > 0 && tempString.Length <= 50)
            {
                insertStrings.Add(tempString);
            }
            else
            {
                keepGoing = false;
            }

            tempString = ((TextBox)LastNameInput).Text;
            if (tempString.Length > 0 && tempString.Length <= 50)
            {
                insertStrings.Add(tempString);
            }
            else
            {
                keepGoing = false;
            }

            tempString = ((TextBox)EmailInput).Text;
            if (tempString.Length > 0 && tempString.Length <= 50)
            {
                insertStrings.Add(tempString);
            }
            else
            {
                keepGoing = false;
            }

            tempString = ((TextBox)PhoneNumberInput).Text;
            if (tempString.Length > 0 && tempString.Length <= 50)
            {
                insertStrings.Add(tempString);
            }
            else
            {
                keepGoing = false;
            }

            if (keepGoing)
            {
                try
                {
                    var con = new SqlConnection("data source=.; database = Contact_Manager; integrated security = SSPI");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Contacts (Id,FirstName,LastName,Email,PhoneNumber) VALUES(@I,@F,@L,@E,@P)", con);
                    cmd.Parameters.AddWithValue("@I", indexNumber);
                    cmd.Parameters.AddWithValue("@F", insertStrings[0]);
                    cmd.Parameters.AddWithValue("@L", insertStrings[1]);
                    cmd.Parameters.AddWithValue("@E", insertStrings[2]);
                    cmd.Parameters.AddWithValue("@P", insertStrings[3]);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Contact added successfully.");
                }
                catch (SqlException exc)
                {
                    MessageBox.Show("Error generated. Details: " + exc.ToString());
                }
                finally
                {
                    MainWindow mainWindow = new MainWindow();
                    myWindow.Close();
                    mainWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid data entered.\nPlease keep all inputs between 1 and 50 characters.");
            }
        }

        public static void AddNewContactFromData(string FirstNameInput, string LastNameInput, string EmailInput, string PhoneNumberInput, int indexNumber)
        {
            bool keepGoing = true;
            List<string> insertStrings = new List<String>();

            if (FirstNameInput.Length > 0 && FirstNameInput.Length <= 50)
            {
                insertStrings.Add(FirstNameInput);
            }
            else
            {
                keepGoing = false;
            }

            if (LastNameInput.Length > 0 && LastNameInput.Length <= 50)
            {
                insertStrings.Add(LastNameInput);
            }
            else
            {
                keepGoing = false;
            }

            if (EmailInput.Length > 0 && EmailInput.Length <= 50)
            {
                insertStrings.Add(EmailInput);
            }
            else
            {
                keepGoing = false;
            }

            if (PhoneNumberInput.Length > 0 && PhoneNumberInput.Length <= 50)
            {
                insertStrings.Add(PhoneNumberInput);
            }
            else
            {
                keepGoing = false;
            }

            if (keepGoing)
            {
                try
                {
                    var con = new SqlConnection("data source=.; database = Contact_Manager; integrated security = SSPI");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Contacts (Id,FirstName,LastName,Email,PhoneNumber) VALUES(@I,@F,@L,@E,@P)", con);
                    cmd.Parameters.AddWithValue("@I", indexNumber);
                    cmd.Parameters.AddWithValue("@F", insertStrings[0]);
                    cmd.Parameters.AddWithValue("@L", insertStrings[1]);
                    cmd.Parameters.AddWithValue("@E", insertStrings[2]);
                    cmd.Parameters.AddWithValue("@P", insertStrings[3]);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show("Error generated. Details: " + exc.ToString());
                }
            }
            else
            {
                MessageBox.Show("Invalid data entered.\nPlease keep all inputs between 1 and 50 characters.");
            }
        }

        public static void UpdateContact(object FirstNameInput, object LastNameInput, object EmailInput, object PhoneNumberInput, int indexNumber, UpdateWindow myWindow)
        {
            bool keepGoing = true;
            List<string> insertStrings = new List<String>();
            string tempString;

            tempString = ((TextBox)FirstNameInput).Text;
            if (tempString.Length > 0 && tempString.Length <= 50)
            {
                insertStrings.Add(tempString);
            }
            else
            {
                keepGoing = false;
            }

            tempString = ((TextBox)LastNameInput).Text;
            if (tempString.Length > 0 && tempString.Length <= 50)
            {
                insertStrings.Add(tempString);
            }
            else
            {
                keepGoing = false;
            }

            tempString = ((TextBox)EmailInput).Text;
            if (tempString.Length > 0 && tempString.Length <= 50)
            {
                insertStrings.Add(tempString);
            }
            else
            {
                keepGoing = false;
            }

            tempString = ((TextBox)PhoneNumberInput).Text;
            if (tempString.Length > 0 && tempString.Length <= 50)
            {
                insertStrings.Add(tempString);
            }
            else
            {
                keepGoing = false;
            }

            if (keepGoing)
            {
                try
                {
                    var con = new SqlConnection("data source=.; database = Contact_Manager; integrated security = SSPI");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Contacts SET FirstName = @F,LastName = @L,Email = @E,PhoneNumber = @P WHERE Id = @I", con);
                    cmd.Parameters.AddWithValue("@I", indexNumber);
                    cmd.Parameters.AddWithValue("@F", insertStrings[0]);
                    cmd.Parameters.AddWithValue("@L", insertStrings[1]);
                    cmd.Parameters.AddWithValue("@E", insertStrings[2]);
                    cmd.Parameters.AddWithValue("@P", insertStrings[3]);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Contact updated successfully.");
                }
                catch (SqlException exc)
                {
                    MessageBox.Show("Error generated. Details: " + exc.ToString());
                }
                finally
                {
                    MainWindow mainWindow = new MainWindow();
                    myWindow.Close();
                    mainWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid data entered.\nPlease keep all inputs between 1 and 50 characters.");
            }
        }

        public static void DeleteContact(int indexNumber, SecondWindow myWindow)
        {
            using (SqlConnection con = new SqlConnection("data source=.; database = Contact_Manager ; integrated security = SSPI"))
            {
                SqlCommand cmd = new SqlCommand("DELETE From Contacts Where Id = @Id", con);

                cmd.Parameters.AddWithValue("@Id", indexNumber);

                try
                {
                    con.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully");
                    con.Close();

                    MainWindow mainWindow = new MainWindow();
                    myWindow.Close();
                    mainWindow.ShowDialog();

                }
                catch (SqlException exc)
                {
                    MessageBox.Show("Error Generated. Details: " + exc.ToString());
                }
            }
        }

        public static void DeleteAllContacts()
        {
            using (SqlConnection con = new SqlConnection("data source=.; database = Contact_Manager ; integrated security = SSPI"))
            {
                SqlCommand cmd = new SqlCommand("DELETE From Contacts", con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (SqlException exc)
                {
                    MessageBox.Show("Error Generated. Details: " + exc.ToString());
                }
            }
        }
    }
}
