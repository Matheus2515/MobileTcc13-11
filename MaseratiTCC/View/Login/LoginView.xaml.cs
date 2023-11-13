using MaseratiTCC.View.Cadastro;
using MaseratiTCC.ViewModels.Usuarios;

namespace MaseratiTCC.View.Login;

public partial class LoginView : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public LoginView()
	{
		InitializeComponent();
        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;
    }

    private void btnEsqueceu_Clicked(object sender, EventArgs e)
    {

    }

    private void btnConfirmar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TipoCadastro());
    }
}