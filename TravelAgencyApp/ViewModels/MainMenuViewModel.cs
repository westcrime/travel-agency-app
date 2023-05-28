using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Application.Abstractions;
using TravelAgencyApp.Models;
using TravelAgencyApp.Services;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class MainMenuViewModel : BaseViewModel
    {
        public ObservableCollection<Tour> Tours { get; } = new();

        [ObservableProperty]
        private Tour selectedTour;

        private Models.User user;

        [ObservableProperty] private bool editBtnIsVisible = false;

        private readonly IUserService _userService;

        private readonly ITourService _tourService;

        public MainMenuViewModel(IUserService userService, ITourService tourService)
        {
            _tourService = tourService;
            _userService = userService;
            if (App.CurrentUser.Email.Equals("admin@admin.com"))
            {
                EditBtnIsVisible = true;
            }
        }

        public async Task GetToursAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var tours = await _tourService.GetAllAsync();

                if (Tours.Count != 0)
                    Tours.Clear();

                if(tours == null)
                    return;

                foreach (var tour in tours)
                    Tours.Add(tour);
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

        [RelayCommand]  
        private async void EditToursClicked()
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(EditToursView), true);
            IsBusy = false;
        }

    }
}
