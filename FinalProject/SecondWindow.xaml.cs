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

            Id.Text = contact.Id.ToString();
            first_name.Text = contact.f_name;
            last_name.Text = contact.l_name;
            email.Text = contact.email;
            phone_number.Text = contact.phone_number;
        }
    }
    }

