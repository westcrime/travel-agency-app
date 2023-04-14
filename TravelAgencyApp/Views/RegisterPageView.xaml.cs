using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class RegisterPageView : ContentPage
{
	public RegisterPageView()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel();
#if WINDOWS
        border.WidthRequest = 450;
#endif
    }
}