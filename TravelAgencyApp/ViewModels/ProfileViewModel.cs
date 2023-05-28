using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Application.Abstractions;
using TravelAgencyApp.Services;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        private readonly ITourService _tourService;

        public ProfileViewModel(IUserService userService, ITourService tourService)
        {
            _tourService = tourService;
            _userService = userService;
            Balance = App.CurrentUser.Balance.ToString() + '$';
            UserEmail = App.CurrentUser.Email;
            UserPassword = "********";
        }

        [ObservableProperty]
        public string userEmail;
        
        [ObservableProperty]
        public string userPassword;
        
        [ObservableProperty]
        public string balance;

        [RelayCommand]
        private async void PutMoneyOnBalance()
        {
            try
            {
                string result = await App.Current.MainPage.DisplayPromptAsync("Putting money on balance", "Enter the value of operation");
                if (!string.IsNullOrEmpty(result))
                {
                    IsBusy = true;
                    double value = Convert.ToDouble(result);
                    if (value <= 0)
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Incorrect value!", "OK");
                    }
                    else
                    {
                        App.CurrentUser.Balance += value;
                        await _userService.AddAsync(App.CurrentUser);
                        Balance = App.CurrentUser.Balance.ToString() + '$';
                    }
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async void ChangePassword()
        {
            try
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Alert", "Do you really want to change password?", "Yes", "No");
                IsBusy = true;
                if (answer)
                {
                    await _userService.AuthProvider.SendPasswordResetEmailAsync(App.CurrentUser.Email);
                    await App.Current.MainPage.DisplayAlert("Warning", "We have sent reset email message with password changing. Check it", "OK");
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async void LogOut()
        {
            try
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Alert", "Do you really want to log out?", "Yes", "No");
                IsBusy = true;
                if (answer)
                {
                    App.CurrentUser = null;
                    Preferences.Clear("AuthToken");
                    await Shell.Current.GoToAsync($"//{nameof(LoginView)}", true);
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        [RelayCommand]
        private async void ChangeEmail()
        {
            try
            {
                string result = await App.Current.MainPage.DisplayPromptAsync("Changing Email", "Enter new Email");
                IsBusy = true;
                if (!string.IsNullOrEmpty(result))
                {
                    await _userService.AuthProvider.ChangeUserEmail(Preferences.Get("AuthToken", "no token"), result);
                    App.CurrentUser.Email = result;
                    await _userService.AddAsync(App.CurrentUser);
                    UserEmail = App.CurrentUser.Email;
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task Update()
        {
            await Task.Run(() =>
            {
                IsBusy = true;
                Balance = App.CurrentUser.Balance.ToString() + '$';
                UserEmail = App.CurrentUser.Email;
                IsBusy = false;
            });
        }
        
    }
}

