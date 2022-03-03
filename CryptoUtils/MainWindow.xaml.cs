using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Windows.UI.Core;

namespace CryptoUtils
{
    public sealed partial class MainWindow : Window
    {
        public static DispatcherQueue AppDispatcher { get; private set; }

        public MainWindow()
        {
            this.InitializeComponent();
            Title = "CryptoUtils";
            AppDispatcher = DispatcherQueue;
        }
    }
}
