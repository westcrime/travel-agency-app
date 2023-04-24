using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Services;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        DatabaseService databaseService;
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
                var auth = await App.authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                App.User = await this.databaseService.GetUserAsync(auth.User.LocalId);
                await Shell.Current.GoToAsync($"//{nameof(ProfileView)}", true);
                IsBusy = false;
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
        public LoginViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            UserEmail = "admin@admin.com";
            UserPassword = "123123";
        }
    }
}