using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class ProfileView : ContentPage
{
    private ProfileViewModel profileViewModel;
	public ProfileView(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
		this.profileViewModel = profileViewModel;
        BindingContext = profileViewModel;

    }

	private void ProfileView_OnNavigatedTo(object sender, NavigatedToEventArgs e)	
	{
		this.profileViewModel.Update();
	}
}