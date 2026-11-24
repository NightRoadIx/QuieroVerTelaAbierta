using QuieroVerTelaAbierta.ViewModels;

namespace QuieroVerTelaAbierta.Views;

public partial class ContadorPage : ContentPage
{
	public ContadorPage(ContadorViewModel viewModel)
	{
		InitializeComponent();
        // Se establece el BindingContext de la página al ViewModel inyectado
        BindingContext = viewModel;
	}
}