using PortalNoticias.Infra.Util.ExtensionMethods;

namespace PortalNoticias.Services.ViewModels
{
    public class UsuarioViewModel
    {
        private string _nome;
        private string _email;

        public int Codigo { get; set; }
        public string Nome {
            get { return _nome; }
            set { _nome = value.RemoveAcentos(); }
        }
        public string Email {
            get { return _email; }
            set { _email = value; }
        }

    }
}
