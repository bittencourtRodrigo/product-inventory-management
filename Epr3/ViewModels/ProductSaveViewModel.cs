using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.ProductSave;

namespace Epr3.ViewModels
{
    public partial class ProductSaveViewModel : ObservableObject
    {
        private readonly IProductSaveService _productSaveService;

        [ObservableProperty]
        private CatalogProductModel _product;

        public ProductSaveViewModel(IProductSaveService productService)
        {
            _productSaveService = productService;
            Product = new CatalogProductModel();
        }

        [RelayCommand]
        private async Task ProductSaveAsync()
        {
            if (Product.Name == null)
            {
                await App.Current.MainPage.DisplayAlert("Alert", $"{nameof(Product.Name)} cannot be empyt.", "CLose");
                return;
            }

            await _productSaveService.ProductSaveAsync(Product);
            await App.Current.MainPage.DisplayAlert("Alert", $"{Product.Name} was saved.", "Close");
            await Shell.Current.GoToAsync("..");
        }
    }
}