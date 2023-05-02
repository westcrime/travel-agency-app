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

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await Task.Delay(250);
        await _viewModel.GetToursAsync();

    }
}