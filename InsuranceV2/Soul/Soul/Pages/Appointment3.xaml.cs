using Soul.Connectivity;
using Soul.Controller;
using System;
using System.Collections.Generic;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Soul.Pages
{
    public sealed partial class Appointment3 : Page, ISender
    {
        Meta meta;
        AppointmentCtrl app;
        public Appointment3()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait | DisplayOrientations.PortraitFlipped;
        }

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
            app.MakeAnAppointment(this);
        }
        //-----------------------------------------------------------------------------------------------
        public void RenderResponseAsync(string msg)
        {
            if (app.State == 3)
            {
                lView.ItemsSource = app.GetAllAppintments(msg);
            }
        }
        //-----------------------------------------------------------------------------------------------
        private void imgBack_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), meta);
        }
        //-----------------------------------------------------------------------------------------------
    }
}
