using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.ClientSave;

namespace Epr3.ViewModels
{
    public partial class ClientSaveViewModel : ObservableObject
    {
        private readonly IClientSaveService _clientSaveService;

        [ObservableProperty]
        private CatalogClientModel _client;

        public ClientSaveViewModel(IClientSaveService clientService)
        {
            _clientSaveService = clientService;
            _client = new CatalogClientModel();
        }
        
        [RelayCommand]
        private async Task ClientSaveAsync()
        {
            if (Client.Name == null || Client.RegisterPerson == null)
            {
                await App.Current.MainPage.DisplayAlert("Alert", $"{nameof(Client.Name)} and {nameof(Client.RegisterPerson)} cannot be empyt.", "CLose");
                return;
            }
            await _clientSaveService.ClientSaveAsync(Client);
        }
    }
}