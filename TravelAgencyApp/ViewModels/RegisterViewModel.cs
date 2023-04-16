using Firebase.Auth;
using Microsoft.Maui.ApplicationModel.Communication;
using System.ComponentModel;
//using FireSharp.Config;
using TravelAgencyApp.Data;
using TravelAgencyApp.Exceptions;
using TravelAgencyApp.UserControl;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public Command RegisterUser { get; set; }
        public Command BackToLogin { get; set; }
        private string email;
        private string password;

        public RegisterViewModel() 
        {
            RegisterUser = new Command(RegisterUserTappedAsync);
            BackToLogin = new Command(BackToLoginTappedAsync);
        }

        private async void BackToLoginTappedAsync(object obj)
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }


        public string UserEmail
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("UserEmail");
            }
        }

        public string UserPassword
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                var auth = await App.authProvider.CreateUserWithEmailAndPasswordAsync(UserEmail, UserPassword);
                string token = auth.FirebaseToken;
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Success!", "User Registered successfully", "OK");
                var auth1 = await App.authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                if (Preferences.ContainsKey("UserEmail") ||
                    Preferences.ContainsKey("UserPassword"))
                {
                    Preferences.Remove("UserEmail");
                    Preferences.Remove("UserPassword");
                }
                Preferences.Set("UserEmail", UserEmail);
                Preferences.Set("UserPassword", UserPassword);
                App.userId.Email = UserEmail;
                App.userId.Password = UserPassword;
                App.firebase.AddUserAsync(App.userId);
                MenuShell.Current.FlyoutFooter = new FlyoutFooterControl();

                await Shell.Current.GoToAsync($"//{nameof(ProfileView)}");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}
