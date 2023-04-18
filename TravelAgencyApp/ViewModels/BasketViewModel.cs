using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.ViewModels
{
    public partial class BasketViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Tour> basketTours;

        [ObservableProperty] 
        public string cost;

        public BasketViewModel()
        {
            cost = "0$";
            BasketTours = new ObservableCollection<Tour>();
            var tours = new List<Tour>();
            foreach (var tour in App.ToursInBasket)
            {
                basketTours.Add(tour);
            }
        }

        public void UpdateBasket()
        {
            BasketTours = new ObservableCollection<Tour>();
            foreach (var tour in App.ToursInBasket)
            {
                BasketTours.Add(tour);
            }
            double _cost = 0;
            foreach (var tour in BasketTours)
            {
                _cost += Convert.ToDouble(tour.Price.Remove(tour.Price.Length - 1, 1));
            }
            Cost = _cost.ToString() + '$';
        }
        [RelayCommand]
        private async void DeleteTour(Tour obj)
        {
            BasketTours.Remove(obj);
            App.ToursInBasket.Remove(obj);
            this.UpdateBasket();
        }
    }
}
