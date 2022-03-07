using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views.Dialogs
{
    public sealed partial class PasswordContentDialog : ContentDialog
    {
        public PasswordContentDialog()
        {
            InitializeComponent();
        }

        public string Password { get; set; }
    }
}
