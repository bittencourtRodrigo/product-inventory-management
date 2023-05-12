using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epr3.ViewModels
{
    public partial class CatalogClientViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        ObservableCollection<CatalogClientModel> _clientList;

        public CatalogClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task ClientEdit(CatalogClientModel catalogClient = null)
        {
            await _navigationService.NavigateToAsync(
                nameof(ClientSaveView),
                new Dictionary<string, object>() { { nameof(catalogClient.Id), catalogClient } });
        }
    }
}