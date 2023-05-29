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

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await this.profileViewModel.Update();
    }

}