using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;

namespace CryptoUtils.ViewModels
{
    public class EncDecWithKeyViewModel : ObservableObject
    {
        #region Commands

        private ICommand _encryptCommand;
        public ICommand EncryptCommand => _encryptCommand ??= new AsyncRelayCommand(Encrypt); //() => 

        private ICommand _decryptCommand;
        public ICommand DecryptCommand => _decryptCommand ??= new AsyncRelayCommand(Decrypt);

        #endregion

        #region Properties

        public XamlRoot XamlRoot { get; set; }

        #endregion

        #region Methods

        private async Task Encrypt()
        {

        }

        private async Task Decrypt()
        {

        }

        #endregion
    }
}
