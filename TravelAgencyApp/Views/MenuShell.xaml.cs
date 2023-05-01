using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class MenuShell : Shell
{
    public MenuShell()
    {
        InitializeComponent();
        BindingContext = new MenuShellViewModel();
        Routing.RegisterRoute(nameof(DetailTourView), typeof(DetailTourView));
        Routing.RegisterRoute(nameof(EditToursView), typeof(EditToursView));
        Routing.RegisterRoute(nameof(SettingTourView), typeof(SettingTourView));
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        Routing.RegisterRoute(nameof(RegisterPageView), typeof(RegisterPageView));
    }
}