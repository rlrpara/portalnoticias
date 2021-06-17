namespace PortalNoticias.Services.ViewModels
{
    public class UserAuthenticateResponseViewModel
    {
        public UsuarioViewModel Usuario { get; set; }
        public string Token { get; set; }

        public UserAuthenticateResponseViewModel(UsuarioViewModel usuarioViewModel, string token)
        {
            Usuario = usuarioViewModel;
            Token = token;
        }
    }
}
