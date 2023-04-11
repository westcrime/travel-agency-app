using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class AuthenticationView : ContentPage
{
	public AuthenticationView()
	{
		InitializeComponent();
		BindingContext = new AuthenticationViewModel(Navigation);
	}
}