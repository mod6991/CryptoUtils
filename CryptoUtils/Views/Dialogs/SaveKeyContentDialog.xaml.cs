using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views.Dialogs
{
    public sealed partial class SaveKeyContentDialog : ContentDialog
    {
        public SaveKeyContentDialog()
        {
            InitializeComponent();
        }

        public bool EncryptWithPassword { get; set; } = true;
        public string Password { get; set; }
    }
}
