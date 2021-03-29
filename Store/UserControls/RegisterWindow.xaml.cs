using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseConnection;

namespace Store.UserControls
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : UserControl
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void SubmitRegister(object sender, RoutedEventArgs e)
        {
            var first_name = FirstName.Text.Trim();
            var last_name = LastName.Text.Trim();
            var email = EmailAdress.Text.Trim();

            if (State.User == null)
            {
                Customer new_customer = new Customer();

                new_customer.FirstName = first_name;
                new_customer.LastName = last_name;
                new_customer.EmailAdress = email;

                MessageBox.Show("Registration completed!");
            }
            else
            {
                MessageBox.Show("You already have an account");
            }
        }
    }
}
