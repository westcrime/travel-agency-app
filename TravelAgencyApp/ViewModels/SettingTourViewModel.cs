using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Application.Abstractions;
using TravelAgencyApp.Models;
using TravelAgencyApp.Services;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    [QueryProperty(nameof(Tour), "CurrentTour")]
    public partial class SettingTourViewModel : BaseViewModel
    {
        [ObservableProperty] private Tour currentTour;

        [ObservableProperty] private string name;

        [ObservableProperty] private string description;

        [ObservableProperty] private string price;

        [ObservableProperty] private string picture;

        private readonly IUserService _userService;

        private readonly ITourService _tourService;

        public SettingTourViewModel(IUserService userService, ITourService tourService)
        {
            _tourService = tourService;
            _userService = userService;
        }

        [RelayCommand]
        private async void Confirm()
        {
            IsBusy = true;
            try
            {
                if (Name != string.Empty || Price != string.Empty || Description != string.Empty ||
                    Picture != string.Empty)
                {
                    if (CurrentTour != null)
                    {
                        await ChangeTour(CurrentTour, Name, Description, Price, Picture);
                    }
                    else
                    {
                        await AddTour(new Models.Tour(Name, Price, Description, Picture));
                    }

                    await Shell.Current.GoToAsync("..", true);
                }
            }
            catch (Exception e)
            {

                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task AddTour(Tour tourForAdding)
        {
            await _tourService.AddAsync(tourForAdding);
        }

        private async Task ChangeTour(Tour tourForChanging, string name, string description, string price, string picture)
        {
            tourForChanging.Name = name;
            tourForChanging.Description = description;
            tourForChanging.Price = price;
            tourForChanging.Picture = picture;
            await _tourService.DeleteAsync(tourForChanging);
            await _tourService.AddAsync(tourForChanging);
        }
    }
}
