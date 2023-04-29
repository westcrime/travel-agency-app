using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using TravelAgencyApp.Models;
using TravelAgencyApp.Services;

namespace TravelAgencyApp.ViewModels
{
    [QueryProperty(nameof(Tour), "Tour")]
    public partial class SettingTourViewModel : BaseViewModel
    {
        [ObservableProperty] private Tour tour;

        [ObservableProperty] private string name;

        [ObservableProperty] private string description;

        [ObservableProperty] private string price;

        [ObservableProperty] private string picture;

        private DatabaseService databaseService;

        public SettingTourViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
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
                    if (Tour != null)
                    {
                        await ChangeTour(Tour, Name, Description, Price, Picture);
                    }
                    else
                    {
                        await AddTour(new Models.Tour(Name, Price, Description, Picture));
                    }
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
            await databaseService.AddTourAsync(tourForAdding);
        }

        private async Task ChangeTour(Tour tourForChanging, string name, string description, string price, string picture)
        {
            tourForChanging.Name = name;
            tourForChanging.Description = description;
            tourForChanging.Price = price;
            tourForChanging.Picture = picture;
            await databaseService.RemoveTourAsync(tourForChanging);
            await databaseService.AddTourAsync(tourForChanging);
        }
    }
}
