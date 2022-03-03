using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace CryptoUtils.ViewModels
{
    public class RSAKeyGenViewModel : ObservableObject
    {
        #region Commands

        private ICommand _generateCommand;
        public ICommand GenerateCommand => _generateCommand ??= new AsyncRelayCommand<int>(Generate);

        #endregion

        #region Properties

        private bool _isWorking;
        public bool IsWorking
        {
            get => _isWorking;
            set => SetProperty(ref _isWorking, value);
        }

        private string _publicKey;
        public string PublicKey
        {
            get => _publicKey;
            set => SetProperty(ref _publicKey, value);
        }

        private string _privateKey;
        public string PrivateKey
        {
            get => _privateKey;
            set => SetProperty(ref _privateKey, value);
        }

        #endregion

        #region Methods

        private async Task Generate(int size)
        {
            IsWorking = true;

            await Task.Run(() =>
            {
                MainWindow.AppDispatcher.TryEnqueue(() =>
                {
                    PublicKey = string.Empty;
                    PrivateKey = string.Empty;
                });

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(size);
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                MainWindow.AppDispatcher.TryEnqueue(() =>
                {
                    PublicKey = publicKey;
                    PrivateKey = privateKey;
                    IsWorking = false;
                });
            });
        }

        #endregion
    }
}
