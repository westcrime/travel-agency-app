using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Application.Abstractions;
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

        private readonly IUserService _userService;

        private readonly ITourService _tourService;

        public BasketViewModel(IUserService userService, ITourService tourService)
        {
            _tourService = tourService;
            _userService = userService;
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
                foreach (var tour in App.CurrentUser.ReservationBook)
                {
                    Tours.Add(await _tourService.GetAsync(tour));
                }

                if (Tours == null)
                    return;

                Balance = App.CurrentUser.Balance.ToString() + '$';

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
            IsBusy = true;
            Tours.Remove(obj);
            App.CurrentUser.ReservationBook.Remove(obj.Id);
            string cost = Cost.Remove(Cost.Length - 1);
            double newCost = Convert.ToDouble(cost) - Convert.ToDouble(obj.Price.Remove(obj.Price.Length - 1));
            Cost = newCost.ToString() + '$';
            await _userService.AddAsync(App.CurrentUser);
            IsBusy = false;
        }

        [RelayCommand]
        private async void Buy()
        {
            double cost = Convert.ToDouble(Cost.Remove(Cost.Length - 1));
            if (Convert.ToDouble(Balance.Remove(Balance.Length - 1)) < cost)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "You do not have enough money!", "OK");
                return;
            }
            else
            {
                string userId = (await _userService.AuthProvider.GetUserAsync(Preferences.Get("AuthToken", "No token"))).LocalId;
                var user = await _userService.GetAsync(userId);
                await Task.Run(() =>
                {
                    Tours.Clear();
                    user.ReservationBook.Clear();
                    user.Balance -= cost;
                    Balance = user.Balance.ToString() + '$';
                });
                await _userService.AddAsync(user);
                await App.Current.MainPage.DisplayAlert("Success!", "You have bought tour(s)!", "OK");
                Cost = "0$";
            }
        }
    }
}
