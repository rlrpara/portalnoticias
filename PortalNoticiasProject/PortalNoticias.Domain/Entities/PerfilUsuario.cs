using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("PERFIL_USUARIO")]
    public class PerfilUsuario
    {
        [Column("ID")]
        public int Codigo { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }
    }
}
