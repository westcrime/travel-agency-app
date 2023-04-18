using System.Collections.ObjectModel;
using Acr.UserDialogs;
using Firebase.Auth;
using TravelAgencyApp.Models;
using TravelAgencyApp.Views;
using TravelAgencyApp.Data;

namespace TravelAgencyApp;

public partial class App : Application
{
    public static Models.User User;
    public static ObservableCollection<Tour> ToursInBasket;

    private string webApiKey = "AIzaSyC0spDZvY5wOLonDHlgZdWxqdNjjmbaNw8";
    public static FirebaseAuthProvider authProvider;
    public static FireBaseService firebase;
    public App()
    {
        ToursInBasket = new ObservableCollection<Tour>();
        User = new Models.User();
        authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        firebase = new FireBaseService();
        InitializeComponent();
        MainPage = new MenuShell();
    }
}
