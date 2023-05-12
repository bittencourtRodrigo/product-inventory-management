using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Epr3.ViewModels
{
    public partial class ClientSaveViewModel : ObservableObject
    {
        private readonly IClientService _clientService;

        [ObservableProperty]
        private Client _clientList;

        [RelayCommand]
        void SaveClient()
        {
            _clientService.ClientSave(ClientList);
        }

        public ClientSaveViewModel(IClientService clientService)
        {
            _clientService = clientService;
            ClientList = new ClientList();
        }
    }
}
