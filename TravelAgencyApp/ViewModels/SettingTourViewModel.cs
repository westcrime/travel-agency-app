using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.ViewModels
{
    [QueryProperty(nameof(Tour), "Tour")]
    public partial class SettingTourViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Tour tour;


    }
}
