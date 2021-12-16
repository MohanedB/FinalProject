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
using System.IO;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxId = 0;

        public MainWindow()
        {
            InitializeComponent();
            DataBinding.ItemsSource = DBManager.ListContacts();
        }

        private void DataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact select = (Contact)DataBinding.SelectedItem;

            if (select != null)
            {
                SecondWindow secondwindow = new SecondWindow(select);
                this.Close();
                secondwindow.ShowDialog();
            }

            DataBinding.SelectedIndex = -1;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow(maxId + 1);
            this.Close();
            addWindow.ShowDialog();
        }

        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            List<Contact> myContacts = DBManager.ListContacts();
            FileInfo file = new FileInfo(((TextBox)exportFileNameBox).Text);
            try
            {
                if (!file.Exists)
                {
                    using (StreamWriter sw = file.AppendText())
                    {
                        sw.Write(String.Empty);
                        for (int i = 0; i < myContacts.Count; i++)
                        {
                            Contact myContact = myContacts[i];
                            sw.Write(myContact.Id.ToString());
                            sw.Write(",");
                            sw.Write(myContact.first_name.ToString());
                            sw.Write(",");
                            sw.Write(myContact.last_name.ToString());
                            sw.Write(",");
                            sw.Write(myContact.email.ToString());
                            sw.Write(",");
                            sw.Write(myContact.phone_num.ToString());
                            sw.Write(",\n");
                        }
                    }

                    MessageBox.Show("File successfully exported.");
                }
                else
                {
                    MessageBox.Show("This file already exists.\nPlease delete it or select\na new file name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                file = null;
            }
        }

        private void importButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> contactStrings = new List<string>();
            FileInfo file = new FileInfo(((TextBox)exportFileNameBox).Text);
            try
            {
                if (file.Exists)
                {
                    using (StreamReader sr = new StreamReader(((TextBox)exportFileNameBox).Text))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            contactStrings.Add(line);
                        }
                    }

                    DBManager.DeleteAllContacts();

                    for(int i = 0; i < contactStrings.Count; i++)
                    {
                        string tempString = contactStrings[i];
                        string[] arr = tempString.Split(',');
                        DBManager.AddNewContactFromData(arr[1], arr[2], arr[3], arr[4], Int32.Parse(arr[0]));
                    }

                    DataBinding.ItemsSource = DBManager.ListContacts();
                    MessageBox.Show("Contacts successfully imported.");
                }
                else
                {
                    MessageBox.Show("This file does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                file = null;
            }
        }
    }
}
    

