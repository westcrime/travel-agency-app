using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class AuthenticationView : ContentPage
{
    public AuthenticationView(AuthenticationViewModel authentication)
    {
        InitializeComponent();
        BindingContext = authentication;
#if WINDOWS
        border.WidthRequest = 450;
#endif
    }
}