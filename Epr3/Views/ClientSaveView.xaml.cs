using Epr3.ViewModels;

namespace Epr3.Views;

public partial class ClientSaveView : ContentPage
{
	public ClientSaveView(ClientSaveViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}