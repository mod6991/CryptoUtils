using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoUtils.Models;
using CryptoUtils.Views.Dialogs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace CryptoUtils.ViewModels
{
    public class EncDecFilesViewModel : ObservableObject
    {
        #region Constructor

        public EncDecFilesViewModel()
        {
            EncryptionTypes.Add(new EncryptionTypeItem { Type = EncryptionType.AES });
            EncryptionTypes.Add(new EncryptionTypeItem { Type = EncryptionType.ChaChaAES });
            SelectedEncryptionType = EncryptionTypes.First(x => x.Type == EncryptionType.ChaChaAES);

            KeySources.Add(new EncryptionKeySourceItem { KeySource = EncryptionKeySource.RSA });
            KeySources.Add(new EncryptionKeySourceItem { KeySource = EncryptionKeySource.Password });
            SelectedKeySource = KeySources.First(x => x.KeySource == EncryptionKeySource.RSA);
        }

        #endregion

        #region Commands

        private ICommand _encryptCommand;
        public ICommand EncryptCommand => _encryptCommand ??= new AsyncRelayCommand(Encrypt); //() => 

        private ICommand _decryptCommand;
        public ICommand DecryptCommand => _decryptCommand ??= new AsyncRelayCommand(Decrypt);

        private ICommand _addFilesCommand;
        public ICommand AddFilesCommand => _addFilesCommand ??= new AsyncRelayCommand(AddFiles);

        private ICommand _removeFilesCommand;
        public ICommand RemoveFilesCommand => _removeFilesCommand ??= new RelayCommand<string>(RemoveFiles);

        private ICommand _clearFilesCommand;
        public ICommand ClearFilesCommand => _clearFilesCommand ??= new RelayCommand(ClearFiles);

        private ICommand _setOutputCommand;
        public ICommand SetOutputCommand => _setOutputCommand ??= new AsyncRelayCommand(SetOutput);

        #endregion

        #region Properties

        public XamlRoot XamlRoot { get; set; }

        private ObservableCollection<EncryptionTypeItem> _encryptionTypes;
        public ObservableCollection<EncryptionTypeItem> EncryptionTypes
        {
            get => _encryptionTypes ??= new ObservableCollection<EncryptionTypeItem>();
            set => SetProperty(ref _encryptionTypes, value);
        }

        private EncryptionTypeItem _selectedEncryptionType;
        public EncryptionTypeItem SelectedEncryptionType
        {
            get => _selectedEncryptionType;
            set => SetProperty(ref _selectedEncryptionType, value);
        }

        private ObservableCollection<EncryptionKeySourceItem> _keySources;
        public ObservableCollection<EncryptionKeySourceItem> KeySources
        {
            get => _keySources ??= new ObservableCollection<EncryptionKeySourceItem>();
            set => SetProperty(ref _keySources, value);
        }

        private EncryptionKeySourceItem _selectedKeySource;
        public EncryptionKeySourceItem SelectedKeySource
        {
            get => _selectedKeySource;
            set => SetProperty(ref _selectedKeySource, value);
        }

        private ObservableCollection<string> _inputFiles;
        public ObservableCollection<string> InputFiles
        {
            get => _inputFiles ??= new ObservableCollection<string>();
            set => SetProperty(ref _inputFiles, value);
        }

        private string _output;
        public string Output
        {
            get => _output;
            set => SetProperty(ref _output, value);
        }

        #endregion

        #region Methods

        private async Task Encrypt()
        {
            ProgressionDialog dialog = new ProgressionDialog { XamlRoot = XamlRoot };
            dialog.IsIndeterminate = false;
            dialog.ProgressText = "Computing...";
            dialog.ProgressValue = 12.55;
            dialog.Action = async (dialog) =>
            {
                for (int i = 0; i < 101; i++)
                {
                    await Task.Delay(20);
                    dialog.ProgressValue = i;
                }
            };

            await dialog.ShowAsync();
        }

        private async Task Decrypt()
        {

        }

        private async Task AddFiles()
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.FileTypeFilter.Add("*");

            WinRT.Interop.InitializeWithWindow.Initialize(picker, MainWindow.WindowHandle);

            IReadOnlyList<IStorageFile> files = await picker.PickMultipleFilesAsync();

            if (files != null)
            {
                foreach (IStorageFile file in files)
                {
                    if (file.IsOfType(StorageItemTypes.File) && !InputFiles.Contains(file.Path))
                        InputFiles.Add(file.Path);
                }
            }
        }

        private void RemoveFiles(string file)
        {
            InputFiles.Remove(file);
        }

        private void ClearFiles()
        {
            InputFiles.Clear();
        }

        private async Task SetOutput()
        {
            FolderPicker picker = new FolderPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.FileTypeFilter.Add("*");

            WinRT.Interop.InitializeWithWindow.Initialize(picker, MainWindow.WindowHandle);

            StorageFolder folder = await picker.PickSingleFolderAsync();

            if (folder != null)
                Output = folder.Path;
        }

        #endregion
    }
}
