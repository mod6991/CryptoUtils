using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views.Dialogs
{
    public sealed partial class PasswordDialog : ContentDialog
    {
        public PasswordDialog()
        {
            InitializeComponent();
        }

        public string Password { get; set; }
    }
}
