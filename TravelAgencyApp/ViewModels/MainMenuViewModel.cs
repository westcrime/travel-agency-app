using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Models;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public partial class MainMenuViewModel : BaseViewModel
    {
        public ObservableCollection<Tour> Tours { get; set; }
        [ObservableProperty]
        private Tour selectedTour;
        private INavigation navigation;


        public MainMenuViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            Tours = new ObservableCollection<Tour>();
        }

        public async Task LoadFromDatabase()
        {
            List<Tour> list = new List<Tour>();
            list = await App.firebase.GetToursAsync();
            Task.Run(() =>
            {
                foreach (var tour in list)
                {
                    Tours.Add(tour);
                }
            });
        }
        [RelayCommand]
        private async void TourClicked(Tour tour)
        {
            await Task.Run(() => SelectedTour = tour);
            await navigation.PushAsync(new DetailTourView(SelectedTour));
        }

    }
}
