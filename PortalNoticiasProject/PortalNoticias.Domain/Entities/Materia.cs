using PortalNoticias.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("Materia")]
    public class Materia : Entity
    {
        [Column(name: "ID_CATEGORIA", Order = 2)]
        public string CodigoCategoria { get; set; }

        [Column(name: "TITULO", Order = 3)]
        public string Titulo { get; set; }

        [Column(name: "ID_RESPONSAVEL", Order = 4)]
        public DateTime CodigoResponsavel { get; set; }

        [Column(name: "DATA_PUBLICACAO", Order = 5)]
        public DateTime? DataPublicacao { get; set; }

        [Column(name: "IMG_PRINCIPAL", Order = 6)]
        public string ImagemPrincipal { get; set; }

        [Column(name: "IMG_PRINCIPAL_LEGENDA", Order = 7)]
        public string ImagemPrincipalLegenda { get; set; }

        [Column(name: "TEXTO", Order = 8)]
        public string TextoImagemPrincipalLegenda { get; set; }
    }
}
