using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Application.Abstractions;
using TravelAgencyApp.Models;
using TravelAgencyApp.Services;

namespace TravelAgencyApp.ViewModels
{
    [QueryProperty("CurrentTour", "CurrentTour")]
    public partial class DetailTourViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Tour currentTour;

        private readonly IUserService _userService;

        private readonly ITourService _tourService;

        public DetailTourViewModel(IUserService userService, ITourService tourService)
        {
            _tourService = tourService;
            _userService = userService;
        }

        [RelayCommand]
        private async void TourToBasket()
        {
            foreach (var tour in App.CurrentUser.ReservationBook)
            {
                if (tour == CurrentTour.Id)
                {
                    return;
                }
            }
            App.CurrentUser.ReservationBook.Add(CurrentTour.Id);
            await _userService.AddAsync(App.CurrentUser);
            await App.Current.MainPage.DisplayAlert("Success!", "Tour added to your basket.", "OK");
        }
    }
}
