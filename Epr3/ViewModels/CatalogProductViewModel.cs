using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Models.Enums;
using Epr3.Services.CatalogProduct;
using Epr3.Services.Navigation;
using Epr3.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        private async void ProductGetAll()
        {
            ProductList = new ObservableCollection<CatalogProductModel>(await _catalogProductService.ProductGetAll());
        }

        [RelayCommand]
        private async Task TapItem(object itemTapped)
        {
            var item = (CatalogProductModel)itemTapped;
            var choice = await Shell.Current.DisplayActionSheet(
                item.Name,
                "Cancel",
                null,
                new string[] {
                    nameof(ChoiceItemCatalog.Edit),
                    nameof(ChoiceItemCatalog.Delete)
                });

            if (choice == nameof(ChoiceItemCatalog.Edit))
            await _navigationService.NavigateToAsync(
                nameof(ProductSaveView),
                new Dictionary<string, object>() { { nameof(CatalogProductModel), item } }
                );
        }
    }
}