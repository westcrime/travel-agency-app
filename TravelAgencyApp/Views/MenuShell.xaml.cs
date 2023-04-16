using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class MenuShell : Shell
{
    public MenuShell()
    {
        InitializeComponent();
        BindingContext = new MenuShellViewModel();
    }
}