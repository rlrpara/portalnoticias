namespace PortalNoticias.Domain.Entities
{
    public class UsuarioPerfil : EntityBase
    {
        public string Nome { get; set; }
        public bool Ler { get; set; }
        public bool Adicionar { get; set; }
        public bool Editar { get; set; }
        public bool Gravar { get; set; }
        public bool Apagar { get; set; }
    }
}
