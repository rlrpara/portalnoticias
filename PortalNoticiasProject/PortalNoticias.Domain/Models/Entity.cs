using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Models
{
    public class Entity
    {
        [Key]
        [Column(name: "ID", Order = 1)]
        public int Codigo { get; set; }

        [Column(name: "DATA_CRIADO", Order = 100)]
        public DateTime? DataCriado { get; set; } = DateTime.Now;

        [Column(name: "DATA_ATUALIZADO", Order = 101)]
        public DateTime? DataAtualizacao { get; set; } = DateTime.Now;

        [Column(name: "DELETADO", Order = 102)]
        public bool IsDelete { get; set; }
    }
}
