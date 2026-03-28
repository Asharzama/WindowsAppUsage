using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WindowsAppUsage.Models
{
    public partial class AppUsageModel : ObservableObject
    {
        [ObservableProperty]
        private string appName;

        [ObservableProperty]
        private TimeSpan usageTime;
    }
}
