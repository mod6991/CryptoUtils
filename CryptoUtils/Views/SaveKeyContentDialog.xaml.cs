using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views
{
    public sealed partial class SaveKeyContentDialog : Page
    {
        public SaveKeyContentDialog()
        {
            InitializeComponent();
        }

        public bool EncryptWithPassword { get; set; } = true;
        public string Password { get; set; }
    }
}
