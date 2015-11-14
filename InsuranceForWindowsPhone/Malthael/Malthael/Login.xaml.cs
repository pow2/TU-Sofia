using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Malthael
{
    public partial class Login : PhoneApplicationPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn5Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btn6Login_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateRemoteHost() && ValidateInput())
            {
                logininf li1 = new logininf(txtUsername.Text, pwdbox1.Password);
                SocketClient client = new SocketClient();
                string result = client.Connect(remotehost, remoteport);
                result = client.Send(li1.ToString());
                result = client.Receive();
                client.Close();
                if (result == "Грешно име или парола") { MessageBox.Show(result); }
                else
                {
                    //MessageBox.Show(result);
                    try
                    {
                        TempMem.ID = Convert.ToInt32(result);
                        TempMem.username = txtUsername.Text;
                        TempMem.password = pwdbox1.Password;
                        this.NavigationService.Navigate(new Uri("/Create.xaml", UriKind.Relative));
                    }
                    catch
                    {
                        MessageBox.Show("Грешка в получените данни");
                    }
                }
                    
            }
            //endbtn
        }



        //IP
        string remoteEndpoint = TempMem.host;
        string remotehost;
        int remoteport;

        private bool ValidateInput()
        {
            // txtInput must contain some text
            if (String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Въведете потребителско име");
                return false;
            }
            if (String.IsNullOrWhiteSpace(pwdbox1.Password))
            {
                MessageBox.Show("Въведете парола");
                return false;
            }
            return true;
        }

        private bool ValidateRemoteHost()
        {
            if (string.IsNullOrEmpty(remoteEndpoint) || remoteEndpoint.IndexOf(':') < 0)
            {
                MessageBox.Show("Грешен хост");
                return false;
            }

            string[] remoteEndpointParts = remoteEndpoint.Split(':');
            remotehost = remoteEndpointParts[0].Trim();
            remoteport = Convert.ToInt32(remoteEndpointParts[1].Trim());
            return true;
        }


    }
}