using CryptoUtils.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace CryptoUtils.State
{
    internal class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }
    }
}
