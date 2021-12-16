using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace FinalProject
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        Contact contact;
        public SecondWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;

            Id.Text ="ID: "+contact.Id.ToString();
            first_name.Text ="First Name: "+ contact.first_name;
            last_name.Text = "Last Name: "+ contact.last_name;
            email.Text = "Email: "+ contact.email;
            phone_number.Text = "Phone Number: "+ contact.phone_num;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow updateWindow = new UpdateWindow(contact);
            this.Close();
            updateWindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int Id = contact.Id;
            DBManager.DeleteContact(Id, this);
        }

        private void Return_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}

