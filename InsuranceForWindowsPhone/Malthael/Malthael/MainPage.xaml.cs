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
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn2Check_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Check.xaml", UriKind.Relative));
        }

        private void btn3Create_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

        private void btn1Calc_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/calc1.xaml", UriKind.Relative));
        }


    }
}