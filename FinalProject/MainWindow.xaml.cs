﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var con = new SqlConnection("data source=. ; database = Contact_Manager ; integrated security = SSPI"))
            {
                SqlCommand cm = new SqlCommand("Select * from Contact", con);


                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();

                if (!sdr.HasRows)
                {
                    Console.WriteLine("No record found");

                }
                else
                {
                    while (sdr.Read())
                    {
                        // Display Record
                        Contact c = new Contact((int)sdr["id"], (string)sdr["f_name"], (string)sdr["l_name"], (string)sdr["email"], (string)sdr["phone_number"]);
                        contactlist.Add(c);

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
                SecondWindow secondWindow = new SecondWindow(select);
                secondWindow.ShowDialog();
            }
        }
    }
    }
    

