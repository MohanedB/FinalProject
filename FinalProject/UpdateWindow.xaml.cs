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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        Contact contact;
        int indexNumber;
        public UpdateWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;
            this.indexNumber = contact.Id;

            FirstNameInput.Text = contact.first_name;
            LastNameInput.Text = contact.last_name;
            EmailInput.Text = contact.email;
            PhoneNumberInput.Text = contact.phone_num;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DBManager.UpdateContact(FirstNameInput, LastNameInput, EmailInput, PhoneNumberInput, indexNumber, this);
        }

        private void Return_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}

