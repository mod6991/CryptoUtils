namespace CryptoUtils.Models
{
    public interface IProgression
    {
        bool IsIndeterminate { get; set; }
        double ProgressValue { get; set; }
        string ProgressText { get; set; }
        bool IsPercentageVisible { get; set; }
        bool AutoClose { get; set; }
        string CloseButtonTextWhenDone { get; set; }
        object ProgressionState { get; set; }
    }
}
