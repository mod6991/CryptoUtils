using CryptoUtils.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;

namespace CryptoUtils.Views
{
    public sealed partial class ShellPage : Page
    {
        public ShellPageViewModel ViewModel { get; }

        public ShellPage()
        {
            InitializeComponent();

            ViewModel = new ShellPageViewModel();
            DataContext = ViewModel;

            Loaded += ShellPage_Loaded;
            Unloaded += ShellPage_Unloaded;
        }

        private void ShellPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavView.ItemInvoked += NavView_ItemInvoked;
        }

        private void ShellPage_Unloaded(object sender, RoutedEventArgs e)
        {
            NavView.ItemInvoked -= NavView_ItemInvoked;
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                Navigate(item);
            }
        }

        private void Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "rsa":
                    ContentFrame.Navigate(typeof(RSAKeyGenPage));
                    break;

                case "key":
                    ContentFrame.Navigate(typeof(EncDecWithKeyPage));
                    break;

                case "pass":
                    ContentFrame.Navigate(typeof(EncDecWithPassPage));
                    break;

                case "hash":
                    ContentFrame.Navigate(typeof(HashPage));
                    break;
            }
        }
    }
}
