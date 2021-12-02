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
            last_name.Text = "last Name: "+ contact.last_name;
            email.Text = "Email: "+ contact.email;
            phone_number.Text = "Phone Number: "+ contact.phone_num;
        }
    }
    }

