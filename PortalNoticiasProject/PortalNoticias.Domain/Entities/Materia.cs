using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("Materia")]
    public class Materia
    {
        [Column("ID")]
        public int Codigo { get; set; }

        [Column("ID_CATEGORIA")]
        public string CodigoCategoria { get; set; }

        [Column("TITULO")]
        public string Titulo { get; set; }

        [Column("DATA_PUBLICACAO")]
        public DateTime DataCadastro { get; set; }

        [Column("ID_RESPONSAVEL")]
        public DateTime CodigoResponsavel { get; set; }

        [Column("DATA_PUBLICACAO")]
        public DateTime? DataPublicacao { get; set; }

        [Column("IMG_PRINCIPAL")]
        public string ImagemPrincipal { get; set; }

        [Column("IMG_PRINCIPAL_LEGENDA")]
        public string ImagemPrincipalLegenda { get; set; }

        [Column("TEXTO")]
        public string TextoImagemPrincipalLegenda { get; set; }
    }
}
