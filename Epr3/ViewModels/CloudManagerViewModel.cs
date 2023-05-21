using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Data;
using Epr3.Models;
using Epr3.Services.Cloud;
using Epr3.Services.Navigation;
using Epr3.Services.ProductSave;
using Firebase.Auth;
using Firebase.Auth.Providers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Epr3.ViewModels
{
    public partial class CloudManagerViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IProductService _productService;
        private readonly ICloudService _cloudService;
        private FirebaseAuthClient _client;


        [ObservableProperty]
        string _emailUser;

        [ObservableProperty]
        string _password;



        public CloudManagerViewModel(INavigationService navigationService, IProductService productService, ICloudService cloudService)
        {
            _navigationService = navigationService;
            _productService = productService;
            _cloudService = cloudService;
        }

        [RelayCommand]
        private async Task UploadAsync()
        {
            try
            {
                await Login();
                await _productService.DefineUserIdAllProductsAsync(_client.User.Uid);
                string serialize = JsonSerializer.Serialize<List<CatalogProductModel>>(await _productService.ProductGetAllAsync());
                HttpResponseMessage status = await PostJson(serialize);
                await App.Current.MainPage.DisplayAlert("Alert", $"Finish. {status}", "Back");
            }
            catch (FirebaseAuthException e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "Back");
                return;
            }
        }

        [RelayCommand]
        private async Task DownloadAsync()
        {
            //HttpClient httpClient = new HttpClient();
            //HttpResponseMessage response = await httpClient.GetAsync(ApiConstants.ApiGetUri);
            //var serializer = await response.Content.ReadAsStringAsync();
            var serializer = "[{\"id\":6,\"uid\":\"HXalGtWgqbfDYtdzZCP7Y9S6z1D3\",\"barcode\":0,\"currentInventory\":0,\"storeLocation\":null,\"name\":\"Pa\",\"costPrice\":0,\"salePrice\":0,\"observation\":null},{\"id\":7,\"uid\":\"HXalGtWgqbfDYtdzZCP7Y9S6z1D3\",\"barcode\":0,\"currentInventory\":0,\"storeLocation\":null,\"name\":\"Tv\",\"costPrice\":0,\"salePrice\":0,\"observation\":null},{\"id\":8,\"uid\":\"HXalGtWgqbfDYtdzZCP7Y9S6z1D3\",\"barcode\":0,\"currentInventory\":0,\"storeLocation\":null,\"name\":\"Enxada\",\"costPrice\":0,\"salePrice\":0,\"observation\":null}]";
            List<CatalogProductModel> list = JsonSerializer.Deserialize<List<CatalogProductModel>>(serializer);
            list.ForEach(x => _productService.ProductSaveAsync(x));
            await App.Current.MainPage.DisplayAlert("Alert", "Download conclued.", "Back");

        }

        private async Task<HttpResponseMessage> PostJson(string serialize)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(serialize, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(ApiConstants.ApiPostUri, content);
        }

        private async Task Login()
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = FirebaseConstants.ApiKey,
                AuthDomain = FirebaseConstants.Domain,
                Providers = new FirebaseAuthProvider[] { new EmailProvider() }
            };

            _client = new FirebaseAuthClient(config);

            try
            {
                await _client.SignInWithEmailAndPasswordAsync(EmailUser, Password);
            }
            catch (FirebaseAuthException e)
            {
                throw new FirebaseAuthException("Email or password invalid.", e.Reason);
            }
        }
    }
}
