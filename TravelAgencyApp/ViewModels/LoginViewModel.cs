using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [RelayCommand]
        private async void Register(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPageView)}");
        }

        [RelayCommand]
        private async void Login(object obj)
        {
            try
            {
                var auth = await App.authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                App.User.Email = UserEmail;
                App.User.Password = UserPassword;
                await Shell.Current.GoToAsync($"//{nameof(ProfileView)}");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        [ObservableProperty]
        public string userEmail;

        [ObservableProperty]
        public string userPassword;
        public LoginViewModel()
        {
            UserEmail = "admin@admin.com";
            UserPassword = "123123";
        }
    }
}