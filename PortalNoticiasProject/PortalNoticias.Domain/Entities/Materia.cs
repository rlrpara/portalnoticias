using System;

namespace PortalNoticias.Domain.Entities
{
    public class Materia : EntityBase
    {
        public string CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public string Titulo { get; set; }
        public DateTime CodigoResponsavel { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string ImagemPrincipal { get; set; }
        public string ImagemPrincipalLegenda { get; set; }
        public string TextoImagemPrincipalLegenda { get; set; }
    }
}
