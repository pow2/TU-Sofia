using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public partial class Create : PhoneApplicationPage
    {
        public Create()
        {
            InitializeComponent();
            txtblPrice.Text = TempMem.price.ToString() + " лв.";
        }

        private void btn5Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btn6Reg_Click(object sender, RoutedEventArgs e)
        {
            
            if (ValidateRemoteHost() && ValidateInput())
            {
                register reg1 = new register(TempMem.username, TempMem.password, txtFname.Text, txtLname.Text, txtNum.Text, txtBrand.Text, txtModel.Text, TempMem.cartype.ToString(), TempMem.caraddinfo.ToString(), TempMem.price.ToString(), TempMem.city.ToString(), TempMem.ID.ToString());
                SocketClient client = new SocketClient();
                string result = client.Connect(remotehost, remoteport);
                result = client.Send(reg1.ToString());
                result = client.Receive();
                client.Close();
                if (result == "Системата не може да изпълни заявката в момента") { MessageBox.Show(result); }
                else
                {
                    try
                    {
                        MessageBox.Show(result);
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
            if (String.IsNullOrWhiteSpace(txtFname.Text))
            {
                MessageBox.Show("Въведете име");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("Въведете фамилия");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("Въведете рег.номер");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtBrand.Text))
            {
                MessageBox.Show("Въведете марка");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Въведете модел");
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