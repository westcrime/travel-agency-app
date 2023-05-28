using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Application.Abstractions;
using TravelAgencyApp.Application.Services;
using TravelAgencyApp.Services;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string userEmail;

        [ObservableProperty]
        private string userPassword;

        private readonly IUserService _userService;

        private readonly ITourService _tourService;

        public RegisterViewModel(IUserService userService, ITourService tourService)
        {
            _tourService = tourService;
            _userService = userService;
        }

        [RelayCommand]
        private async void BackToLogin(object obj)
        {
            try
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
        [RelayCommand]
        private async void RegisterUser(object obj)
        {
            try
            {
                IsBusy = true;
                var auth = await _userService.AuthProvider.CreateUserWithEmailAndPasswordAsync(UserEmail, UserPassword);
                Preferences.Set("AuthToken", auth.FirebaseToken);
                if (!string.IsNullOrEmpty(auth.FirebaseToken))
                    await App.Current.MainPage.DisplayAlert("Success!", "User Registered successfully", "OK");
                var auth1 = await _userService.AuthProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                var user = new Models.User()
                {
                    Id = auth1.User.LocalId,
                    Email = UserEmail
                };
                await _userService.AddAsync(user);
                App.CurrentUser = user;
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
    }
}
