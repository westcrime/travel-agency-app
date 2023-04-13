using Firebase.Auth;
using Microsoft.Maui.ApplicationModel.Communication;
using System.ComponentModel;
//using FireSharp.Config;
using TravelAgencyApp.Data;
using TravelAgencyApp.Exceptions;

namespace TravelAgencyApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public string webApiKey = "AIzaSyC0spDZvY5wOLonDHlgZdWxqdNjjmbaNw8";
        private INavigation _navigation;
        public Command RegisterUser { get; set; }
        private string email;
        private string password;

        public RegisterViewModel(INavigation navigation) 
        {
            this._navigation = navigation;
            RegisterUser = new Command(RegisterUserTappedAsync);
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
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserEmail, UserPassword);
                string token = auth.FirebaseToken;
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Success!", "User Registered successfully", "OK");
                await this._navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}
