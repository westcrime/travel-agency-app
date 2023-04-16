using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TravelAgencyApp.Models;
using TravelAgencyApp.Views;

namespace TravelAgencyApp.ViewModels
{
    public class MainMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _text;
        public string Text
        {
            get => _text; set
            {
                _text = value;
                RaisePropertyChanged("Text");
            }
        }
        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        public ObservableCollection<Tour> Tours { get; set; }

        public ICommand TourClickedCommand { get; }
        public ICommand TourToBasketTapped { get; }
        public ICommand EditToursCommand { get; }
        private Tour selectedTour { get; set; }
        public Tour SelectedTour
        {
            get => selectedTour; set
            {
                selectedTour = value;
                RaisePropertyChanged("Text");
            }
        }
        private INavigation navigation;


        public MainMenuViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            _text = "Tour details";
            TourClickedCommand = new Command<Tour>(TourClickedCommandAsync);
            TourToBasketTapped = new Command<Tour>(TourToBasketTappedAsync);
            Tours = new ObservableCollection<Tour>()
            {
                new Tour()
                {
                    Description = "Awesome tour to Egypt",
                    Name = "Egyptian pyramids",
                    Picture = "pyramids.jpg",
                    Price = "899$"
                },
                new Tour()
                {
                    Description = "Awesome tour to Italy",
                    Name = "Italy",
                    Picture = "italy.jpg",
                    Price = "999$"
                },
                new Tour()
                {
                    Description = "Awesome tour to Egypt",
                    Name = "Egyptian pyramids",
                    Picture = "pyramids.jpg",
                    Price = "999$"
                },
                new Tour()
                {
                    Description = "Awesome tour to Egypt",
                    Name = "Egyptian pyramids",
                    Picture = "pyramids.jpg",
                    Price = "999$"
                },
                new Tour()
                {
                    Description = "Awesome tour to Egypt",
                    Name = "Egyptian pyramids",
                    Picture = "pyramids.jpg",
                    Price = "999$"
                },
            };
        }

        private async void TourClickedCommandAsync(Tour tour)
        {
            await Task.Run(() => SelectedTour = tour);
            await navigation.PushAsync(new DetailTourView(this));
        }

        private async void TourToBasketTappedAsync(Tour tour)
        {
            foreach (var _tour in App.ToursInBasketList)
            {
                if (_tour.Id == tour.Id)
                {
                    return;
                }
            }
            App.ToursInBasketList.Add(tour);
            await App.Current.MainPage.DisplayAlert("Success!", "Tour added to your basket.", "OK");
        }
    }
}
