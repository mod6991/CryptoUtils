using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Byte.Toolkit.Crypto.PubKey;
using CryptoUtils.Views.Dialogs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace CryptoUtils.ViewModels
{
    public class RSAKeyGenViewModel : ObservableObject
    {
        #region Commands

        private ICommand _generateCommand;
        public ICommand GenerateCommand => _generateCommand ??= new AsyncRelayCommand<int>(Generate);

        private ICommand _loadCommand;
        public ICommand LoadCommand => _loadCommand ??= new AsyncRelayCommand(Load);

        private ICommand _savePublicKeyCommand;
        public ICommand SavePublicKeyCommand => _savePublicKeyCommand ??= new AsyncRelayCommand(SavePublicKey, () => !string.IsNullOrWhiteSpace(PublicKey));

        private ICommand _savePrivateKeyCommand;
        public ICommand SavePrivateKeyCommand => _savePrivateKeyCommand ??= new AsyncRelayCommand(SavePrivateKey, () => !string.IsNullOrWhiteSpace(PrivateKey));

        #endregion

        #region Properties

        public XamlRoot XamlRoot { get; set; }

        private bool _isWorking;
        public bool IsWorking
        {
            get => _isWorking;
            set => SetProperty(ref _isWorking, value);
        }

        public System.Security.Cryptography.RSACryptoServiceProvider Key { get; set; }

        private string _publicKey;
        public string PublicKey
        {
            get => _publicKey;
            set
            {
                SetProperty(ref _publicKey, value);
                ((AsyncRelayCommand)SavePublicKeyCommand).NotifyCanExecuteChanged();
            }
        }

        private string _privateKey;
        public string PrivateKey
        {
            get => _privateKey;
            set
            {
                SetProperty(ref _privateKey, value);
                ((AsyncRelayCommand)SavePrivateKeyCommand).NotifyCanExecuteChanged();
            }
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

                Key = RSA.GenerateKeyPair(size);

                string publicKey = string.Empty;
                string privateKey = string.Empty;

                using (MemoryStream ms = new MemoryStream())
                {
                    RSA.SavePublicKeyToPEM(Key, ms);
                    publicKey = Encoding.UTF8.GetString(ms.ToArray());
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    RSA.SavePrivateKeyToPEM(Key, ms);
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

        private async Task Load()
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.FileTypeFilter.Add(".pem");

            WinRT.Interop.InitializeWithWindow.Initialize(picker, MainWindow.WindowHandle);

            StorageFile file = await picker.PickSingleFileAsync();
        }

        private async Task SavePublicKey()
        {
            FileSavePicker picker = new FileSavePicker();
            picker.FileTypeChoices.Add("PEM file", new List<string> { ".pem" });
            WinRT.Interop.InitializeWithWindow.Initialize(picker, MainWindow.WindowHandle);

            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                RSA.SavePublicKeyToPEM(Key, file.Path);

                MessageBoxContentDialog dialog = new MessageBoxContentDialog
                {
                    XamlRoot = XamlRoot,
                    Message = "Public key saved !"
                };
                await dialog.ShowAsync();
            }
        }

        private async Task SavePrivateKey()
        {
            SaveKeyContentDialog dialog = new SaveKeyContentDialog { XamlRoot = XamlRoot };
            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                bool encrypt = dialog.EncryptWithPassword;
                string password = dialog.Password;

                FileSavePicker picker = new FileSavePicker();
                picker.FileTypeChoices.Add("PEM file", new List<string> { ".pem" });

                WinRT.Interop.InitializeWithWindow.Initialize(picker, MainWindow.WindowHandle);

                StorageFile file = await picker.PickSaveFileAsync();
                if (file != null)
                {
                    if (encrypt)
                        RSA.SavePrivateKeyToPEM(Key, file.Path, password);
                    else
                        RSA.SavePrivateKeyToPEM(Key, file.Path);
                }
            }
        }

        #endregion
    }
}
