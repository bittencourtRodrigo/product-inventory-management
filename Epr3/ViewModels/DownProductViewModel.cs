using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.ItemSearcher;
using Epr3.Services.Navigation;
using Epr3.Services.ProductSave;
using System.Collections.ObjectModel;

namespace Epr3.ViewModels
{
    public partial class DownProductViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IProductService _productService;
        private readonly IItemSearcherService _itemSearcherService;

        [ObservableProperty]
        string _searchText;
        partial void OnSearchTextChanged(string value)
        {
            CatalogSearcher(value);
        }

        [ObservableProperty]
        ObservableCollection<CatalogProductModel> _productList;

        [ObservableProperty]
        ObservableCollection<BasketProductModel> _removeProductList;

        public DownProductViewModel(INavigationService navigationService, IProductService productService, IItemSearcherService itemSearcherService)
        {
            _navigationService = navigationService;
            _productService = productService;
            _itemSearcherService = itemSearcherService;
            CatalogSearcher(string.Empty);
        }

        private async void CatalogSearcher(string searchText)
        {
            ProductList = new ObservableCollection<CatalogProductModel>(await _itemSearcherService.SearchProduct(searchText));
        }

        [RelayCommand]
        private void TapItemProductList(object itemTapped)
        {
            RemoveProductList ??= new ObservableCollection<BasketProductModel>();
            CatalogProductModel product = (CatalogProductModel)itemTapped;
            RemoveProductList.Add(new BasketProductModel(product.Id, product.CurrentInventory, product.Name, 1));
        }

        [RelayCommand]
        private void TapItemRemoveProductList(object itemTapped)
        {
            BasketProductModel product = (BasketProductModel)itemTapped;
            RemoveProductList.Remove(product);
        }

        [RelayCommand]
        private async Task ConcludeAsync()
        {
            List<BasketProductModel> products = RemoveProductList.ToList();
            await _productService.ProductDownInventoryAsync(products);
            await _navigationService.NavigateToAsync("..");
        }
    }
}