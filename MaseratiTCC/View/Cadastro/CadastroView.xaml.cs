using MaseratiTCC.View.Login;
using MaseratiTCC.ViewModels.Usuarios;

namespace MaseratiTCC.View.Cadastro;

public partial class CadastroView : ContentPage
{
    UsuarioViewModel viewModel;
    public CadastroView()
	{
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
    }
    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TipoCadastro());
    }

    private void btnAvancar_Clicked(object sender, EventArgs e)
    {

    }
}