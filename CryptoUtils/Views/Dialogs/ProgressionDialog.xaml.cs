using System;
using System.ComponentModel;
using System.Threading.Tasks;
using CryptoUtils.Models;
using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views.Dialogs
{
    public sealed partial class ProgressionDialog : ContentDialog, INotifyPropertyChanged
    {
        public ProgressionDialog()
        {
            InitializeComponent();

            Loaded += ProgressionDialog_Loaded;
        }

        private async void ProgressionDialog_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (Action != null)
                await Action(ProgressionObject);
            Hide();
        }

        private IProgression _progressionObject;

        public event PropertyChangedEventHandler PropertyChanged;

        public IProgression ProgressionObject
        {
            get => _progressionObject;
            set
            {
                _progressionObject = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProgressionObject)));
            }
        }

        public Func<IProgression, Task> Action { get; set; }
    }
}
