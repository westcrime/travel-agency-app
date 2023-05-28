using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Application.Abstractions;
using TravelAgencyApp.Services;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        private readonly ITourService _tourService;

        public LoginViewModel(IUserService userService, ITourService tourService)
        {
            _tourService = tourService;
            _userService = userService;
            UserEmail = "admin@admin.com";
            UserPassword = "123123";
        }
        
        [RelayCommand]
        private async void Register(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPageView)}", true);
        }

        [RelayCommand]
        private async void Login(object obj)
        {
            try
            {
                IsBusy = true;
                var auth = await _userService.AuthProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                Preferences.Set("AuthToken", auth.FirebaseToken);
                App.CurrentUser = await _userService.GetAsync(auth.User.LocalId);
                await Shell.Current.GoToAsync($"//{nameof(MainMenu)}", true);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ObservableProperty]
        public string userEmail;

        [ObservableProperty]
        public string userPassword;
    }
}