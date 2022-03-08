using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views.Dialogs
{
    public sealed partial class SaveKeyDialog : ContentDialog
    {
        public SaveKeyDialog()
        {
            InitializeComponent();
        }

        public bool EncryptWithPassword { get; set; } = true;
        public string Password { get; set; }
    }
}
