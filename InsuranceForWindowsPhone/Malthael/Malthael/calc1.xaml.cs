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
    public partial class calc1 : PhoneApplicationPage
    {
        public void Offer()
        {

        }
        public calc1()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        byte a = 99;
        byte b = 99;
        byte c = 99;
        bool res = false;

        private void Visualization(double v)
        {
            lbType.Visibility = Visibility.Collapsed;
            lbType.IsEnabled = false;
            lbBus.Visibility = Visibility.Collapsed;
            lbBus.IsEnabled = false;
            lbAvt.Visibility = Visibility.Collapsed;
            lbAvt.IsEnabled = false;
            lbTovavt.Visibility = Visibility.Collapsed;
            lbTovavt.IsEnabled = false;
            lbCity.Visibility = Visibility.Collapsed;
            lbCity.IsEnabled = false;
            tbox1.Visibility = Visibility.Collapsed;
            tbox2.Visibility = Visibility.Collapsed;
            btn10.IsEnabled = false;
            btn10.Visibility = Visibility.Collapsed;
            btnZ.IsEnabled = true;
            btnZ.Visibility = Visibility.Visible;
            res = true;
            double k = 0;
            if (c == 0) k = v * 1.2;
            else if (c == 1 ) k = v * 1.1;
            else if (c == 2 ) k = v;
            tbox5.Text = k.ToString() + " лв.";
            TempMem.price = k;
            tbox3.Visibility = Visibility.Visible;
            tbox4.Visibility = Visibility.Visible;
            tbox5.Visibility = Visibility.Visible;
        }

        private void Calculate (int a1, int b1)
        {
            if (a1 == 0)
            {
                if (b1 == 0)
                {
                    Visualization(141.77);
                }
                else if (b1 == 1)
                {
                    Visualization(142.87);
                }
                else if (b1 == 2)
                {
                    Visualization(145.89);
                }
                else if (b1 == 3)
                {
                    Visualization(147.79);
                }
                else if (b1 == 4)
                {
                    Visualization(155.08f);
                }
                else if (b1 == 5)
                {
                    Visualization(189.11);
                }
                else if (b1 == 6)
                {
                    Visualization(218.43);
                }
            }
            else if (a1 == 1)
            {
                if (b1 == 0)
                {
                    Visualization(233.25);
                }
                else if (b1 == 1)
                {
                    Visualization(239.60);
                }
                else if (b1 == 2)
                {
                    Visualization(317.96);
                }
                else if (b1 == 3)
                {
                    Visualization(362.93);
                }
                else if (b1 == 4)
                {
                    Visualization(627.88);
                }
                else if (b1 == 5)
                {
                    Visualization(749.97);
                }
            }
            else if (a1 == 6)
            {
                if (b1 == 0)
                {
                    Visualization(382.77);
                }
                else if (b1 == 1)
                {
                    Visualization(512.66);
                }
                else if (b1 == 2)
                {
                    Visualization(603.06);
                }
            }
        }

        private void Calculate (int a1)
        {
            if (a1 == 2) { Visualization(995.29); }
            else if (a1 == 3) { Visualization(83.61); }
            else if (a1 == 4) { Visualization(85.78); }
            else if (a1 == 5) { Visualization(58.14); }
            else if (a1 == 7) { Visualization(346.13); }
            else if (a1 == 8) { Visualization(81.52); }
            else if (a1 == 9) { Visualization(167.21); }
        }
        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            if (lbCity.IsEnabled && lbType.IsEnabled)
            {
                if (lbCity.SelectedIndex == 0) { c = 0; }
                else if (lbCity.SelectedIndex == 1) { c = 1; }
                else if (lbCity.SelectedIndex == 2) { c = 1; }
                else if (lbCity.SelectedIndex == 3) { c = 1; }
                else if (lbCity.SelectedIndex == 4) { c = 2; }
                else { MessageBox.Show("Избери град."); c = 99; }
            }
            if (!lbType.IsEnabled)
            {
                if (a == 0) 
                {
                    if (lbAvt.SelectedIndex == 0) { b = 0; Calculate(a, b); }
                    else if (lbAvt.SelectedIndex == 1) { b = 1; Calculate(a, b); }
                    else if (lbAvt.SelectedIndex == 2) { b = 2; Calculate(a, b); }
                    else if (lbAvt.SelectedIndex == 3) { b = 3; Calculate(a, b); }
                    else if (lbAvt.SelectedIndex == 4) { b = 4; Calculate(a, b); }
                    else if (lbAvt.SelectedIndex == 5) { b = 5; Calculate(a, b); }
                    else if (lbAvt.SelectedIndex == 6) { b = 6; Calculate(a, b); }

                }
                if (a == 1)
                {
                    if (lbTovavt.SelectedIndex == 0) { b = 0; Calculate(a, b); }
                    else if (lbTovavt.SelectedIndex == 1) { b = 1; Calculate(a, b); }
                    else if (lbTovavt.SelectedIndex == 2) { b = 2; Calculate(a, b); }
                    else if (lbTovavt.SelectedIndex == 3) { b = 3; Calculate(a, b); }
                    else if (lbTovavt.SelectedIndex == 4) { b = 4; Calculate(a, b); }
                    else if (lbTovavt.SelectedIndex == 5) { b = 5; Calculate(a, b); }
                }
                if (a == 6)
                {
                    if (lbBus.SelectedIndex == 0) { b = 0; Calculate(a, b); }
                    else if (lbBus.SelectedIndex == 1) { b = 1; Calculate(a, b); }
                    else if (lbBus.SelectedIndex == 2) { b = 2; Calculate(a, b); }
                }
            }
            if (lbType.IsEnabled && c != 99)
            {
                //System.Diagnostics.Debug.WriteLine(lbType.SelectedIndex.ToString());
                if (lbType.SelectedIndex == 0)
                {
                    lbType.Visibility = Visibility.Collapsed;
                    lbType.IsEnabled = false;
                    lbAvt.Visibility = Visibility.Visible;
                    lbAvt.IsEnabled = true;
                    a = 0;
                }
                else if (lbType.SelectedIndex == 1)
                {
                    lbType.Visibility = Visibility.Collapsed;
                    lbType.IsEnabled = false;
                    lbTovavt.Visibility = Visibility.Visible;
                    lbTovavt.IsEnabled = true;
                    a = 1;
                }
                else if (lbType.SelectedIndex == 6)
                {
                    lbType.Visibility = Visibility.Collapsed;
                    lbType.IsEnabled = false;
                    lbBus.Visibility = Visibility.Visible;
                    lbBus.IsEnabled = true;
                    a = 6;
                }
                else if (lbType.SelectedIndex == 2) { a = 2; Calculate(a); }
                else if (lbType.SelectedIndex == 3) { a = 3; Calculate(a); }
                else if (lbType.SelectedIndex == 4) { a = 4; Calculate(a); }
                else if (lbType.SelectedIndex == 5) { a = 5; Calculate(a); }
                else if (lbType.SelectedIndex == 7) { a = 7; Calculate(a); }
                else if (lbType.SelectedIndex == 8) { a = 8; Calculate(a); }
                else if (lbType.SelectedIndex == 9) { a = 9; Calculate(a); }
                else { MessageBox.Show("Избери вид превозно средство."); a = 99;}
            }
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (!res)
            {
                if (!lbType.IsEnabled)
                {
                    lbType.Visibility = Visibility.Visible;
                    lbType.IsEnabled = true;
                    lbAvt.Visibility = Visibility.Collapsed;
                    lbAvt.IsEnabled = false;
                    lbTovavt.Visibility = Visibility.Collapsed;
                    lbTovavt.IsEnabled = false;
                    lbBus.Visibility = Visibility.Collapsed;
                    lbBus.IsEnabled = false;
                    lbCity.IsEnabled = true;
                }
                else { this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); }
            }
            else 
            {
                res = false; 
                a = b = c = 99;
                lbType.Visibility = Visibility.Visible;
                lbType.IsEnabled = true;
                lbCity.Visibility = Visibility.Visible;
                lbCity.IsEnabled = true;
                lbAvt.Visibility = Visibility.Collapsed;
                lbAvt.IsEnabled = false;
                lbTovavt.Visibility = Visibility.Collapsed;
                lbTovavt.IsEnabled = false;
                lbBus.Visibility = Visibility.Collapsed;
                lbBus.IsEnabled = false;
                tbox1.Visibility = Visibility.Visible;
                tbox2.Visibility = Visibility.Visible;
                tbox3.Visibility = Visibility.Collapsed;
                tbox4.Visibility = Visibility.Collapsed;
                tbox5.Visibility = Visibility.Collapsed;
                btnZ.IsEnabled = false;
                btnZ.Visibility = Visibility.Collapsed;
                btn10.IsEnabled = true;
                btn10.Visibility = Visibility.Visible;

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            TempMem.cartype = a;
            TempMem.caraddinfo = b;
            TempMem.city = c;
            this.NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }
    }
}