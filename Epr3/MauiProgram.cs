using Epr3.Data;
using Epr3.Services.CatalogProduct;
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
        var builder = MauiApp.CreateBuilder();
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
        builder.Services.AddSingleton<ICatalogProductService, CatalogProductService>();
        builder.Services.AddSingleton<IProductSaveService, ProductSaveService>();

        builder.Services.AddSingleton<SqliteDatabase>();

        builder.Services.AddSingleton<CatalogProductViewModel>();
        builder.Services.AddSingleton<CatalogProductView>();

        builder.Services.AddSingleton<ProductSaveViewModel>();
        builder.Services.AddSingleton<ProductSaveView>();

        return builder.Build();
	}
}