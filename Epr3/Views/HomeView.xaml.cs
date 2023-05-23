using Epr3.ViewModels;
namespace Epr3.Views;
public partial class HomeView : ContentPage
{
	public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}