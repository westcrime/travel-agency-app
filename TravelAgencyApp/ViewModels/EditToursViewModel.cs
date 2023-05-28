using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Application.Abstractions;
using TravelAgencyApp.Models;
using TravelAgencyApp.Services;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class EditToursViewModel : BaseViewModel
    {
        [ObservableProperty] 
        public ObservableCollection<Tour> tours;

        [ObservableProperty]
        private Tour tour;

        private readonly IUserService _userService;

        private readonly ITourService _tourService;

        public EditToursViewModel(IUserService userService, ITourService tourService)
        {
            App.NeedToRefresh = true;
            _tourService = tourService;
            _userService = userService;
            Tours = new ObservableCollection<Tour>();
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

                if (tours == null)
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
        private async void DeleteTour(Tour tour)
        {
            IsBusy = true;
            Tours.Remove(tour);
            await _tourService.DeleteAsync(tour);
            if (App.CurrentUser.ReservationBook.Contains(tour.Id))
            {
                App.CurrentUser.ReservationBook.Remove(tour.Id);
                await _userService.AddAsync(App.CurrentUser);
            }

            IsBusy = false;
        }
        [RelayCommand]
        private async void EditTour(Tour tour)
        {
            await Shell.Current.GoToAsync(nameof(SettingTourView), true, new Dictionary<string, object>
            {
                { "Tour", tour }
            });
        }
        [RelayCommand]
        private async void AddTour()
        {
            await Shell.Current.GoToAsync(nameof(SettingTourView), true, new Dictionary<string, object>
            {
                { "Tour", null }
            });
        }
    }
}
