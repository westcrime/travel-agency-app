using Acr.UserDialogs;
using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
#if WINDOWS
        Border.WidthRequest = 450;
#endif
    }
}