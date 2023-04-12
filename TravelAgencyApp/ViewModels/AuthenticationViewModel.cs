using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    class AuthenticationViewModel
    {
        private INavigation _navigation;
        public string webApiKey = "AIzaSyC0spDZvY5wOLonDHlgZdWxqdNjjmbaNw8";
        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }
        public AuthenticationViewModel(INavigation navigation) 
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }

        private async void LoginBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new MainMenuView());
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new RegisterPageView());
        }
    }
}
