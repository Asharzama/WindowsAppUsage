using WindowsAppUsage.ViewModels;

namespace WindowsAppUsage
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }

}
