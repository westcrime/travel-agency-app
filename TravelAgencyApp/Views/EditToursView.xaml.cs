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
    private async void EditToursView_NavigatedTo(object sender, EventArgs e)
    {
        await viewModel.GetToursAsync();
    }

}
