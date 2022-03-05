using CryptoUtils.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views
{
    public sealed partial class RSAKeyGenPage : Page
    {
        public RSAKeyGenViewModel ViewModel { get; private set; }

        public RSAKeyGenPage()
        {
            InitializeComponent();

            ViewModel = new RSAKeyGenViewModel();

            Loaded += RSAKeyGenPage_Loaded;
        }

        private void RSAKeyGenPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.XamlRoot = Content.XamlRoot;
        }
    }
}
