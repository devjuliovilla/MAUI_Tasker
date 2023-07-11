using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
    public NewTaskView()
    {
        InitializeComponent();
    }

    private async void addTaskButton_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        var selectedCategory = vm.Categories
            .Where(x => x.IsSelected)
            .FirstOrDefault();

        if (selectedCategory != null)
        {
            vm.Tasks.Add(new MyTask
            {
                TaskName = vm.Task,
                CategoryId = selectedCategory.Id
            });
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Alert", "You must select a category to continue", "Ok");
        }
    }

    private async void addCategoryButton_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        string categoryName = await DisplayPromptAsync("Add new Category",
            "Enter category name",
            maxLength: 15,
            keyboard: Keyboard.Text);

        var rand = new Random();

        if (!String.IsNullOrEmpty(categoryName))
        {
            vm.Categories.Add(new Category
            {
                Id = vm.Categories.Max(x => x.Id) + 1,
                CategoryName = categoryName,
                IsSelected = true,
                Color = Color.FromRgb(
                rand.Next(0, 255),
                rand.Next(0, 255),
                rand.Next(0, 255)).ToHex()
            });
        }
    }
}