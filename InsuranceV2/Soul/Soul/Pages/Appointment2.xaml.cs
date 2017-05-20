using Soul.Controller;
using System;
using System.Collections.Generic;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Soul.Pages
{
    public sealed partial class Appointment2 : Page, Connectivity.ISender
    {
        private static Windows.UI.Xaml.Visibility collapsed = Windows.UI.Xaml.Visibility.Collapsed;
        private static Windows.UI.Xaml.Visibility visible = Windows.UI.Xaml.Visibility.Visible;
        Meta meta;
        AppointmentCtrl app;
        //-----------------------------------------------------------------------------------------------
        public Appointment2()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait | DisplayOrientations.PortraitFlipped;
        }
        //-----------------------------------------------------------------------------------------------
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            meta = (Meta)e.Parameter;
            app = meta.AppointmentCtrl;
            InitLoad();
        }
        //-----------------------------------------------------------------------------------------------
        private void Reset()
        {
            lView.ItemsSource = new List<String>();
        }
        //-----------------------------------------------------------------------------------------------
        private void InitLoad()
        {
            Reset();
            app.GetFreeOffices(this);
        }
        //-----------------------------------------------------------------------------------------------
        public void RenderResponseAsync(string msg)
        {
            if (app.State == 2)
            {
                lView.ItemsSource = app.GetOffices(msg);
            }
        }
        //-----------------------------------------------------------------------------------------------
        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Appointment), meta);
        }
        //-----------------------------------------------------------------------------------------------
        private void imgMakeApp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (lView.SelectedIndex != -1)
            {
                app.SetOffice(lView.SelectedValue.ToString());
                this.Frame.Navigate(typeof(Appointment3), meta);
            }
        }
        //-----------------------------------------------------------------------------------------------
    }
}
