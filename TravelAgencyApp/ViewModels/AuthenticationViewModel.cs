using Firebase.Auth;
using Newtonsoft.Json;
using System.ComponentModel;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public class AuthenticationViewModel : INotifyPropertyChanged
    {
        public string webApiKey = "AIzaSyC0spDZvY5wOLonDHlgZdWxqdNjjmbaNw8";
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

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(userEmail, UserPassword);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                //Preferences.Set("UserEmail", UserEmail);
                //Preferences.Set("UserPassword", userPassword);
                App.User.Email = UserEmail;
                App.User.Password = UserPassword;
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