using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Services.Navigation;
using Epr3.Services.ProductSave;
using System.Collections.ObjectModel;
namespace Epr3.ViewModels
{
    public partial class DownProductViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IProductService _productService;
        [ObservableProperty]
        ObservableCollection<CatalogProductModel> _productList;
        [ObservableProperty]
        ObservableCollection<BasketProductModel> _removeProductList;
        public DownProductViewModel(INavigationService navigationService, IProductService productService)
        {
            _navigationService = navigationService;
            _productService = productService;
            NewLists();
        }
        private async void NewLists()
        {
            ProductList = new ObservableCollection<CatalogProductModel>(await _productService.ProductGetAllAsync());
            RemoveProductList = new ObservableCollection<BasketProductModel>();
        }
        [RelayCommand]
        private void TapItemProductList(object itemTapped)
        {
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