using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Services;

namespace TravelAgencyApp.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private DatabaseService databaseService;

        [ObservableProperty]
        public string userEmail;

        [RelayCommand]
        private async void ChangeEmail()
        {
            try
            {
                string result = await App.Current.MainPage.DisplayPromptAsync("Changing Email", "Enter new Email");
                IsBusy = true;
                if (result != string.Empty)
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

        public ProfileViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            UserEmail = App.User.Email;
        }
    }
}

