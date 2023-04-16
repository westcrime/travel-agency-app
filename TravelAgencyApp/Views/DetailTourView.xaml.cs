using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class DetailTourView : ContentPage
{
    public DetailTourView(MainMenuViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}