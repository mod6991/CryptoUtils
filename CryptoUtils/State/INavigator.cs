using CryptoUtils.ViewModels;
using System.Windows.Input;

namespace CryptoUtils.State
{
    internal interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
