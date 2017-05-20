using Windows.ApplicationModel.Core;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Soul.Controller;
using Soul.Pages;

namespace Soul
{
    public sealed partial class MainPage : Page
    {
        Meta meta;

        public MainPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait | DisplayOrientations.PortraitFlipped;
        }

        private void imgExit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            meta = (Meta) e.Parameter;
        }

        private void imgCheck_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Check), meta);
        }

        private void imgCalc_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Calc), meta);
        }

        private void imgMakeAp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Appointment), meta);
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings), meta);
        }
    }
}
