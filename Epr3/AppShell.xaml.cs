using Epr3.Views;

namespace Epr3;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ProductView), typeof(ProductView));
		Routing.RegisterRoute(nameof(CatalogProductView), typeof(CatalogProductView));
		Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
		Routing.RegisterRoute(nameof(DownProductView), typeof(DownProductView));
		Routing.RegisterRoute(nameof(CloudManagerView), typeof(CloudManagerView));
	}
}
