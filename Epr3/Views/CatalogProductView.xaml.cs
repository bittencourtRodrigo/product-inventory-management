using Epr3.ViewModels;

namespace Epr3.Views;

public partial class CatalogProductView : ContentPage
{
	public CatalogProductView(CatalogProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}