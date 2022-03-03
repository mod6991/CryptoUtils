using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Byte.Toolkit.Crypto.PubKey;
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

                var rsa = RSA.GenerateKeyPair(size);

                string publicKey = string.Empty;
                string privateKey = string.Empty;

                using (MemoryStream ms = new MemoryStream())
                {
                    RSA.SavePublicKeyToPEM(rsa, ms);
                    publicKey = Encoding.UTF8.GetString(ms.ToArray());
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    RSA.SavePrivateKeyToPEM(rsa, ms);
                    privateKey = Encoding.UTF8.GetString(ms.ToArray());
                }

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
