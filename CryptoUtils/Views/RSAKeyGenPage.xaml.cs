using CryptoUtils.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views
{
    public sealed partial class RSAKeyGenPage : Page
    {
        public RSAKeyGenViewModel ViewModel { get; set; }

        public RSAKeyGenPage()
        {
            InitializeComponent();

            ViewModel = new RSAKeyGenViewModel();
        }
    }
}
