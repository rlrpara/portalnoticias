using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Models
{
    public class Entity
    {
        [Key]
        [Column("ID", Order = 1)]
        public int Codigo { get; set; }

        [Column("DATA_CRIADO", Order = 100)]
        public DateTime DataCriado { get; set; }

        [Column("DATA_ATUALIZADO", Order = 101)]
        public DateTime DataAtualizacao { get; set; }

        [Column("DELETADO", Order = 102)]
        public bool IsDelete { get; set; }
    }
}
