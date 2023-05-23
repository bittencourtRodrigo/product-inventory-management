using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Epr3.Models;
using Epr3.Models.Enums;
using Epr3.Services.Navigation;
using Epr3.Services.ProductSave;
using Epr3.Views;
using System.Collections.ObjectModel;
namespace Epr3.ViewModels
{
    public partial class CatalogProductViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IProductService _productService;
        [ObservableProperty]
        ObservableCollection<CatalogProductModel> _productList;
        public CatalogProductViewModel(INavigationService navigationService, IProductService productService)
        {
            _navigationService = navigationService;
            _productService = productService;
            NewLists();
        }
        private async void NewLists()
        {
            ProductList = new ObservableCollection<CatalogProductModel>(await _productService.ProductGetAllAsync());
        }
        private async Task DeleteAsync(CatalogProductModel item)
        {
            string choice = await Shell.Current.DisplayActionSheet($"ALERT! '{item.Name}' will be deleted.", "Cancel", null, new string[] { nameof(ChoiceItemCatalog.Delete) });
            if (choice != nameof(ChoiceItemCatalog.Delete))
                return;
            await _productService.ProductDeleteAsync(item);
            await _navigationService.NavigateToAsync("../..");
        }
        [RelayCommand]
        private async Task TapItem(object itemTapped)
        {
            CatalogProductModel item = (CatalogProductModel)itemTapped;
            string choice = await Shell.Current.DisplayActionSheet(item.Name, "Cancel", null, new string[] { nameof(ChoiceItemCatalog.Edit), nameof(ChoiceItemCatalog.Delete) });
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { nameof(ChoiceItemCatalog.Edit), async () => await _navigationService.NavigateToAsync(nameof(ProductView), new Dictionary<string, object>() { { nameof(CatalogProductModel), item } }) },
                { nameof(ChoiceItemCatalog.Delete), async () => await DeleteAsync(item)}
            };
            if (actions.ContainsKey(choice))
            {
                await actions[choice]();
            }
        }
    }
}