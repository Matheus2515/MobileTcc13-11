using MaseratiTCC.ViewModels.Usuarios;


namespace MauiApp1.View.Senhas;

public partial class RecuperarSenhaPage : ContentPage
{
    UsuarioViewModel viewModel;

    public RecuperarSenhaPage()
	{
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
    }

    private void btnAvancar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RecuperarSenhaPage2());
    }
}