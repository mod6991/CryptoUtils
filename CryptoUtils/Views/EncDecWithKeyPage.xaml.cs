using CryptoUtils.ViewModels;
using CryptoUtils.ViewModels.Controls;
using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views
{
    public sealed partial class EncDecWithKeyPage : Page
    {
        public EncDecWithKeyViewModel ViewModel { get; set; }
        public EncDecViewModel EncDecViewModel { get; set; }

        public EncDecWithKeyPage()
        {
            InitializeComponent();

            Loaded += EncDecWithKeyPage_Loaded;

            ViewModel = new EncDecWithKeyViewModel();
            EncDecViewModel = new EncDecViewModel();
        }

        private void EncDecWithKeyPage_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.XamlRoot = XamlRoot;
            EncDecViewModel.XamlRoot = XamlRoot;
        }
    }
}
