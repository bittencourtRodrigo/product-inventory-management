using Epr3.Models;
using Epr3.Services.ProductSave;
namespace Epr3.Services.ItemSearcher
{
    public class ItemSearcherService : IItemSearcherService
    {
        private readonly IProductService _productService;
        public async Task<List<CatalogProductModel>> SearchProduct(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return await _productService.ProductGetAllAsync();
            string[] search = searchText.ToLower().Split(' ');
            var filteredProducts = await _productService.ProductGetAllAsync();
            foreach (var item in search)
            {
                filteredProducts = filteredProducts.Where(x => x.Name.ToLower().Contains(item)).ToList();
            }
            return filteredProducts;
        }
        public ItemSearcherService(IProductService productService)
        {
            _productService = productService;
        }
    }
}