﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Models;
using TravelAgencyApp.Services;

namespace TravelAgencyApp.ViewModels
{
    [QueryProperty(nameof(Tour), "Tour")]
    public partial class DetailTourViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Tour tour;

        private DatabaseService databaseService;

        public DetailTourViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        [RelayCommand]
        private async void TourToBasket()
        {
            foreach (var tour in App.User.ReservationBook)
            {
                if (tour == this.Tour.Id)
                {
                    return;
                }
            }
            App.User.ReservationBook.Add(this.Tour.Id);
            this.databaseService.AddUserAsync(App.User);
            await App.Current.MainPage.DisplayAlert("Success!", "Tour added to your basket.", "OK");
        }
    }
}