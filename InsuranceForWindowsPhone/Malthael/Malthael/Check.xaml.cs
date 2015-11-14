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
using Malthael;
using System.Net.Sockets;
using System.Text;

namespace Malthael
{   
    public partial class Check : PhoneApplicationPage
    {
        public Check()
        {
            InitializeComponent();
        }

        private void btn5Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btn4Sent_Click(object sender, RoutedEventArgs e)
        {
            // Clear the log 
            ClearLog();

            // Make sure we can perform this action with valid data
            if (ValidateRemoteHost() && ValidateInput())
            {
                Chk chk1 = new Chk(txtName.Text, txtLastName.Text, txtNumber.Text);
                // Instantiate the SocketClient
                SocketClient client = new SocketClient();

                // Attempt to connect to the echo server
                //Log(String.Format("Connecting to server '{0}' over port {1} ...", remotehost, remoteport), true);
                string result = client.Connect(remotehost, remoteport);
                //Log(result, false);

                // Attempt to send our message to be echoed to the echo server
                //Log(String.Format("Sending '{0}' to server ...", chk1.ToString()), true);
                result = client.Send(chk1.ToString());
                //Log(result, false);

                // Receive a response from the echo server
                //Log("Requesting Receive ...", true);
                //ClearLog();
                result = client.Receive();
                Log(result, false);

                // Close the socket connection explicitly
                client.Close();
            }
            //endbtn
        }

        //IP
        string remoteEndpoint = TempMem.host;
        string remotehost;
        int remoteport;

        #region UI Validation
        /// <summary>
        /// Validates the txtInput TextBox
        /// </summary>
        /// <returns>True if the txtInput TextBox contains valid data, otherwise 
        /// False.
        ///</returns>
        private bool ValidateInput()
        {
            // txtInput must contain some text
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter name");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter last name");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Please enter number");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the txtRemoteHost TextBox
        /// </summary>
        /// <returns>True if the txtRemoteHost contains valid data,
        /// otherwise False
        /// </returns>
        private bool ValidateRemoteHost()
        {
            if (string.IsNullOrEmpty(remoteEndpoint) || remoteEndpoint.IndexOf(':') < 0)
            {
                MessageBox.Show("Грешен хост");
                return false;
            }

            // split and convert
            string[] remoteEndpointParts = remoteEndpoint.Split(':');
            remotehost = remoteEndpointParts[0].Trim();
            remoteport = Convert.ToInt32(remoteEndpointParts[1].Trim());

            // create endpoint
            //var ipAddress = IPAddress.Parse(host);
            //var endpoint = new IPEndPoint(ipAddress, port);

            return true;
        }
        #endregion

        #region Logging
        /// <summary>
        /// Log text to the txtOutput TextBox
        /// </summary>
        /// <param name="message">The message to write to the txtOutput TextBox</param>
        /// <param name="isOutgoing">True if the message is an outgoing (client to server)
        /// message, False otherwise.
        /// </param>
        /// <remarks>We differentiate between a message from the client and server 
        /// by prepending each line  with ">>" and "<<" respectively.</remarks>
        private void Log(string message, bool isOutgoing)
        {
            //string direction = (isOutgoing) ? ">> " : "<< ";
            //txtbl6.Text += Environment.NewLine + direction + message;
            txtbl6.Text += Environment.NewLine + message;
        }

        /// <summary>
        /// Clears the txtOutput TextBox
        /// </summary>
        private void ClearLog()
        {
            txtbl6.Text = String.Empty;
        }
        #endregion
            






    }
}