using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class MainView : ContentPage
{
	private MainViewModel mainViewModel = new MainViewModel();
    public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

    private void checkboxTask_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var newTaskView = new NewTaskView
        { 
            BindingContext=new NewTaskViewModel
            { 
                Tasks=mainViewModel.Tasks,
                Categories=mainViewModel.Categories
            }
        };

        Navigation.PushAsync(newTaskView);
    }
}