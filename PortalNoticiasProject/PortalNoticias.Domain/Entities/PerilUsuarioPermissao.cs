using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("PERFIL_USUARIO_PERMISSAO")]
    public class PerilUsuarioPermissao
    {
        [Column("ID")]
        public int Codigo { get; set; }

        [Column("ID_PERFIL")]
        public int CodigoPerfil { get; set; }

        [Column("X_LER")]
        public bool Ler { get; set; }

        [Column("X_ADICIONAR")]
        public bool Adicionar { get; set; }

        [Column("X_EDITAR")]
        public bool Editar { get; set; }

        [Column("X_GRAVAR")]
        public bool Gravar { get; set; }

        [Column("X_APAGAR")]
        public bool Apagar { get; set; }
    }
}
