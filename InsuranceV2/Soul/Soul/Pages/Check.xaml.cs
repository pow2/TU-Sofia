using Soul.Controller;
using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Soul.Pages
{
    public sealed partial class Check : Page, Connectivity.ISender
    {
        //-----------------------------------------------------------------------------------------------
        Meta meta;
        Checker chk;
        //-----------------------------------------------------------------------------------------------
        public Check()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait | DisplayOrientations.PortraitFlipped;
        }
        //-----------------------------------------------------------------------------------------------
        private void imgCheck_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CheckIt();
        }
        //-----------------------------------------------------------------------------------------------
        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), meta);
        }
        //-----------------------------------------------------------------------------------------------
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            meta = (Meta)e.Parameter;
            chk = meta.Chk;
        }
        //-----------------------------------------------------------------------------------------------
        public void RenderResponseAsync(string msg)
        {
            tbResp.Text = chk.GetActiveStatus(msg);
        }
        //-----------------------------------------------------------------------------------------------
        private void CheckIt()
        {
            tbResp.Text = chk.VerifyAndSend(tbxNumber.Text, this);
        }
        //-----------------------------------------------------------------------------------------------
    }
}
