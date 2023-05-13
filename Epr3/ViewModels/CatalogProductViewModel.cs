using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.CatalogProduct;
using Epr3.Services.Navigation;
using Epr3.Views;
using System.Collections.ObjectModel;

namespace Epr3.ViewModels
{
    public partial class CatalogProductViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ICatalogProductService _catalogProductService;


        [ObservableProperty]
        ObservableCollection<CatalogProductModel> _productList;

        public CatalogProductViewModel(INavigationService navigationService, ICatalogProductService catalogProductService)
        {
            _navigationService = navigationService;
            _catalogProductService = catalogProductService;
            ProductGetAll();
        }

        [RelayCommand]
        private async Task ProductEditAsync()
        {
            await _navigationService.NavigateToAsync(nameof(ProductSaveView));
        }

        private async void ProductGetAll()
        {
            ProductList = new ObservableCollection<CatalogProductModel>(await _catalogProductService.ProductGetAll());
        }
    }
}
