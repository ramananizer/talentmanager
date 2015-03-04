using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ApplicationStartUpService
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : Window
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            Application.Current.Shutdown();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Write code here to authenticate user
            // If authenticated, then set DialogResult=true
            //DialogResult = true;
            if (txtUserName.Text == "Raman" && txtPassword.Password == "a80tude")
                DialogResult = true;
            else
                DialogResult = false;
        }
    }
}
