using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.ClientSave;

namespace Epr3.ViewModels
{
    public partial class ClientSaveViewModel : ObservableObject
    {
        private readonly IClientSaveService _clientService;

        [ObservableProperty]
        private CatalogClientModel _client;

        public ClientSaveViewModel(IClientSaveService clientService)
        {
            _clientService = clientService;
        }
        
        [RelayCommand]
        private async Task ClientSaveAsync()
        {
            await _clientService.ClientSaveAsync(Client);
        }
    }
}