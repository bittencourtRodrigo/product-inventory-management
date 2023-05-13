using Epr3.ViewModels;

namespace Epr3.Views;

public partial class ProductSaveView : ContentPage
{
	public ProductSaveView(ProductSaveViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}