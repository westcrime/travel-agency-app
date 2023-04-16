using TravelAgencyApp.Views;

namespace TravelAgencyApp.UserControl;

public partial class FlyoutFooterControl : ContentView
{
    public FlyoutFooterControl()
    {
        InitializeComponent();
        BindingContext = this;
        if (App.userId != null)
        {
            EmailLbl.Text = "Logged in as " + App.userId.Email;

        }
    }

}