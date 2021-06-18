using PortalNoticias.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("PERFIL_USUARIO_PERMISSAO")]
    public class PerfilUsuarioPermissao : Entity
    {
        [Column(name: "ID_PERFIL", Order = 2)]
        public int CodigoPerfil { get; set; }

        [Column(name: "X_LER", Order = 3)]
        public bool Ler { get; set; }

        [Column(name: "X_ADICIONAR", Order = 4)]
        public bool Adicionar { get; set; }

        [Column(name: "X_EDITAR", Order = 5)]
        public bool Editar { get; set; }

        [Column(name: "X_GRAVAR", Order = 6)]
        public bool Gravar { get; set; }

        [Column(name: "X_APAGAR", Order = 7)]
        public bool Apagar { get; set; }
    }
}
