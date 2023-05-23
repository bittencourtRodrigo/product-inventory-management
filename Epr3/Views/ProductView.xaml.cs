using Epr3.ViewModels;
namespace Epr3.Views;
public partial class ProductView : ContentPage
{
	public ProductView(ProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}