using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
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

                    }
                    else
                    {
                       
                        while (sdr.Read())
                        {
                            
                            // Display Record
                            
                            Contact i = new Contact((int)sdr["Id"], (string)sdr["FirstName"], (string)sdr["LastName"], (string)sdr["Email"], (string)sdr["PhoneNumber"]);
                            
                            contactlist.Add(i);

                        }
                       
                        DataBinding.ItemsSource = contactlist;
                    }

                }
            }
        }

        private void DataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact select = (Contact)DataBinding.SelectedItem;

            if (select != null)
            {

                SecondWindow secondwindow = new SecondWindow(select);
                secondwindow.ShowDialog();
            }
        }
    }
    }
    

