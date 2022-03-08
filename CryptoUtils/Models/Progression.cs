using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace CryptoUtils.Models
{
    public class Progression : ObservableObject, IProgression
    {
        private bool _isIndeterminate;
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

        private bool _isPercentageVisible;
        public bool IsPercentageVisible
        {
            get => _isPercentageVisible;
            set => SetProperty(ref _isPercentageVisible, value);
        }
    }
}
