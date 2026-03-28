using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using WindowsAppUsage.Models;
using System.Timers;
#if WINDOWS
using WindowsAppUsage.Platforms.Windows;
#endif

namespace WindowsAppUsage.Services
{
    public class AppUsageService
    {
        public ObservableCollection<AppUsageModel> Usages { get; set; } = new();

        private string currentApp = "";
        private DateTime startTime;
        private readonly Timer timer;

        public AppUsageService()
        {
            timer = new Timer(1000);
            timer.Elapsed += CheckApp;
            timer.Start();
        }

        private void CheckApp(object sender, ElapsedEventArgs e)
        {
#if WINDOWS
        string active = ForegroundTracker.GetActiveApp();

        if (string.IsNullOrEmpty(currentApp))
        {
            currentApp = active;
            startTime = DateTime.Now;
            return;
        }

        if (currentApp != active)
        {
            var duration = DateTime.Now - startTime;
            UpdateUsage(currentApp, duration);

            currentApp = active;
            startTime = DateTime.Now;
        }
#endif
        }

        private void UpdateUsage(string app, TimeSpan duration)
        {
            var existing = Usages.FirstOrDefault(x => x.AppName == app);

            if (existing == null)
            {
                AppUsageModel model = new()
                {
                    AppName = app,
                    UsageTime = duration
                };

                App.Current.Dispatcher.Dispatch(() => Usages.Add(model));
            }
            else
            {
                existing.UsageTime += duration;
            }
        }
    }
}
