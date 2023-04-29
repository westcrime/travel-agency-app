using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Models;
using TravelAgencyApp.Services;

namespace TravelAgencyApp.ViewModels
{
    public partial class BasketViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Tour> tours;

        [ObservableProperty] 
        public string cost;

        [ObservableProperty]
        public string balance;

        private DatabaseService databaseService;

        public BasketViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            Cost = "0$";
            Balance = "0$";
            Tours = new ObservableCollection<Tour>();
        }

        public async Task GetToursAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                if (Tours.Count != 0)
                    Tours.Clear();

                foreach (var tour in App.User.ReservationBook)
                {
                    Tours.Add(await this.databaseService.GetTourAsync(tour));
                }

                if (Tours == null)
                    return;

                Balance = App.User.Balance.ToString() + '$';

                double _cost = 0;

                foreach (var tour in Tours)
                {
                    _cost += Convert.ToDouble(tour.Price.Remove(tour.Price.Length - 1, 1));
                }
                Cost = _cost.ToString() + '$';
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
        private async void DeleteTour(Tour obj)
        {
            Tours.Remove(obj);
            App.User.ReservationBook.Remove(obj.Id);
            await databaseService.AddUserAsync(App.User);
        }
    }
}
