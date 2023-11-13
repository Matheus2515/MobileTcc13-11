
using MaseratiTCC.Models;
using MaseratiTCC.Models.Enuns;
using MaseratiTCC.View.Login;
using MaseratiTCC.ViewModels.Usuarios;

namespace MaseratiTCC.View.Cadastro;

public partial class TipoCadastro : ContentPage
{
    UsuarioViewModel viewModel;

    public TipoCadastro()
    {
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginView());
    }

    private void btnAvancar_Clicked(object sender, EventArgs e)
    {
        if (viewModel.TipoUsuarioSelecionado.Descricao.Equals("Cliente"))
        {
            Navigation.PushAsync (new CadastroView()); 
        }
        else
        {
            Navigation.PushAsync (new CadastroEstabelecimento());
        }
    }
}