using Firebase.Auth;
using Newtonsoft.Json;
using System.ComponentModel;
using TravelAgencyApp.UserControl;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public class AuthenticationViewModel : INotifyPropertyChanged
    {
        
        private string userEmail;
        private string userPassword;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        public string UserEmail
        {
            get => userEmail; set
            {
                userEmail = value;
                RaisePropertyChanged("UserEmail");
            }
        }

        public string UserPassword
        {
            get => userPassword; set
            {
                userPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        public AuthenticationViewModel()
        {
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }

        private async void LoginBtnTappedAsync(object obj)
        {

            
            try
            {
                var auth = await App.authProvider.SignInWithEmailAndPasswordAsync(userEmail, UserPassword);
                if (Preferences.ContainsKey("UserEmail") ||
                    Preferences.ContainsKey("UserPassword"))
                {
                    Preferences.Remove("UserEmail");
                    Preferences.Remove("UserPassword");
                }
                Preferences.Set("UserEmail", UserEmail);
                Preferences.Set("UserPassword", userPassword);
                App.userId.Email = UserEmail;
                App.userId.Password = userPassword;
                MenuShell.Current.FlyoutFooter = new FlyoutFooterControl();

                await Shell.Current.GoToAsync($"//{nameof(ProfileView)}");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }


        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPageView)}");
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}