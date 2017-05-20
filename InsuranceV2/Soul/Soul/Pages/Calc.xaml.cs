using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Soul.Controller;
using Windows.Graphics.Display;

namespace Soul.Pages
{
    public sealed partial class Calc : Page, Connectivity.ISender
    {
        //-----------------------------------------------------------------------------------------------
        Meta meta;
        Calculator calc;
        //-----------------------------------------------------------------------------------------------
        public Calc()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait | DisplayOrientations.PortraitFlipped;
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
            calc = meta.Calc;
            LoadResources();
        }
        //-----------------------------------------------------------------------------------------------
        private void LoadResources()
        {
            cbCities.ItemsSource = calc.BindingLists.Cities;
            cbVehicles.ItemsSource = calc.BindingLists.Vehicles;
        }
        //-----------------------------------------------------------------------------------------------
        private void cbVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbCapacity.ItemsSource = calc.VehCapacity(cbVehicles.SelectedValue.ToString());
            cbCapacity.SelectedIndex = 0;
        }
        //-----------------------------------------------------------------------------------------------
        public void RenderResponseAsync(string msg)
        {
            tbResp.Text = calc.FormatResponse(msg);
        }
        //-----------------------------------------------------------------------------------------------
        private void imgCalc_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (cbCities.SelectedIndex != -1 && cbVehicles.SelectedIndex != -1 && cbCapacity.SelectedIndex != -1)
            {
                calc.GetRespFromServer(cbCities.SelectedValue.ToString(), cbVehicles.SelectedValue.ToString(), cbCapacity.SelectedValue.ToString(), this);
            }
            else
            {
                tbResp.Text = Errors.FILLTHEFIELDS;
            }
        }
        //-----------------------------------------------------------------------------------------------
    }
}
