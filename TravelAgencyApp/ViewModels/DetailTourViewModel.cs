using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.ViewModels
{
    public partial class DetailTourViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Tour selectedTour;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private string price;
        [ObservableProperty]
        private string picture;
        public DetailTourViewModel(Tour _selectedTour)
        {
            selectedTour = _selectedTour;
            name = selectedTour.Name;
            description = selectedTour.Description;
            price = selectedTour.Price;
            picture = selectedTour.Picture;
        }
        [RelayCommand]
        private async void TourToBasket()
        {
            foreach (var _tour in App.ToursInBasket)
            {
                if (_tour.Id == selectedTour.Id)
                {
                    return;
                }
            }
            App.ToursInBasket.Add(selectedTour);
            Preferences.Set("NeedToRefreshBasket", "True");
            await App.Current.MainPage.DisplayAlert("Success!", "Tour added to your basket.", "OK");
        }
    }
}
