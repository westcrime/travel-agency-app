using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class MainMenu : ContentPage
{
	public MainMenuViewModel viewModel;
	public MainMenu()
	{
		InitializeComponent();
		viewModel = new MainMenuViewModel(Navigation);
        BindingContext = viewModel;
    }
}