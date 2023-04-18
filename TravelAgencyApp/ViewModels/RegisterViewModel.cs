using Firebase.Auth;
using Microsoft.Maui.ApplicationModel.Communication;
using System.ComponentModel;
using Acr.UserDialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string userEmail;
        [ObservableProperty]
        private string userPassword;

        public RegisterViewModel() 
        {
        }
        [RelayCommand]
        private async void BackToLogin(object obj)
        {
            try
            {
                await Shell.Current.GoToAsync($"//{nameof(AuthenticationView)}");
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
                var auth = await App.authProvider.CreateUserWithEmailAndPasswordAsync(UserEmail, UserPassword);
                string token = auth.FirebaseToken;
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Success!", "User Registered successfully", "OK");
                var auth1 = await App.authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                App.User.Email = UserEmail;
                App.User.Password = UserPassword;

                await Shell.Current.GoToAsync($"//{nameof(MainMenu)}");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}
