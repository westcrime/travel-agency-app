using Acr.UserDialogs;
using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class AuthenticationView : ContentPage
{
    public AuthenticationView(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
#if WINDOWS
        Border.WidthRequest = 450;
#endif
    }
}