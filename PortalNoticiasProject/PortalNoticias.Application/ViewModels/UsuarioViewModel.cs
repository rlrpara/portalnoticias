using PortalNoticias.Infra.CrossCutting.Util.ExtensionMethods;

namespace PortalNoticias.Services.ViewModels
{
    public class UsuarioViewModel
    {
        private string _nome;
        private string _email;
        private string _senha;

        public int Codigo { get; set; }
        public string Nome {
            get { return _nome; }
            set { _nome = value.RemoveAcentos(); }
        }
        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public string Senha {
            get { return _senha; }
            set { _senha = value; }
        }

        public int CodigoPerfil { get; set; }
        public bool isDelete { get; set; }
    }
}
