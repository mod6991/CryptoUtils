using CryptoUtils.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
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
                NavigateTo(typeof(SettingsPage));
            }
            else
            {
                NavigationViewItem item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                switch (item.Tag)
                {
                    case "rsa":
                        NavigateTo(typeof(RSAKeyGenPage));
                        break;

                    case "key":
                        NavigateTo(typeof(EncDecWithKeyPage));
                        break;

                    case "pass":
                        NavigateTo(typeof(EncDecWithPassPage));
                        break;

                    case "hash":
                        NavigateTo(typeof(HashPage));
                        break;
                }
            }
        }

        private void NavigateTo(Type pageType)
        {
            if (ContentFrame.SourcePageType != pageType)
                ContentFrame.Navigate(pageType);
        }
    }
}
