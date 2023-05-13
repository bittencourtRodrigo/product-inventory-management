﻿using CommunityToolkit.Mvvm.Input;
using Epr3.Services.Navigation;
using Epr3.Views;

namespace Epr3.ViewModels
{
    public partial class HomeViewModel
    {
        private readonly INavigationService _navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        public async Task NavigateToCatalogProductViewAsync()
        {
            await _navigationService.NavigateToAsync(nameof(CatalogProductView));
        }

        [RelayCommand]
        public async Task NavigateToProductSaveViewAsync()
        {
            await _navigationService.NavigateToAsync(nameof(ProductSaveView));
        }
    }
}