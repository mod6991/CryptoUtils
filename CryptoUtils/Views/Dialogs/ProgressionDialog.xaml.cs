using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CryptoUtils.Models;
using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views.Dialogs
{
    public sealed partial class ProgressionDialog : ContentDialog, IProgression, INotifyPropertyChanged
    {
        public ProgressionDialog()
        {
            InitializeComponent();

            Loaded += ProgressionDialog_Loaded;
        }

        private async void ProgressionDialog_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (Action != null)
                await Action(this);

            if (AutoClose)
                Hide();
            else
                CloseButtonText = CloseButtonTextWhenDone ?? "Close";
        }

        #region Properties

        private bool _isIndeterminate = false;
        public bool IsIndeterminate
        {
            get => _isIndeterminate;
            set => SetProperty(ref _isIndeterminate, value);
        }

        private double _progressValue;
        public double ProgressValue
        {
            get => _progressValue;
            set => SetProperty(ref _progressValue, value);
        }

        private string _progressText;
        public string ProgressText
        {
            get => _progressText;
            set => SetProperty(ref _progressText, value);
        }

        private bool _isPercentageVisible = true;
        public bool IsPercentageVisible
        {
            get => _isPercentageVisible;
            set => SetProperty(ref _isPercentageVisible, value);
        }

        public object ProgressionState { get; set; }

        public bool AutoClose { get; set; } = false;

        public string CloseButtonTextWhenDone { get; set; }

        public Func<IProgression, Task> Action { get; set; }

        #endregion

        #region INotifyPropertyChanged interface

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, newValue))
                return;

            field = newValue;
            OnPropertyChanged(propertyName);
        }

        #endregion
    }
}
