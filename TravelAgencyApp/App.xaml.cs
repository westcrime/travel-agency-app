using Firebase.Auth;
using TravelAgencyApp.Models;
using TravelAgencyApp.Views;
using TravelAgencyApp.Data;

namespace TravelAgencyApp;

public partial class App : Application
{
    public static Models.User User;
    private string webApiKey = "AIzaSyC0spDZvY5wOLonDHlgZdWxqdNjjmbaNw8";
    public static string Token;
    public static FirebaseAuthProvider authProvider;
    public static FireBaseService firebase;
    public App()
    {
        authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        firebase = new FireBaseService();
        InitializeComponent();
        AddTours();
        AddTours();
        AddTours();
        MainPage = new MenuShell();
    }

    private async void AddTours()
    {
        Tour tour1 = new Tour()
        {
            Description =
                "Start in Rome and end in Milan! With the In-depth Cultural tour Discover Italy end Milan, you have a 7 days tour package taking you through Rome, Italy and 6 other destinations in Italy. Discover Italy end Milan includes accommodation in a hotel as well as an expert guide, insurance, meals, transport and more. ",
            Name = "Italy",
            Picture = "italy.jpg",
            Price = "999$"
        };
        Tour tour2 = new Tour()
        {
            Description =
                "Start and end in Cairo! With the In-depth Cultural tour Wonders of Egypt, you have a 9 days tour package taking you through Cairo, Egypt and 7 other destinations in Egypt. Wonders of Egypt includes accommodation in a hotel as well as flights, an expert guide, insurance, meals, transport and more. ",
            Name = "Egyptian pyramids",
            Picture = "pyramids.jpg",
            Price = "899$"
        };
        Tour tour3 = new Tour()
        {
            Description =
               "Start and end in Zurich! With the In-depth Cultural tour Country Roads of Switzerland (Classic, 14 Days), you have a 14 days tour package taking you through Zurich, Switzerland and 15 other destinations in Europe. Country Roads of Switzerland (Classic, 14 Days) includes accommodation in a hotel as well as an expert guide, meals, transport and more. ",
            Name = "Country Roads of Switzerland",
            Picture = "mountains.jpg",
            Price = "699$"
        };
        Tour tour4 = new Tour()
        {
            Description =
                "Start and end in Zurich! With the In-depth Cultural tour Country Roads of Switzerland (Classic, 14 Days), you have a 14 days tour package taking you through Zurich, Switzerland and 15 other destinations in Europe. Country Roads of Switzerland (Classic, 14 Days) includes accommodation in a hotel as well as an expert guide, meals, transport and more. ",
            Name = "Country Roads of Switzerland",
            Picture = "mountains.jpg",
            Price = "699$"
        };
        Tour tour5 = new Tour()
        {
            Description =
                "Start and end in Zurich! With the In-depth Cultural tour Country Roads of Switzerland (Classic, 14 Days), you have a 14 days tour package taking you through Zurich, Switzerland and 15 other destinations in Europe. Country Roads of Switzerland (Classic, 14 Days) includes accommodation in a hotel as well as an expert guide, meals, transport and more. ",
            Name = "Country Roads of Switzerland",
            Picture = "mountains.jpg",
            Price = "699$"
        };
        await App.firebase.AddTourAsync(tour1);
        await App.firebase.AddTourAsync(tour2);
        await App.firebase.AddTourAsync(tour3);
        await App.firebase.AddTourAsync(tour4);
        await App.firebase.AddTourAsync(tour5);
    }
}
