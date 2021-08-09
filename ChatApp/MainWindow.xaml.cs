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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Login login = new Login();
            //if (login.loginUsername.Text == "")
            //    MainFrame.Navigate(login);
            //else
            //{
            //    Chat chat = new Chat();
            //    MainFrame.Navigate(chat);
            //}
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.GetParentWindow = this;
            this.MainFrame.Navigate(new Login());
        }
    }
}
