using Soul.Controller;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Soul.Pages
{
    public sealed partial class Settings : Page
    {
        //-----------------------------------------------------------------------------------------------
        Meta meta;
        //-----------------------------------------------------------------------------------------------
        public Settings()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait | DisplayOrientations.PortraitFlipped;
        }
        //-----------------------------------------------------------------------------------------------
        private void imgGo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            meta.SetHost(tbxIP.Text, tbxPort.Text);
            this.Frame.Navigate(typeof(MainPage), meta);
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
        }
        //-----------------------------------------------------------------------------------------------
    }
}
