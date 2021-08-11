using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Page
    {
        ChatHandler handler;
        ListBoxItem itm;
        Dispatcher dispatcher;
        string Text { get; set; }
        public Chat()
        {
            handler = new ChatHandler();
            InitializeComponent();
            dispatcher = this.Dispatcher;
            handler.ConnectToServer("127.0.0.1", 8000);
            itm = new ListBoxItem();

            listbox.Items.CurrentChanged += Items_CurrentChanged;

            handler.ReceiveMessage += new EventHandler(Handler_ReceiveMessage);
        }

        private void Handler_ReceiveMessage(object sender, EventArgs e)
        {
                listbox.Items.Add($"{DateTime.Now} - {itm.Content.ToString()}");
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.ScrollIntoView(listbox.SelectedItem);
        }

        private void Items_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            handler.SendMessage(textMessage.Text);
            //itm.Content = handler.ReceiveMessages();
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                itm.Dispatcher.Invoke(new Action(() =>
                {
                    if (itm.Content != null)
                    {
                        listbox.Items.Add($"{DateTime.Now} - {itm.Content.ToString()}");
                        listbox.SelectedIndex = listbox.Items.Count - 1;
                        listbox.ScrollIntoView(listbox.SelectedItem);
                    }
                    return;
                }));
            }
        }

        private void listbox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
