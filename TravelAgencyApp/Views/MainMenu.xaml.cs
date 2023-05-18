using TravelAgencyApp.Models;
using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class MainMenu : ContentPage
{
    private MainMenuViewModel viewModel;
	public MainMenu(MainMenuViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await Task.Delay(250);
        await viewModel.GetToursAsync();

    }

    private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
    {
        var tour = ((VisualElement)sender).BindingContext as Tour;
        if (tour != null)
        {
            viewModel.IsBusy = true;
            await Shell.Current.GoToAsync(nameof(DetailTourView), true, new Dictionary<string, object>
            {
                { "Tour", tour }
            });
            viewModel.IsBusy = false;
        }
    }
}