using System;

namespace PortalNoticias.Domain.Entities
{
    public class EntityBase
    {
        public int Codigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Removido { get; set; }
    }
}
