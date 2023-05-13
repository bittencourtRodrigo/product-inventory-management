using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.CatalogClient;
using Epr3.Services.CatalogProduct;
using Epr3.Services.Navigation;
using Epr3.Services.ProductSave;
using Epr3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private async Task ProductEditAsync(CatalogProductModel catalogProduct = null)
        {
            await _navigationService.NavigateToAsync(
                nameof(ProductSaveView),
                new Dictionary<string, object>() { { nameof(catalogProduct), catalogProduct } });
        }

        private async void ProductGetAll()
        {
            ProductList = new ObservableCollection<CatalogProductModel>(await _catalogProductService.ProductGetAll());
        }
    }
}
