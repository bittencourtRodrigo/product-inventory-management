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
                var userId = await _cloudService.Login(EmailUser, Password);
                await _productService.DefineUserIdAllProductsAsync(userId);
                HttpResponseMessage status = await _cloudService.PostJson(await _productService.ProductGetAllAsync(), ApiConstants.SavePostUri);
                await App.Current.MainPage.DisplayAlert("Alert", $"Finish. {status.StatusCode}", "Back");
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
            try
            {
                var userId = await _cloudService.Login(EmailUser, Password);
                HttpResponseMessage response = await _cloudService.PostJson(userId, ApiConstants.ListByUidPostUri);
                List<CatalogProductModel> products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CatalogProductModel>>(await response.Content.ReadAsStringAsync());
                await _productService.ProductSaveRangeAsync(products);
                await App.Current.MainPage.DisplayAlert("Alert", "Finish.", "Back");
            }
            catch (FirebaseAuthException e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "Back");
                return;
            }
        }
    }
}