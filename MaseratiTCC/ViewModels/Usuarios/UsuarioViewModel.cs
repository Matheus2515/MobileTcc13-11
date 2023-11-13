
using MaseratiTCC.Models;
using MaseratiTCC.Models.Enuns;
using MaseratiTCC.Services.Usuarios;
using MaseratiTCC.View.Cadastro;
using MaseratiTCC.View.Login;
using MauiApp1.View.Senhas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MaseratiTCC.ViewModels.Usuarios
{

    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ICommand DirecionarRecuperarSenhaCommand { get; set; }
        public ICommand DirecionarRecuperarSenha3Command { get; set; }
        public ICommand DirecionarRecuperarSenha2Command { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }
        public ICommand DirecionarMainPageCommand { get; set; }
        public ICommand DirecionarLoginCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }


        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            InicializarCommands();
            _ = ObterTipoUsuario();
        }

        public void InicializarCommands()
        {
            DirecionarRecuperarSenhaCommand = new Command(async () => await DirecionarParaRecuperarSenha());
            DirecionarRecuperarSenha3Command = new Command(async () => await DirecionarParaRecuperarSenha3());
            DirecionarRecuperarSenha2Command = new Command(async () => await DirecionarParaRecuperarSenha2());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
            DirecionarMainPageCommand = new Command(async () => await DirecionarParaMainPage());
            DirecionarLoginCommand = new Command(async () => await DirecionarParaLogin());
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        private string senha = string.Empty;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

        private long cpf;
        public long Cpf
        {
            get { return cpf; }
            set
            {
                cpf = value;
                OnPropertyChanged(nameof(Cpf));
            }
        }

        private TipoUsuario tipoUsuarioSelecionado;
        public TipoUsuario TipoUsuarioSelecionado
        {
            get { return tipoUsuarioSelecionado; }
            set
            {
                if (value != null)
                {
                    tipoUsuarioSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<TipoUsuario> listaTiposUsuario;
        public ObservableCollection<TipoUsuario> ListaTiposUsuarios
        {
            get { return listaTiposUsuario; }
            set
            {
                if (value != null)
                {
                    listaTiposUsuario = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task ObterTipoUsuario()
        {
            try
            {
                ListaTiposUsuarios = new ObservableCollection<TipoUsuario>();
                ListaTiposUsuarios.Add(new TipoUsuario() { Id = 0, Descricao = "Cliente" });
                ListaTiposUsuarios.Add(new TipoUsuario() { Id = 1, Descricao = "Estabelecimento" });
                OnPropertyChanged(nameof(ListaTiposUsuarios));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task RegistrarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Email = Email;
                u.Nome = Nome;
                u.Senha = Senha;
                u.Cpf = Cpf;

                Usuario uRegistrado = await uService.PostResgistrarUsuarioAsync(u);

                if (uRegistrado.Id != 0)
                {
                    string mensagem = $"Usuário Id {uRegistrado.Id} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage.
                        Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Email = Email;
                u.Senha = Senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Nome}.";
                    Preferences.Set("UsuarioId", uAutenticado.Id);
                    Preferences.Set("UsuarioEmail", uAutenticado.Email);
                    Preferences.Set("UsuarioNome", uAutenticado.Nome);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);

                    await Application.Current.MainPage
                        .DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage.
                        Navigation.PushAsync(new AppShell());
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :C", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new CadastroView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaLogin()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new LoginView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaMainPage()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaRecuperarSenha()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new RecuperarSenhaPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaRecuperarSenha2()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new RecuperarSenhaPage2());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaRecuperarSenha3()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new RecuperarSenhaPage3());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

    }
}
