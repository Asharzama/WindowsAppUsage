using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsAppUsage.Models;
using WindowsAppUsage.Services;

namespace WindowsAppUsage.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<AppUsageModel> Apps { get; set; }

        public MainPageViewModel(AppUsageService service)
        {
            Apps = service.Usages;
        }
    }
}
