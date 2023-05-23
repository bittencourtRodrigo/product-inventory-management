using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Data;
using Epr3.Models;
using Epr3.Services.Cloud;
using Epr3.Services.Navigation;
using Epr3.Services.ProductSave;
using Firebase.Auth;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Epr3.ViewModels
{
    public partial class CloudManagerViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IProductService _productService;
        private readonly ICloudService _cloudService;

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
                string userId = await _cloudService.Login(EmailUser, Password);
                string productsJson = JsonSerializer.Serialize(await _productService.ProductGetAllAsync());
                UserProductsJson userProductsJson = new UserProductsJson() { UserId = userId, ProductsJson = productsJson};
                HttpResponseMessage status = await _cloudService.PostJson(userProductsJson, ApiConstants.SavePostUri);
                await App.Current.MainPage.DisplayAlert("Alert", $"Upload Finish.", "Back");
            }
            catch (FirebaseAuthException e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "Back");
                return;
            }
            await _navigationService.NavigateToAsync("..");
        }
        
        [RelayCommand]
        private async Task DownloadAsync()
        {
            try
            {
                string userId = await _cloudService.Login(EmailUser, Password);
                HttpResponseMessage response = await _cloudService.PostJson(userId, ApiConstants.ListByUidPostUri);
                string productsJson = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
                List<CatalogProductModel> products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CatalogProductModel>>(productsJson);
                await _productService.ProductSaveRangeAsync(products);
                await App.Current.MainPage.DisplayAlert("Alert", "Download Finish.", "Back");
            }
            catch (FirebaseAuthException e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "Back");
                return;
            }
            await _navigationService.NavigateToAsync("..");
        }
        
        [RelayCommand]
        private async Task RegisterAsync()
        {
            try
            {
                await _cloudService.Register(EmailUser, Password);
                await App.Current.MainPage.DisplayAlert("Alert", "Register with success.", "Back");
            }
            catch (FirebaseAuthException e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "Back");
                return;
            }
        }
    }

    sealed class UserProductsJson
    {
        public string UserId { get; set; }
        public string ProductsJson { get; set; }
    }
}