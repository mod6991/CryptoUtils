using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUtils.Models
{
    public interface IProgression
    {
        bool IsIndeterminate { get; set; }
        double ProgressValue { get; set; }
        string ProgressText { get; set; }
    }
}
