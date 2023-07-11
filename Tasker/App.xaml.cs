using Tasker.MVVM.Views;

namespace Tasker;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        UserAppTheme = AppTheme.Dark;
        MainPage = new NavigationPage(new MainView());
    }

}