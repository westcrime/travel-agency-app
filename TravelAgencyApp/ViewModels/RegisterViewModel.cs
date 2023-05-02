using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        private DatabaseService databaseService;

        public RegisterViewModel(DatabaseService databaseService) 
        {
            this.databaseService = databaseService;
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
                var auth = await App.authProvider.CreateUserWithEmailAndPasswordAsync(UserEmail, UserPassword);
                string token = auth.FirebaseToken;
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Success!", "User Registered successfully", "OK");
                var auth1 = await App.authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                App.Token = auth1.FirebaseToken;
                App.User = new Models.User()
                {
                    Id = auth1.User.LocalId,
                    Email = UserEmail
                };
                await this.databaseService.AddUserAsync(App.User);
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
