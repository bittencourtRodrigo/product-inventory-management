using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.CatalogClient;
using Epr3.Services.Navigation;
using Epr3.Views;
using System.Collections.ObjectModel;

namespace Epr3.ViewModels
{
    public partial class CatalogClientViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ICatalogClientService _catalogClientService;


        [ObservableProperty]
        ObservableCollection<CatalogClientModel> _clientList;

        public CatalogClientViewModel(INavigationService navigationService, ICatalogClientService catalogClientService)
        {
            _navigationService = navigationService;
            _catalogClientService = catalogClientService;
            ClientGetAll();
        }

        [RelayCommand]
        private async Task ClientEditAsync(CatalogClientModel catalogClient = null)
        {
            await _navigationService.NavigateToAsync(
                nameof(ClientSaveView),
                new Dictionary<string, object>() { { nameof(catalogClient), catalogClient } });
        }

        private async void ClientGetAll()
        {
            ClientList = new ObservableCollection<CatalogClientModel>(await _catalogClientService.ClientGetAll());
        }
    }
}