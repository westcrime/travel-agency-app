using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Models;
using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class DetailTourView : ContentPage
{
    private DetailTourViewModel detailTourViewModel;
    public DetailTourView(Tour SelectedTour)
    {
        InitializeComponent();
        detailTourViewModel = new DetailTourViewModel(SelectedTour);
        BindingContext = detailTourViewModel;
    }
}