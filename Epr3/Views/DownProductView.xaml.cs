using Epr3.ViewModels;

namespace Epr3.Views;

public partial class DownProductView : ContentPage
{
	public DownProductView(DownProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}