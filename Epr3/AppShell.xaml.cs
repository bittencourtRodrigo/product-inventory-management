using Epr3.Views;

namespace Epr3;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ProductSaveView), typeof(ProductSaveView));
		Routing.RegisterRoute(nameof(CatalogProductView), typeof(CatalogProductView));
	}
}
