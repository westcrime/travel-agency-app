using TravelAgencyApp.Models;
using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class EditToursView : ContentPage
{
    private EditToursViewModel viewModel;
    public EditToursView(EditToursViewModel editToursViewModel)
    {
        InitializeComponent();
        this.viewModel = editToursViewModel;
        BindingContext = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await viewModel.GetToursAsync();

    }
}
