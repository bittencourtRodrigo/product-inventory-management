using Epr3.Views;

namespace Epr3;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ClientSaveView), typeof(ClientSaveView));
		Routing.RegisterRoute(nameof(ProductSaveView), typeof(ProductSaveView));
		Routing.RegisterRoute(nameof(CatalogClientView), typeof(CatalogClientView));
		Routing.RegisterRoute(nameof(CatalogProductView), typeof(CatalogProductView));
	}
}
