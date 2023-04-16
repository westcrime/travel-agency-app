using Firebase.Auth;
using TravelAgencyApp.Models;
using TravelAgencyApp.Views;
using TravelAgencyApp.Data;

namespace TravelAgencyApp;

public partial class App : Application
{
    public static Models.User userId;
    private string webApiKey = "AIzaSyC0spDZvY5wOLonDHlgZdWxqdNjjmbaNw8";
    public static FirebaseAuthProvider authProvider;
    public static FireBaseService firebase;
    public static List<Tour> ToursInBasketList;
    public App()
    {
        ToursInBasketList = new List<Tour>();
        authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        userId = new Models.User();
		InitializeComponent();
        firebase = new FireBaseService();
        MainPage = new MenuShell();
    }
}
