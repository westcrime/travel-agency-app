using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class BasketView : ContentPage
{
    public BasketViewModel _viewModel;
    public BasketView(BasketViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;

    }

    private void BasketView_NavigatedTo(object sender, EventArgs e)
    {
        _viewModel.GetToursAsync();
    }
}