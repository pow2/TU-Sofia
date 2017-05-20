using Soul.Controller;
using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;


namespace Soul.Pages
{
    public sealed partial class Appointment : Page, Connectivity.ISender
    {
        private static Windows.UI.Xaml.Visibility collapsed = Windows.UI.Xaml.Visibility.Collapsed;
        private static Windows.UI.Xaml.Visibility visible = Windows.UI.Xaml.Visibility.Visible;
        Meta meta;
        AppointmentCtrl app;
        //-----------------------------------------------------------------------------------------------
        public Appointment()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait | DisplayOrientations.PortraitFlipped;
        }
        //-----------------------------------------------------------------------------------------------
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            meta = (Meta)e.Parameter;
            app = meta.AppointmentCtrl;
            dataPicker.MinDate = DateTime.Today;
            dataPicker.MaxDate = DateTime.Today.AddMonths(6);

            InitLoad();
        }
        //-----------------------------------------------------------------------------------------------
        private void Reset()
        {
            app.ResetState();
            tbWait.Visibility = visible;
            tb1.Visibility = collapsed;
            cbCities.Visibility = collapsed;
            tb2.Visibility = collapsed;
            cbHours.Visibility = collapsed;
            tb3.Visibility = collapsed;
            dataPicker.Visibility = collapsed;
        }
        //-----------------------------------------------------------------------------------------------
        private void InitLoad()
        {
            Reset();
            app.GetCitiesFromServer(this);
        }
        //-----------------------------------------------------------------------------------------------
        public void RenderResponseAsync(string msg)
        {
            if (app.State == 1)
            {
                tbWait.Visibility = collapsed;
                tb1.Visibility = visible;
                cbCities.Visibility = visible;
                cbCities.ItemsSource = app.GetListOfCities(msg);
                tb2.Visibility = visible;
                cbHours.Visibility = visible;
                cbHours.ItemsSource = app.GetWorkingHours();
                tb3.Visibility = visible;
                dataPicker.Visibility = visible;
                cbCities.SelectedIndex = -1;
            }
        }
        //-----------------------------------------------------------------------------------------------
        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), meta);
        }
        //-----------------------------------------------------------------------------------------------
        private void imgMakeApp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string date = app.DateExtractor(dataPicker.Date);

            if (cbCities.SelectedIndex != -1 && cbHours.SelectedIndex != -1 && !String.IsNullOrWhiteSpace(date))
            {
                app.City = cbCities.SelectedValue.ToString();
                app.SetAppDTM(date, cbHours.SelectedValue.ToString());
                this.Frame.Navigate(typeof(Appointment2), meta);
            }
        }
        //-----------------------------------------------------------------------------------------------
    }
}
