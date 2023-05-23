using Epr3.Data;
using Epr3.Services.Cloud;
using Epr3.Services.ItemSearcher;
using Epr3.Services.Navigation;
using Epr3.Services.ProductSave;
using Epr3.ViewModels;
using Epr3.Views;
using Microsoft.Extensions.Logging;
namespace Epr3;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IProductService, ProductService>();
        builder.Services.AddSingleton<ICloudService, CloudService>();
        builder.Services.AddSingleton<IItemSearcherService, ItemSearcherService>();
        builder.Services.AddSingleton<SqliteDatabase>();
        builder.Services.AddTransient<CatalogProductViewModel>();
        builder.Services.AddTransient<CatalogProductView>();
        builder.Services.AddTransient<ProductViewModel>();
        builder.Services.AddTransient<ProductView>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<DownProductViewModel>();
        builder.Services.AddTransient<DownProductView>();
        builder.Services.AddTransient<CloudManagerViewModel>();
        builder.Services.AddTransient<CloudManagerView>();
        return builder.Build();
    }
}