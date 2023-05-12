using Epr3.ViewModels;

namespace Epr3.Views;

public partial class CatalogClientView : ContentPage
{
	public CatalogClientView(CatalogClientViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}