using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.ViewModels;

namespace TravelAgencyApp.Views;

public partial class SettingTourView : ContentPage
{
    private SettingTourViewModel settingTourViewModel;
    public SettingTourView(SettingTourViewModel settingTourViewModel)
    {
        InitializeComponent();
        this.settingTourViewModel = settingTourViewModel;
        BindingContext = settingTourViewModel;
    }
}