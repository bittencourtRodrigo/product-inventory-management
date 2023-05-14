using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.Navigation;
using Epr3.Services.ProductSave;
using Epr3.Views;

namespace Epr3.ViewModels
{
    [QueryProperty(nameof(Product), nameof(CatalogProductModel))]
    public partial class ProductSaveViewModel : ObservableObject
    {
        private readonly IProductSaveService _productSaveService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private CatalogProductModel _product;

        public ProductSaveViewModel(IProductSaveService productService, INavigationService navigationService)
        {
            _productSaveService = productService;
            _navigationService = navigationService;
            Product = new CatalogProductModel();
        }

        [RelayCommand]
        private async Task ProductSaveAsync()
        {
            if (Product.Name == null)
            {
                await App.Current.MainPage.DisplayAlert("Alert", $"{nameof(Product.Name)} cannot be empyt.", "Close");
                return;
            }

            await _productSaveService.ProductSaveAsync(Product);
            await App.Current.MainPage.DisplayAlert("Alert", $"{Product.Name} was saved locally.", "Close");
            await _navigationService.NavigateToAsync("../..");
        }
    }
}