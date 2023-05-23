using Epr3.ViewModels;
namespace Epr3.Views;
public partial class CloudManagerView : ContentPage
{
	public CloudManagerView(CloudManagerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}