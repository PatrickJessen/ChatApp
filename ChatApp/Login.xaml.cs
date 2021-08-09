using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ChatApp.UserManagement;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Manager manager;
        public Login()
        {
            InitializeComponent();
            manager = new Manager();
        }

        private void RegistreBtn(object sender, RoutedEventArgs e)
        {
            App.GetParentWindow.MainFrame.Navigate(new Registre());
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            if (manager.SearchLoginMatch(loginUsername.Text, loginPassword.Password))
            {
                App.GetParentWindow.MainFrame.Navigate(new Chat());
            }
            else
                Debug.WriteLine("failed");
        }
    }
}
