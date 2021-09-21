namespace PortalNoticias.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int CodigoPerfil { get; set; }
        public UsuarioPerfil Perfil { get; set; }
    }
}
