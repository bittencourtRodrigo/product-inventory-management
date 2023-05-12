using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.Client;

namespace Epr3.ViewModels
{
    public partial class ClientSaveViewModel : ObservableObject
    {
        private readonly IClientService _clientService;

        [ObservableProperty]
        private ClientCatalog _client;

        public ClientSaveViewModel(IClientService clientService)
        {
            _clientService = clientService;
            
        }
        
        [RelayCommand]
        private void SaveClient()
        {
            _clientService.ClientSave(Client);
        }
    }
}