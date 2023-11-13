

using MaseratiTCC.ViewModels.Usuarios;

namespace MauiApp1.View.Senhas;



public partial class RecuperarSenhaPage2 : ContentPage
{
    UsuarioViewModel viewModel;

    public RecuperarSenhaPage2()
	{
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
    }

    private void btnEnviar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RecuperarSenhaPage3());
    }

    private void btnReenviar_Clicked(object sender, EventArgs e)
    {

    }
}