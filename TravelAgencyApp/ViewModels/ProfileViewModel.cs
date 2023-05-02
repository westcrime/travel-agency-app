using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Services;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private DatabaseService databaseService;

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
                        App.User.Balance += value;
                        await this.databaseService.AddUserAsync(App.User);
                        this.Balance = App.User.Balance.ToString() + '$';
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
                    await App.authProvider.SendPasswordResetEmailAsync(App.User.Email);
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
                    App.User = null;
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
                    await App.authProvider.ChangeUserEmail(App.Token, result);
                    App.User.Email = result;
                    await databaseService.AddUserAsync(App.User);
                    UserEmail = App.User.Email;
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
                this.Balance = App.User.Balance.ToString() + '$';
                UserEmail = App.User.Email;
                IsBusy = false;
            });
        }
        
        public ProfileViewModel(DatabaseService databaseService)
        {
            this.Balance = App.User.Balance.ToString() + '$';
            UserEmail = App.User.Email;
            this.databaseService = databaseService;
            UserPassword = "********";
        }
    }
}

