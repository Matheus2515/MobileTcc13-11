using MaseratiTCC.View.Login;
using MaseratiTCC.ViewModels.Usuarios;

namespace MauiApp1.View.Senhas;


public partial class RecuperarSenhaPage3 : ContentPage
{

    UsuarioViewModel viewModel;
    public RecuperarSenhaPage3()
	{
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
    }

    private void btnFinalizar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginView());
    }
}