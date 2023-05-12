using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Epr3.ViewModels
{
    public partial class ClientSaveViewModel : ObservableObject
    {
        private readonly IClientService _clientService;

        [ObservableProperty]
        private Client _client;

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