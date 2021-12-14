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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        int indexNumber;

        public AddWindow(int i)
        {
            InitializeComponent();
            indexNumber = i;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DBManager.AddNewContact(FirstNameInput, LastNameInput, EmailInput, PhoneNumberInput, indexNumber, this);
        }

        private void Return_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}

