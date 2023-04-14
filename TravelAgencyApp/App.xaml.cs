using TravelAgencyApp.Models;
using TravelAgencyApp.Views;

namespace TravelAgencyApp;

public partial class App : Application
{
	public static UserID User;
	public App()
	{
		InitializeComponent();
		User = new UserID();
		MainPage = new MenuShell();
		
	}
}
