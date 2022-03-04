using System;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;

namespace CryptoUtils
{
    public sealed partial class MainWindow : Window
    {
        public static DispatcherQueue AppDispatcher { get; private set; }
        public static IntPtr WindowHandle { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            Title = "CryptoUtils";

            AppDispatcher = DispatcherQueue;
            WindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(this);
        }
    }
}
