using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoUtils.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;

namespace CryptoUtils.ViewModels.Controls
{
    public class EncDecViewModel : ObservableObject
    {
        #region Commands

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

        private async Task AddFiles()
        {

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
            
        }

        #endregion
    }
}
