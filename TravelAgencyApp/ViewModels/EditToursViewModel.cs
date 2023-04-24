using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        private DatabaseService databaseService;

        public EditToursViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            Tours = new ObservableCollection<Tour>();
        }
        public async Task GetToursAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var tours = await databaseService.GetToursAsync();

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
            Tours.Remove(tour);
            await databaseService.RemoveTourAsync(tour);
            if (App.User.ReservationBook.Contains(tour.Id))
            {
                App.User.ReservationBook.Remove(tour.Id);
                await databaseService.AddUserAsync(App.User);
            }

            App.NeedToRefreshTours = true;
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
            
        }
    }
}
